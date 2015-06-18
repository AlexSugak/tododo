namespace Tododo.Managing.Errors

type Error = 
    | ValidationError of string
    | NotImplemented

