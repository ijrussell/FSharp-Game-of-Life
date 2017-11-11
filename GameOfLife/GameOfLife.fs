module GameOfLifeCode

    let isAlive neighbours status =
        match neighbours with
        | 3 -> 1
        | 2 -> status
        | _ -> 0
    
    let notSourceCell x y x' y' =
        not (x = x' && y = y')

    let inBounds x y size =
        x >= 0 && x < size && y >= 0 && y < size
    
    let neighbourCount x y (board:int[,]) =
        [ for dx in -1 .. +1 do
            for dy in -1 .. +1 do
                let m, n = x + dx, y + dy
                if (notSourceCell x y m n) && (inBounds m n (board.GetLength 0) ) then
                    yield board.[m, n] ]
        |> List.sum

    // tick event board -> board

