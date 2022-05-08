open System

let input = 
    let x = Console.ReadLine().Split()
    [for i in x -> 
        try
            Convert.ToInt32(i)
        with
            | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]

printfn "%A" input