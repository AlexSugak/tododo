namespace Tododo.Scheduling.Api

open System

[<CLIMutable>]
type MakeAppointment = {
    Date : DateTimeOffset
    ClientName : string
}

