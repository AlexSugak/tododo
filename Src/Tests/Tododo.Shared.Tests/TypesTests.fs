module Types

open System
open Tododo.Shared
open Swensen.Unquote
open FsCheck.Xunit
open Xunit.Extensions
open Tododo.Shared.Types

[<Theory>]
[<InlineData("a@b.com")>]
[<InlineData("sam@bobins.com")>]
[<InlineData("sam@bobins.software")>]
let ``createEmailAddress returns correct value for valid emails`` 
    (input: string) =
     
    let result = createEmailAddress input
    let expected = Some(EmailAddress input)

    test <@ expected = result @>

[<Theory>]
[<InlineData("a")>]
[<InlineData("sam.com")>]
[<InlineData("@bobins.com")>]
let ``createEmailAddress returns correct value for invalid emails`` 
    (input: string) =
     
    let result = createEmailAddress input
    let expected : EmailAddress option = None

    test <@ expected = result @>

[<Theory>]
[<InlineData("123123")>]
[<InlineData("07987")>]
let ``createPhoneNumber returns correct value for valid numbers`` 
    (input: string) =
     
    let result = createPhoneNumber input
    let expected = Some(PhoneNumber input)

    test <@ expected = result @>

[<Theory>]
[<InlineData("")>]
let ``createPhoneNumber returns correct value for invalid numbers`` 
    (input: string) =
     
    let result = createPhoneNumber input
    let expected : PhoneNumber option = None

    test <@ expected = result @>
