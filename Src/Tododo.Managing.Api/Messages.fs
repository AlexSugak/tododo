namespace Tododo.Managing.Api

open System
open Tododo.Shared.Types

[<CLIMutable>]
type UpdateEmployee = {
    Id: Guid
    FirstName : string
    LastName : string
    Email : EmailAddress option
    ContactPhone: PhoneNumber option
}

