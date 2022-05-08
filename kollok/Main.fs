open System
let input() = 
    let x = Console.ReadLine().Split()
    [for i in x -> 
        try
            Convert.ToInt32(i)
        with
            | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]

let modules = ["example"]
let mutable work = true
while work do
    Console.Clear()
    printfn "Colloquium 2022 made by group 0308.\nTo run a module enter its number.\nEnter 0 to close program.\nModules:"
    let mutable count = 0
    for i in modules do
        count <- count + 1
        printfn "%d: %s" count i
    let rec input() = 
        try 
            Convert.ToInt32(Console.ReadLine())
        with
            | :? System.Exception -> printfn "Enter a number."; input()
    match input() with
        | 0 -> work <- false
        | 1 -> example.run;
    printfn "The module finished. Press any key to continue..."
    Console.ReadKey() |> ignore