module example
    open System

    let input() = 
        let x = Console.ReadLine().Split()
        [for i in x -> 
            try
                Convert.ToInt32(i)
            with
                | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]

    let add x = x |> List.map (fun q -> q + 1)

    let run() =
        let mutable data = [] // using data as variable
        data <- input()
        // delete skipped values (zeros)
        match List.tryFindIndex(fun x -> x = 0) data with
            | Some index -> data <- List.removeAt index data
            | None -> None |> ignore
        //
        printfn "Entered array: %A" data
        printfn $"{add data}"