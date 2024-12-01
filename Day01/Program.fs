open System
open type StringSplitOptions
open Microsoft.FSharp.Collections
open Helpers // getInputAsLines, mapBoth

let Part1 input =
  let s0, s1 = mapBoth Seq.sort input
  (0, s0, s1) |||> Seq.fold2 (fun acc e0 e1 ->
    acc + abs (e0 - e1)
  )
  
let Part2 input =
  let counts0, counts1 = input |> mapBoth (fun e -> e |> Seq.countBy id |> Map)
  (0, counts0) ||> Seq.fold (fun acc entry ->
    match counts1.TryFind(entry.Key) with
    | Some value -> acc + (value * entry.Key) * entry.Value
    | None -> acc)

[<EntryPoint>]
let Day01 _ =
  let lines = getInputAsLines("test.txt")
  let pairs = lines |> Seq.map (fun line ->
    let pair = line.Split ([| ' ' |], RemoveEmptyEntries) in
    (pair[0], pair[1])
  ) in
  // Make list of pairs into a pair of lists
  let input = (([], []), pairs) ||> Seq.fold (fun (l0, l1) (e0, e1) ->
    ((e0, l0), (e1, l1)) |> mapBoth (fun (e, l) -> int(e) :: l)
  ) in

  Part1 input |> printfn "%d"
  Part2 input |> printfn "%d"
  0