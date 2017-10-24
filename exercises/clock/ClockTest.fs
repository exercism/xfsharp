// This file was auto-generated based on version 1.0.1 of the canonical data.

module ClockTest

open FsUnit.Xunit
open Xunit

open Clock

[<Fact>]
let ``On the hour`` () =
    let clock = create 8 0
    clock |> display  |> should equal "08:00"

[<Fact(Skip = "Remove to run test")>]
let ``Past the hour`` () =
    let clock = create 11 9
    clock |> display  |> should equal "11:09"

[<Fact(Skip = "Remove to run test")>]
let ``Midnight is zero hours`` () =
    let clock = create 24 0
    clock |> display  |> should equal "00:00"

[<Fact(Skip = "Remove to run test")>]
let ``Hour rolls over`` () =
    let clock = create 25 0
    clock |> display  |> should equal "01:00"

[<Fact(Skip = "Remove to run test")>]
let ``Hour rolls over continuously`` () =
    let clock = create 100 0
    clock |> display  |> should equal "04:00"

[<Fact(Skip = "Remove to run test")>]
let ``Sixty minutes is next hour`` () =
    let clock = create 1 60
    clock |> display  |> should equal "02:00"

[<Fact(Skip = "Remove to run test")>]
let ``Minutes roll over`` () =
    let clock = create 0 160
    clock |> display  |> should equal "02:40"

[<Fact(Skip = "Remove to run test")>]
let ``Minutes roll over continuously`` () =
    let clock = create 0 1723
    clock |> display  |> should equal "04:43"

[<Fact(Skip = "Remove to run test")>]
let ``Hour and minutes roll over`` () =
    let clock = create 25 160
    clock |> display  |> should equal "03:40"

[<Fact(Skip = "Remove to run test")>]
let ``Hour and minutes roll over continuously`` () =
    let clock = create 201 3001
    clock |> display  |> should equal "11:01"

[<Fact(Skip = "Remove to run test")>]
let ``Hour and minutes roll over to exactly midnight`` () =
    let clock = create 72 8640
    clock |> display  |> should equal "00:00"

[<Fact(Skip = "Remove to run test")>]
let ``Negative hour`` () =
    let clock = create -1 15
    clock |> display  |> should equal "23:15"

[<Fact(Skip = "Remove to run test")>]
let ``Negative hour rolls over`` () =
    let clock = create -25 0
    clock |> display  |> should equal "23:00"

[<Fact(Skip = "Remove to run test")>]
let ``Negative hour rolls over continuously`` () =
    let clock = create -91 0
    clock |> display  |> should equal "05:00"

[<Fact(Skip = "Remove to run test")>]
let ``Negative minutes`` () =
    let clock = create 1 -40
    clock |> display  |> should equal "00:20"

[<Fact(Skip = "Remove to run test")>]
let ``Negative minutes roll over`` () =
    let clock = create 1 -160
    clock |> display  |> should equal "22:20"

[<Fact(Skip = "Remove to run test")>]
let ``Negative minutes roll over continuously`` () =
    let clock = create 1 -4820
    clock |> display  |> should equal "16:40"

[<Fact(Skip = "Remove to run test")>]
let ``Negative hour and minutes both roll over`` () =
    let clock = create -25 -160
    clock |> display  |> should equal "20:20"

[<Fact(Skip = "Remove to run test")>]
let ``Negative hour and minutes both roll over continuously`` () =
    let clock = create -121 -5810
    clock |> display  |> should equal "22:10"

[<Fact(Skip = "Remove to run test")>]
let ``Add minutes`` () =
    let clock = create 10 0
    let minutesToAdd = 3
    add minutesToAdd clock |> display  |> should equal "10:03"

[<Fact(Skip = "Remove to run test")>]
let ``Add no minutes`` () =
    let clock = create 6 41
    let minutesToAdd = 0
    add minutesToAdd clock |> display  |> should equal "06:41"

[<Fact(Skip = "Remove to run test")>]
let ``Add to next hour`` () =
    let clock = create 0 45
    let minutesToAdd = 40
    add minutesToAdd clock |> display  |> should equal "01:25"

[<Fact(Skip = "Remove to run test")>]
let ``Add more than one hour`` () =
    let clock = create 10 0
    let minutesToAdd = 61
    add minutesToAdd clock |> display  |> should equal "11:01"

[<Fact(Skip = "Remove to run test")>]
let ``Add more than two hours with carry`` () =
    let clock = create 0 45
    let minutesToAdd = 160
    add minutesToAdd clock |> display  |> should equal "03:25"

[<Fact(Skip = "Remove to run test")>]
let ``Add across midnight`` () =
    let clock = create 23 59
    let minutesToAdd = 2
    add minutesToAdd clock |> display  |> should equal "00:01"

[<Fact(Skip = "Remove to run test")>]
let ``Add more than one day (1500 min = 25 hrs)`` () =
    let clock = create 5 32
    let minutesToAdd = 1500
    add minutesToAdd clock |> display  |> should equal "06:32"

[<Fact(Skip = "Remove to run test")>]
let ``Add more than two days`` () =
    let clock = create 1 1
    let minutesToAdd = 3500
    add minutesToAdd clock |> display  |> should equal "11:21"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract minutes`` () =
    let clock = create 10 3
    let minutesToAdd = -3
    add minutesToAdd clock |> display  |> should equal "10:00"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract to previous hour`` () =
    let clock = create 10 3
    let minutesToAdd = -30
    add minutesToAdd clock |> display  |> should equal "09:33"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract more than an hour`` () =
    let clock = create 10 3
    let minutesToAdd = -70
    add minutesToAdd clock |> display  |> should equal "08:53"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract across midnight`` () =
    let clock = create 0 3
    let minutesToAdd = -4
    add minutesToAdd clock |> display  |> should equal "23:59"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract more than two hours`` () =
    let clock = create 0 0
    let minutesToAdd = -160
    add minutesToAdd clock |> display  |> should equal "21:20"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract more than two hours with borrow`` () =
    let clock = create 6 15
    let minutesToAdd = -160
    add minutesToAdd clock |> display  |> should equal "03:35"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract more than one day (1500 min = 25 hrs)`` () =
    let clock = create 5 32
    let minutesToAdd = -1500
    add minutesToAdd clock |> display  |> should equal "04:32"

[<Fact(Skip = "Remove to run test")>]
let ``Subtract more than two days`` () =
    let clock = create 2 20
    let minutesToAdd = -3000
    add minutesToAdd clock |> display  |> should equal "00:20"

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with same time`` () =
    let clock1 = create 15 37
    let clock2 = create 15 37
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks a minute apart`` () =
    let clock1 = create 15 36
    let clock2 = create 15 37
    clock1 = clock2  |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Clocks an hour apart`` () =
    let clock1 = create 14 37
    let clock2 = create 15 37
    clock1 = clock2  |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with hour overflow`` () =
    let clock1 = create 10 37
    let clock2 = create 34 37
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with hour overflow by several days`` () =
    let clock1 = create 3 11
    let clock2 = create 99 11
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative hour`` () =
    let clock1 = create 22 40
    let clock2 = create -2 40
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative hour that wraps`` () =
    let clock1 = create 17 3
    let clock2 = create -31 3
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative hour that wraps multiple times`` () =
    let clock1 = create 13 49
    let clock2 = create -83 49
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with minute overflow`` () =
    let clock1 = create 0 1
    let clock2 = create 0 1441
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with minute overflow by several days`` () =
    let clock1 = create 2 2
    let clock2 = create 2 4322
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative minute`` () =
    let clock1 = create 2 40
    let clock2 = create 3 -20
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative minute that wraps`` () =
    let clock1 = create 4 10
    let clock2 = create 5 -1490
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative minute that wraps multiple times`` () =
    let clock1 = create 6 15
    let clock2 = create 6 -4305
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative hours and minutes`` () =
    let clock1 = create 7 32
    let clock2 = create -12 -268
    clock1 = clock2  |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with negative hours and minutes that wrap`` () =
    let clock1 = create 18 7
    let clock2 = create -54 -11513
    clock1 = clock2  |> should equal true

