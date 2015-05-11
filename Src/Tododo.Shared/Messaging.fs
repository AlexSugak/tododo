[<AutoOpen>]
module Tododo.Shared.Messaging

open System

type Envelope<'T> = {
    Id: Guid
    Date: DateTimeOffset
    Item: 'T
}

let envelope item getId getDate = 
    {
        Id = getId()
        Date = getDate()
        Item = item 
    }

let envelopeWithDefaults item = envelope item Guid.NewGuid (fun () -> DateTimeOffset.UtcNow)
