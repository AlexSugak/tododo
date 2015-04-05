namespace Tododo.Shared

type Result<'TSuccess, 'TError> = 
    | Success of 'TSuccess
    | Failure of 'TError
