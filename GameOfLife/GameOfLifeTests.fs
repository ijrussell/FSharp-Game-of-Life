module GameOfLifeTests

open NUnit.Framework
open FsUnit
open GameOfLifeCode

[<Test>]
let ``Less than 2 or greater than 3 neighbours return dead`` 
    ([<Values(0,1,4,5)>] n, [<Values(0,1)>] status) =
        isAlive n status
        |> should equal 0

[<Test>]
let ``Exactly 3 neighbours return alive``
    ([<Values(0,1)>] status) =
        isAlive 3 status
        |> should equal 1
    
[<Test>]
let ``2 neighbours return current status`` 
    ([<Values(0,1)>] status) =
        isAlive 2 status
        |> should equal status

let emptyBoard = Array2D.init 3 3 (fun _ _ -> 0)

[<Test>]
let ``No neighbours returns 0`` () =
    let board = Array2D.copy emptyBoard
    neighbourCount 1 1 board
    |> should equal 0

[<Test>]
let ``All alive neighbours returns 8`` () =
    neighbourCount 1 1 (Array2D.init 3 3 (fun _ _ -> 1))
    |> should equal 8

[<Test>]
let ``Corner returns 3 alive neighbours`` 
    ([<Values(0, 2)>] x, [<Values(0, 2)>] y) =
        neighbourCount x y (Array2D.init 3 3 (fun _ _ -> 1))
        |> should equal 3

[<Test>]
let ``Vertical/horizontal cross returns 4`` () =
    let board = Array2D.copy emptyBoard
    board.[1,0] <- 1
    board.[0,1] <- 1
    board.[1,2] <- 1
    board.[2,1] <- 1
    neighbourCount 1 1 board
    |> should equal 4

[<Test>]
let ``Diagonal cross returns 4`` () =
    let board = Array2D.copy emptyBoard
    board.[0,0] <- 1
    board.[0,2] <- 1
    board.[2,0] <- 1
    board.[2,2] <- 1
    neighbourCount 1 1 board
    |> should equal 4

