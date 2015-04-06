namespace Tododo.Scheduling.Api

open System
open System.Web.Http
open System.Net.Http
open System.Net
open Tododo.Scheduling.Domain
open Tododo.Scheduling.Errors
open Tododo.Shared.ROP

[<RoutePrefix("api/appointments")>]
type AppointmentsController
    (
        makeAppointmentImp : MakeAppointmentRendition -> Result<unit, Error>
    ) = 
    inherit ApiController()
    
    [<Route("")>]
    member x.Get() = 
        x.Request.CreateResponse(HttpStatusCode.OK, "test all appointments")

    [<Route("{id:guid}")>]
    member x.Get(id: Guid) = 
        x.Request.CreateResponse(HttpStatusCode.OK, "test appointment")

    [<Route("")>]
    member x.Post(appointment: MakeAppointmentRendition) =
        match makeAppointmentImp appointment with 
        | Failure(ValidationError msg) -> x.BadRequest msg :> IHttpActionResult
        | _ -> x.StatusCode HttpStatusCode.Accepted :> IHttpActionResult 

