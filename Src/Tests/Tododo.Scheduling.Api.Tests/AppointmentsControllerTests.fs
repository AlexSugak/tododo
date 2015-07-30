module AppointmentsController

open System
open System.Net
open System.Web.Http
open Swensen.Unquote
open Tododo.Scheduling.Api
open Tododo.Scheduling.Errors
open Tododo.Shared
open Xunit.Extensions
open Ploeh.AutoFixture.Xunit

[<Theory; AutoData>]
let ``Post returns bad request on validation error`` (model: MakeAppointmentModel) = 
    let imp _ = Failure(ValidationError("error"))
    use sut = new AppointmentsController(imp)

    let result: IHttpActionResult = sut.Post model

    test <@ result :? Results.BadRequestErrorMessageResult @>   

[<Theory; AutoData>]
let ``Post returns Accepted on success`` (model: MakeAppointmentModel) = 
    let imp _ = Success(())
    use sut = new AppointmentsController(imp)

    let result: IHttpActionResult = sut.Post model

    test <@ result 
            |> convertsTo<Results.StatusCodeResult>
            |> Option.map (fun r -> r.StatusCode)
            |> Option.exists ((=) HttpStatusCode.Accepted) @>
