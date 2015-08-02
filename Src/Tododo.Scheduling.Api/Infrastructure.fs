module Tododo.Scheduling.Api.Infrastructure

open System
open System.Web.Http.Controllers
open System.Web.Http.Dispatcher
open System.Web.Http
open Tododo.Scheduling.Api.Actors
open Tododo.Scheduling.Errors
open Tododo.Shared
open Orleankka
open Orleankka.FSharp

type CompositionRoot(makeAppointment) = 
    interface IHttpControllerActivator with
        member this.Create(request, controllerDescriptor, controllerType) = 
            if controllerType = typeof<AppointmentsController> then
                new AppointmentsController(makeAppointment) :> IHttpController
            else 
                raise 
                <| ArgumentException(
                    sprintf "Unknown controller type requested: %O" controllerType,
                    "controllerType")

let ConfigureServices (config: HttpConfiguration) makeAppointment = 
    config.Services.Replace(typeof<IHttpControllerActivator>, CompositionRoot(makeAppointment))

let ConfigureRoutes (config: HttpConfiguration) = 
    config.MapHttpAttributeRoutes()

let ConfigureFormatting (config : HttpConfiguration) =
    config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <-
        Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()

let callActor (actor : ActorRef) m : Result<unit, Error>= 
    let job() = task {
        let! response = actor <? (SchedulingMessage.MakeAppointment m) 
        return response
    }

    match (Task.run job) with
    | Successful r -> r
    | Error ex -> Failure(InfrastructureError (ex.ToString()))
    | Canceled -> Failure(InfrastructureError "operation was cancelled")

let Configure config (actorSystem: IActorSystem) = 
    ConfigureRoutes config
    ConfigureServices config (fun r -> 
                                        let actor = actorSystem.ActorOf<SchedulingActor>("test")
                                        r 
                                        |> Validators.Appointment.validateMake 
                                        |> ROP.bind (callActor actor))
    ConfigureFormatting config
