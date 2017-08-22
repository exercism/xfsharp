module LeapYearTest

open NUnit.Framework
open FsUnit
open LeapYear
    
[<Test>]
let ``Is 1996 a valid leap year`` () = 
    isLeapYear 1996 |> should be true
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Is 1997 an invalid leap year`` () = 
    isLeapYear 1997 |> should be false
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Is the turn of the 20th century an invalid leap year`` () = 
    isLeapYear 1900 |> should be false
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Is the turn of the 25th century a valid leap year`` () = 
    isLeapYear 2400 |> should be true