module Isogram

let isIsogram (str: string) =
    str.ToLowerInvariant()
    |> Seq.filter System.Char.IsLetter
    |> Seq.countBy (fun c -> c)
    |> Seq.forall (fun (_, x) -> x = 1)
