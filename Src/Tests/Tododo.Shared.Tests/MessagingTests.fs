module Messaging

open System
open Tododo.Shared
open Swensen.Unquote
open Xunit

type TestItem = {
    Text: string
}

[<Theory>]
[<InlineData("22456F2B-349D-4757-8FE7-6C631492CB4A", 635640176610590924L, 2., "abc")>]
[<InlineData("FB219CD0-E2EC-41DB-90D3-EAED04C3294F", 635640176610590920L, 1., "foo")>]
let ``envelope must use input to create envelope`` (id: string) (ticks: int64) (offset: float) (text: string) = 
    let idGen _ = Guid id
    let dateGen _ = DateTimeOffset(ticks, TimeSpan.FromHours(offset))
    let item = { Text = text }
    let expected = { Id = (Guid id); Date = DateTimeOffset(ticks, TimeSpan.FromHours(offset)); Item = item }

    let result = envelope item idGen dateGen

    test <@ expected = result @>
