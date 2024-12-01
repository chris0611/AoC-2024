open System
open type StringSplitOptions
open Microsoft.FSharp.Collections
open Helpers // getInputAsLines, mapBoth

let part1 input =
  input
  |> mapBoth Array.sort
  ||> Array.zip
  |> Array.map (fun (l, r) -> abs (l - r))
  |> Array.sum

let part2 (lhs, rhs) =
  let rhs_count = rhs |> Seq.countBy id |> Map
  lhs
  |> Seq.countBy id
  |> Seq.sumBy(fun (k, factor) ->
    match rhs_count.TryFind(k) with
    | Some value -> (value * k) * factor 
    | None -> 0)

let input =
  getInputAsLines "input.txt"
    |> Array.map (fun line ->
      let pair = line.Split (' ', RemoveEmptyEntries)
      (int pair[0], int pair[1]))
    |> Array.unzip
  
part1 input |> printfn "Part 1: %d"
part2 input |> printfn "Part 2: %d"