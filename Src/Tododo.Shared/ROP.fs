[<AutoOpen>]
module Tododo.Shared.ROP


type Result<'TSuccess, 'TError> = 
    | Success of 'TSuccess
    | Failure of 'TError

let bind f x =
    match x with
        | Success s -> f s
        | Failure f -> Failure f

let map f x =
    match x with
        | Success s -> Success(f s)
        | Failure f -> Failure f