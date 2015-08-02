module DomainTests

open Xunit.Extensions
open System
open Swensen.Unquote
open Tododo.Scheduling.Domain

let weekStartTestData : obj[] seq = 
    let toOffset t = match t with | (y, m, d, h, mm) -> new DateTimeOffset(y, m, d, h, mm, 0, TimeSpan.Zero)
    let toObjArray l = l |> List.map toOffset |> List.map box |> List.toArray

    seq {
        yield ([
                    (2015, 7, 27, 0, 0)//monday
                    (2015, 7, 27, 0, 0)//monday
               ] |> toObjArray)
        yield ([
                    (2015, 8, 1, 0, 0)//suterday
                    (2015, 7, 27, 0, 0)//monday
               ] |> toObjArray)
        yield ([
                    (2016, 1, 1, 4, 30)//friday
                    (2015, 12, 28, 0, 0)//monday
               ] |> toObjArray)
    }

[<Theory>]
[<PropertyData("weekStartTestData")>]
let ``weekStart must return correct result``
    (date: DateTimeOffset) 
    (expected: DateTimeOffset) =

    let actual = weekStart date DayOfWeek.Monday

    test <@ expected = actual @>
        
