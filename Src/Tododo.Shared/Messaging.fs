[<AutoOpen>]
module Tododo.Shared.Messaging

open System

type Envelope<'a> = {
    Id: Guid
    Date: DateTimeOffset
    Item: 'a
}

/// wraps message into envelope
let envelope item getId getDate = 
    {
        Id = getId()
        Date = getDate()
        Item = item 
    }

/// wraps message into envelope with default metadata values
let envelopeWithDefaults item = envelope item Guid.NewGuid (fun () -> DateTimeOffset.UtcNow)
