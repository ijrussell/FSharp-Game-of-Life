module GameOfLifeCode

    let isAlive neighbours status =
        match neighbours with
        | 3 -> 1
        | 2 -> status
        | _ -> 0
    
    // neighbour count
    // tick event board -> board

