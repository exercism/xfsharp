module NthPrimeTest

open NUnit.Framework
open FsUnit
open NthPrime

[<Test>]
let ``First prime`` () =
    nthPrime 1 |> should equal 2

[<Test>]
[<Ignore("Remove to run test")>]
let ``Second prime`` () =
    nthPrime 2 |> should equal 3

[<Test>]
[<Ignore("Remove to run test")>]
let ``Third prime`` () =
    nthPrime 3 |> should equal 5

[<Test>]
[<Ignore("Remove to run test")>]
let ``4th prime`` () =
    nthPrime 4 |> should equal 7

[<Test>]
[<Ignore("Remove to run test")>]
let ``5th prime`` () =
    nthPrime 5 |> should equal 11

[<Test>]
[<Ignore("Remove to run test")>]
let ``6th prime`` () =
    nthPrime 6 |> should equal 13

[<Test>]
[<Ignore("Remove to run test")>]
let ``7th prime`` () =
    nthPrime 7 |> should equal 17

[<Test>]
[<Ignore("Remove to run test")>]
let ``8th prime`` () =
    nthPrime 8 |> should equal 19

[<Test>]
[<Ignore("Remove to run test")>]
let ``1000th prime`` () =
    nthPrime 1000 |> should equal 7919

[<Test>]
[<Ignore("Remove to run test")>]
let ``10000th prime`` () =
    nthPrime 10000 |> should equal 104729

[<Test>]
[<Ignore("Remove to run test")>]
let ``10001th prime`` () =
    nthPrime 10001 |> should equal 104743