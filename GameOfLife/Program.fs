let printCell x y state =
    if (state <> 0) then
        System.Console.SetCursorPosition(x, y)
        System.Console.Write("#")

let printBoard board =
    System.Console.Clear()
    board
    |> Array2D.iteri (fun x y v -> printCell x y v)

let rec game board =
    printBoard board
    System.Threading.Thread.Sleep(100)
    GameOfLifeCode.tick board 
    |> game

let rnd = System.Random()
let initialBoard size = Array2D.init size size (fun _ _ -> rnd.Next(2))

[<EntryPoint>]
let main argv = 
    game (initialBoard 30)
    0 // return an integer exit code
