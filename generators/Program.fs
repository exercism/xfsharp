﻿module Generators.Program

open Serilog
open Exercises
open Input
open Options

let regenerateTestClass options =
    let parseCanonicalData' = parseCanonicalData options

    fun (exercise: Exercise) ->
        let canonicalData = parseCanonicalData' exercise.Name
        exercise.Regenerate(canonicalData)

let regenerateTestClasses options =
    Log.Information("Re-generating test classes...")

    let regenerateTestClass' = regenerateTestClass options

    createExercises options.Exercises
    |> Seq.iter regenerateTestClass'

    Log.Information("Re-generated test classes.")

[<EntryPoint>]
let main argv = 
    setupLogger()

    match parseOptions argv with
    | Result.Ok(options) -> 
        regenerateTestClasses options
        0
    | Result.Error(errors) -> 
        Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
        1