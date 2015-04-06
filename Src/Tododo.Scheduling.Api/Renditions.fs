namespace Tododo.Scheduling.Api

open System

[<CLIMutable>]
type MakeAppointmentRendition = {
    Date : string
    ClientName : string
}

