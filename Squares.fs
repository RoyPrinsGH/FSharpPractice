module Squares

open System

let start = 
    
    let numbers = Console.ReadLine().Split(",")
                |> Array.map(fun s -> s.Trim())
                |> Array.choose(
                    fun s ->
                        match Int32.TryParse(s) with
                        | (true, n) -> Some n
                        | _ -> None
                )

    let g = numbers
            |> Array.map(fun s -> s*s)
            |> Array.sum

    printf "%i" g