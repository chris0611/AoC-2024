module Helpers

open System
open System.IO
open type StringSplitOptions

let mapBoth f (a, b) =
  (f a, f b)
  
let getInputAsString (inputFile: string): string =
  Path.Combine(Directory.GetCurrentDirectory(), $"input/{inputFile}")
  |> File.ReadAllText
  
let getInputAsLines (inputFile: string): seq<string> =
  getInputAsString(inputFile).Split([| '\n' |], RemoveEmptyEntries)
  |> seq<string>