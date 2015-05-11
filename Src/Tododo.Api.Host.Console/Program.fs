﻿// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open Microsoft.Owin.Hosting

[<EntryPoint>]
let main argv = 
    let baseAddress = "http://localhost:8050"
    printfn "Starting web server at [%s]" baseAddress

    try 
        let app = WebApp.Start<Tododo.Scheduling.Api.OwinHost.Startup>(new StartOptions(baseAddress))
        ()
    with e -> 
        printfn "Error while starting web server\n%A" e
        reraise()

    printfn "Server started"

    System.Console.ReadLine() |> ignore
    1