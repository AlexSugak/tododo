module Tododo.Scheduling.Api.Infrastructure

open System
open Tododo.Scheduling.Api
open System.Web.Http.Controllers
open System.Web.Http.Dispatcher
open System.Web.Http

type CompositionRoot() = 
    interface IHttpControllerActivator with
        member this.Create(request, controllerDescriptor, controllerType) = 
            if controllerType = typeof<AppointmentsController> then
                new AppointmentsController() :> IHttpController
            else 
                raise 
                <| ArgumentException(
                    sprintf "Unknown controller type requested: %O" controllerType,
                    "controllerType")

let ConfigureServices (config: HttpConfiguration) = 
    config.Services.Replace(typeof<IHttpControllerActivator>, CompositionRoot())

let ConfigureRoutes (config: HttpConfiguration) = 
    config.MapHttpAttributeRoutes()

let ConfigureFormatting (config : HttpConfiguration) =
    config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <-
        Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()

let Configure config = 
    ConfigureRoutes config
    ConfigureServices config
    ConfigureFormatting config
