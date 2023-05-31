module Palindrome

open System

let rec reverse (str:char array) =
    match str with
    | _ when str.Length = 0 -> [||]
    | _ -> Array.append (Array.tail str |> reverse) [| (Array.head str) |]
    

let checkPalindrome() =
        printfn "Please type a word: "

        let input = Console.ReadLine()

        let reversedString = input.ToCharArray()
                             |> reverse
                             |> System.String

        let isPalindrome = input = reversedString

        if isPalindrome then
            printfn "The word '%s' is a palindrome" input
        else
            printfn "The word '%s' is not a palindrome" input

let rec start() =
    checkPalindrome()
    printfn "Do you want to check another word? Y/N"
    let wantsRepeat = Console.ReadLine() = "Y"
    if wantsRepeat then
        start()