module Types

type HonorsStatus =
    | Honors
    | NoHonors

type Student = 
    struct 
        val Name : string
        val ID : int
        val GPA : float
        new(name, ID, gpa) = { Name = name; ID = ID; GPA = gpa }
    end

let student1 = new Student("Alice", 1, 3.8)
let student2 = new Student("Bob", 2, 3.2)
let student3 = new Student("Charlie", 3, 3.9)

let calculateHonors (std:Student) = std.GPA > 3.5

let getStudentInfo (std:Student) =
    match std with
    | _ when calculateHonors std -> sprintf "Student '%s' with ID %s qualifies for honors!" std.Name (std.ID.ToString())
    | _ -> $"Student '{std.Name}' with ID {std.ID} does not qualify for honors..."

let start() = 
    printfn "%s" (student1 |> getStudentInfo)
    printfn "%s" (student2 |> getStudentInfo)
    printfn "%s" (student3 |> getStudentInfo)