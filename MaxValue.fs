module MaxValue

open System

let getNumbersFromCommandLine() =
    Console.ReadLine().Split(",")
    |> Array.map(fun s -> s.Trim())
    |> Array.choose(
        fun s ->
            match Int32.TryParse(s) with
            | (true, n) -> Some n
            | _ -> None
    )

let rec MaxValue (intArr:int array) = 
    match intArr with
    | _ when intArr.Length = 0 -> 0
    | _ -> max (Array.head intArr) (Array.tail intArr |> MaxValue)

let start() =
    getNumbersFromCommandLine() |> MaxValue
                                |> fun i -> printfn "%i" i