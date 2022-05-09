open System

let rec input() = 
        try 
            Convert.ToInt32(Console.ReadLine())
        with
            | :? System.Exception -> printfn "Enter a number."; input()


let modules = [ "example"; 
                "Greatest common divisor"; 
                "List Reversal, Lemma 7.5" 
                "Concatenation" 
                "Exceptions" 
                "Order relations" 
                "Power"
                "Type data"
                "Tail recursion"
                "Lexical analyzer"
                "Differentiation"
                "List Reversal, Theorem 7.6"
                "List Reversal, Lemma 7.4" ]

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
        | 1 -> example.run() // to run your module replace the example and type "1" in console
        | 2 -> gcd.run()
        | 3 -> Lemma7_5.run()
        | 4 -> concatination.run()
        | 5 -> exn.run()
        | 6 -> order_relation.run()
        | 7 -> power.run()
        | 8 -> Berezkin.run()
        | 9 -> tail_recursion.run()
        | 10 -> lexical_analyzer.run()
        | 11 -> differentiation.run()
        | 12 -> Theorem76.run()
        | 13 -> Lemma_74.run()
    printfn "The module finished. Press any key to continue..."
    Console.ReadKey() |> ignore