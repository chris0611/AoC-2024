module Helpers

open System
open System.IO
open type StringSplitOptions

let mapBoth f (a, b) =
  (f a, f b)

let private getPath inputFile =
  Path.Combine(Directory.GetCurrentDirectory(), $"input/{inputFile}")

let getInputAsString (inputFile: string): string =
  inputFile |> getPath |> File.ReadAllText
  
let getInputAsLines (inputFile: string): array<string> =
  inputFile |> getPath |> File.ReadAllLines