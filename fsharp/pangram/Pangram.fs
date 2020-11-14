module Pangram

let isPangram (input: string): bool =
    input.ToLower()
    |> Seq.filter System.Char.IsLetter
    |> Set.ofSeq
    |> Set.count = 26
