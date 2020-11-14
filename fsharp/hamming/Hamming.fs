module Hamming

let distance (strand1: string) (strand2: string): int option =
    match Seq.length strand1 = Seq.length strand2 with
    | true ->
        Seq.map2 (fun a b ->
            if a <> b then 1 else 0) strand1 strand2
        |> Seq.sum
        |> Some
    | false -> None
