module Tododo.Scheduling.Api.Infrastructure

open System
open Tododo.Scheduling.Api
open System.Web.Http.Controllers
open System.Web.Http.Dispatcher
open System.Web.Http
open Tododo.Scheduling.Domain
open Tododo.Shared.ROP

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

let Configure config = 
    ConfigureRoutes config
    ConfigureServices config (fun r -> r |> Validators.Appointment.validateMake |> bind Schedule.handle)
    ConfigureFormatting config
