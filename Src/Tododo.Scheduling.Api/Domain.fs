namespace Tododo.Scheduling.Domain

open System
open Tododo.Scheduling.Errors
open Tododo.Scheduling.Api
open Tododo.Shared.ROP

[<AutoOpen>]
module Schedule = 
    let handle (cmd: MakeAppointment) : Result<unit, Error> = 
        Failure(NotImplemented)
    
    let weekStart (date: DateTimeOffset) (dof: DayOfWeek) : DateTimeOffset = 
        let diff = match int (date.DayOfWeek - dof) with 
                    | d when d < 0 -> d + 7
                    | d -> d
                   |> float

        let s = date.AddDays(-1.0 * diff)
        new DateTimeOffset(s.Year, s.Month, s.Day, 0, 0, 0, s.Offset)

    let id (date: DateTimeOffset) (start: DateTimeOffset -> DateTimeOffset) = 
        let s = date |> start
        sprintf "%i_%i_%i" s.Year s.Month s.Day
