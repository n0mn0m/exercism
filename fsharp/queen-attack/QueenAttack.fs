module QueenAttack

let create (x, y) = x >= 0 && x < 8 && y >= 0 && y < 8

let canAttack (x1: int, y1: int) (x2: int, y2: int) =
    if x1 = x2 && y1 = y2
    then invalidOp "Queens cannot occupy the same space"
    else x1 = x2 || y1 = y2 || (x2 - x1 |> abs) = (y2 - y1 |> abs)
