module AppointmentsController

open System
open System.Net
open System.Web.Http
open Swensen.Unquote
open Tododo.Scheduling.Api
open Tododo.Scheduling.Errors
open Tododo.Shared
open Xunit

[<Fact>]
let ``Post must return bad request on validation error`` () = 
    let imp _ = Failure(ValidationError("error"))
    use sut = new AppointmentsController(imp)
    let rendition: MakeAppointmentRendition = {
        Date = "2015-04-06"
        ClientName = "bob"}

    let result: IHttpActionResult = sut.Post rendition

    test <@ result :? Results.BadRequestErrorMessageResult @>     

[<Fact>]
let ``Post must return Accepted on success`` () = 
    let imp _ = Success(())
    use sut = new AppointmentsController(imp)
    let rendition: MakeAppointmentRendition = {
        Date = "2015-04-06"
        ClientName = "bob"}

    let result: IHttpActionResult = sut.Post rendition

    test <@ result 
            |> convertsTo<Results.StatusCodeResult>
            |> Option.map (fun r -> r.StatusCode)
            |> Option.exists ((=) HttpStatusCode.Accepted) @>
