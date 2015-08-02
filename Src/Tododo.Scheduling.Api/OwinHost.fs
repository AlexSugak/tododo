module Tododo.Scheduling.Api.OwinHost

open Owin
open System.Net
open System.Web.Http
open Microsoft.Owin.Hosting
open Infrastructure
open Orleankka
open Orleankka.Playground
open System.Reflection

type Startup() = 
    member this.Configuration(app: Owin.IAppBuilder) =
        let config = new HttpConfiguration()

        let actorSystem = ActorSystem
                            .Configure()
                            .Playground()
                            .Register(Assembly.GetExecutingAssembly())
                            .Done()

        Configure config actorSystem

        app.UseWebApi(config) |> ignore
        

