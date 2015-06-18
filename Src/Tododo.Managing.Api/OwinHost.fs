module Tododo.Managing.Api.OwinHost

open Owin
open System.Net
open System.Web.Http
open Microsoft.Owin.Hosting
open Infrastructure

type Startup() = 
    member this.Configuration(app: Owin.IAppBuilder) =
        let config = new HttpConfiguration()
        Configure(config)

        app.UseWebApi(config) |> ignore
        

