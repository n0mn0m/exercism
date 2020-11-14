module Raindrops

let convert (number: int): string =
    let s = [ "Pling"; "Plang"; "Plong" ]
    let d = [ 3; 5; 7 ]

    Seq.zip d s
    |> Seq.map (fun (d, s) ->
        if number % d = 0 then s else "")
    |> Seq.reduce (+)
    |> fun r ->
        if r <> "" then r else string number
