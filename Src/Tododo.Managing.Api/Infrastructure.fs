module Tododo.Managing.Api.Infrastructure

open System
open Tododo.Managing.Api
open System.Web.Http.Controllers
open System.Web.Http.Dispatcher
open System.Web.Http
open Tododo.Shared.ROP

type CompositionRoot(insertEmployee) = 
    interface IHttpControllerActivator with
        member this.Create(request, controllerDescriptor, controllerType) = 
            if controllerType = typeof<EmployeesController> then
                new EmployeesController(insertEmployee) :> IHttpController
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
    ConfigureServices config (fun r -> Success())
    ConfigureFormatting config
