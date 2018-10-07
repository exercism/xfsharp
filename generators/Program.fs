﻿module Generators.Program

open Serilog
open Exercise
open CanonicalData
open Generators
open Options

let private isNotFilteredByName options (exercise: Exercise) =
    match options.Exercise with
    | Some filteredExerciseName -> filteredExerciseName = exerciseName exercise
    | None -> true
    
let private isNotFilteredByStatus options (exercise: Exercise) =
    match options.Status, exercise with
    | None, _ -> true
    | Some Status.Implemented,   Exercise.Generator _     -> true
    | Some Status.Unimplemented, Exercise.Unimplemented _ -> true
    | Some Status.MissingData,   Exercise.MissingData _   -> true
    | Some Status.Deprecated,    Exercise.Deprecated _    -> true
    | Some Status.Custom,        Exercise.Custom _        -> true
    | _ -> false

let private shouldBeIncluded options (exercise: Exercise) =
    isNotFilteredByName options exercise &&
    isNotFilteredByStatus options exercise

let private regenerateTestClass options =
    let parseCanonicalData' = parseCanonicalData options

    fun (exercise) ->
        match exercise with
        | Exercise.Custom custom ->
            Log.Information("{Exercise}: has customized tests", custom.Name)
        | Exercise.Unimplemented unimplemented ->
            Log.Error("{Exercise}: missing test generator", unimplemented.Name)
        | Exercise.MissingData missingData ->
            Log.Warning("{Exercise}: missing canonical data", missingData.Name)
        | Exercise.Deprecated deprecated ->
            Log.Warning("{Exercise}: deprecated", deprecated.Name)
        | Exercise.Generator generator ->
            let canonicalData = parseCanonicalData' generator.Name
            generator.Regenerate(canonicalData)
            Log.Information("{Exercise}: tests generated", generator.Name)

let private regenerateTestClasses options =
    Log.Information("Re-generating test classes...")

    let regenerateTestClass' = regenerateTestClass options
    
    createExercises options
    |> List.filter (shouldBeIncluded options)
    |> function
        | [] -> Log.Warning "No exercises matched given options."
        | exercises ->
            List.iter regenerateTestClass' exercises
            Log.Information("Re-generated test classes.")

type ExerciseVersionStatus =
        | UpToDate
        | OutDated of string * string * string
        
let private checkOutdated options =
    Log.Information("Checking for outdated test classes...")
    
    let parseCanonicalData' = parseCanonicalData options
    
    let results = 
        createExercises options
        |> List.choose (function
                            | Generator g -> Some g
                            | _ -> None )
        |> List.map (fun exercise ->
            let cData = parseCanonicalData' exercise.Name
            
            match cData.Version,exercise.ReadVersion() with
            | canonVersion,exerciseVersion when canonVersion.Equals exerciseVersion -> UpToDate
            | canonVersion,exerciseVersion -> OutDated (exercise.Name,canonVersion,exerciseVersion)
        )
    
    let numUpToDate = results |> List.where (fun s -> s = UpToDate) |> List.length
    
    Log.Information (sprintf "%d exercises up to date." numUpToDate)
    
    let outdated = results |> List.choose (fun s ->
        match s with 
        | OutDated (x,y,z) -> Some (x,y,z)
        | UpToDate -> None
    )
    
    Log.Information (sprintf "%d exercises outdated / mismatched:" outdated.Length)
    
    let longestNameLength = outdated |> List.map (fun (a,_,_) -> a.Length) |> List.max
    
    outdated |> List.iter (fun (name,canonVersion,exerciseVersion) ->
        let numSpaces = longestNameLength - name.Length + 2
        let indentation = String.replicate numSpaces " "
        Log.Information (sprintf "%s%s%s -> %s" name indentation exerciseVersion canonVersion)
    )
    
    ()
    

[<EntryPoint>]
let main argv = 
    Logging.setupLogger()

    match parseOptions argv with
    | Ok(options) -> 
        regenerateTestClasses options
        0
    | Error(errors) when errors |> Seq.contains "CommandLine.HelpRequestedError" ->
        0
    | Error(errors) -> 
        Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
        1