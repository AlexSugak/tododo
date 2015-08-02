namespace Tododo.Scheduling.Errors

open System

type Error = 
    | ValidationError of string
    | NotImplemented
    | InfrastructureError of string

