namespace Tododo.Shared.Types

[<AutoOpen>]
module EmailAddressType = 

    open System.Text.RegularExpressions

    type EmailAddress = EmailAddress of string

    let createEmailAddress (s:string) = 
        if Regex.IsMatch(s, @"^\S+@\S+\.\S+$") 
            then Some (EmailAddress s)
            else None

[<AutoOpen>]
module PhoneNumberType = 
    
    open System

    type PhoneNumber = PhoneNumber of string

    let createPhoneNumber (s: string) : PhoneNumber option = 
        match String.IsNullOrEmpty(s) with
        | true -> None
        | false -> Some(PhoneNumber s)

