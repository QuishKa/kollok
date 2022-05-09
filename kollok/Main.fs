open System

let rec input() = 
        try 
            Convert.ToInt32(Console.ReadLine())
        with
            | :? System.Exception -> printfn "Enter a number."; input()

// to run a module from main add its name in list and invoke run() function as with example
let modules = [ "example"; 
                "Greatest common divisor"; 
                "List Reversal, Lemma 7.5" ]
//
let mutable work = true
while work do
    Console.Clear()
    printfn "Colloquium 2022 made by group 0308.\nTo run a module enter its number.\nEnter 0 to close program.\nModules:"
    let mutable count = 0
    for i in modules do
        count <- count + 1
        printfn "%d: %s" count i
    match input() with
        | 0 -> work <- false
        | 1 -> example.run() // run example module (the number indicates the position of the module in the list)
        | 2 -> gcd.run()
        | 3 -> Lemma7_5.run()
    printfn "The module finished. Press any key to continue..."
    Console.ReadKey() |> ignore