namespace Tododo.Scheduling.Api

open System

[<CLIMutable>]
type MakeAppointmentModel = {
    Date : string
    ClientName : string
}

