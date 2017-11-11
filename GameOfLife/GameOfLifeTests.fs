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