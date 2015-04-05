namespace Tododo.Scheduling.Api

open System
open System.Web.Http
open System.Net.Http
open System.Net

[<RoutePrefix("api/appointments")>]
type AppointmentsController() = 
    inherit ApiController()
    
    [<Route("")>]
    member x.Get() = 
        x.Request.CreateResponse(HttpStatusCode.OK, "test all appointments")

    [<Route("{id:guid}")>]
    member x.Get(id: Guid) = 
        x.Request.CreateResponse(HttpStatusCode.OK, "test appointment")
