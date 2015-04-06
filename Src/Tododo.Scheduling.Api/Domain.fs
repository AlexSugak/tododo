namespace Tododo.Scheduling.Domain

open System
open Tododo.Scheduling.Errors

module Schedule = 
    open Tododo.Scheduling.Api
    open Tododo.Shared.ROP

    let handle (cmd: MakeAppointment) = 
        Failure(NotImplemented)
    
