namespace Tododo.Scheduling.Api.Validators

open System
open Tododo.Scheduling.Api
open Tododo.Scheduling.Errors
open Tododo.Shared.ROP

module Appointment = 
    let validateMake (r: MakeAppointmentModel) = 
        match r.Date |> DateTimeOffset.TryParse with
            | (true, date) -> Success({ Date = date; ClientName = r.ClientName })
            | (false, _) -> Failure(ValidationError (sprintf "Failed to parse date: %s" r.Date))

