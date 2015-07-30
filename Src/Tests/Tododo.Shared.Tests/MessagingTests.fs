module Messaging

open System
open Tododo.Shared
open Swensen.Unquote
open FsCheck.Xunit

type TestItem = {
    Text: string
}

[<Property>]
let ``envelope uses input to create envelope`` 
    (id: Guid) 
    (date: DateTimeOffset) 
    (offset: float) 
    (text: string) =
     
    let idGen _ = id
    let dateGen _ = date
    let item = { Text = text }
    let expected = { Id = id; Date = date; Item = item }

    let result = envelope item idGen dateGen

    test <@ expected = result @>
