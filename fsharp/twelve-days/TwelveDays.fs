module TwelveDays

let nth =
    [ "first"; "second"; "third"; "fourth"; "fifth"; "sixth"; "seventh"; "eighth"; "ninth"; "tenth"; "eleventh"; "twelfth" ]

let nthObject =
    [ "a Partridge in a Pear Tree"
      "two Turtle Doves"
      "three French Hens"
      "four Calling Birds"
      "five Gold Rings"
      "six Geese-a-Laying"
      "seven Swans-a-Swimming"
      "eight Maids-a-Milking"
      "nine Ladies Dancing"
      "ten Lords-a-Leaping"
      "eleven Pipers Piping"
      "twelve Drummers Drumming" ]

let rec verseObject n =
    let part = nthObject.[n - 1]
    match n with
    | 1 -> part
    | 2 -> sprintf "%s, and %s" part (verseObject (n - 1))
    | _ -> sprintf "%s, %s" part (verseObject (n - 1))

let composeVerse n = sprintf "On the %s day of Christmas my true love gave to me: %s." nth.[n - 1] (verseObject n)

let recite start stop =
    seq { start .. stop }
    |> Seq.map composeVerse
    |> Seq.toList
