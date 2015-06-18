namespace Tododo.Managing.Api

open System

[<CLIMutable>]
type EmployeeModel = {
    Id: Guid
    FirstName : string
    LastName : string
}

