namespace Tododo.Scheduling.Api.Actors

open Orleankka.FSharp
open Tododo.Scheduling.Api
open Tododo.Scheduling.Api.Validators
open Tododo.Scheduling.Domain
open Tododo.Shared.ROP

type SchedulingMessage = 
    | MakeAppointment of MakeAppointment

type SchedulingActor() = 
    inherit Actor<SchedulingMessage>()

    override this.Receive message reply = task {
        match message with
        | MakeAppointment msg -> msg
                                    |> Schedule.handle
                                    |> reply
    }
