[<AutoOpen>]
module Tododo.Shared.Converting

let convertsTo<'T> candidate = 
    match box candidate with 
        | :? 'T as converted -> Some(converted)
        | _ -> None


