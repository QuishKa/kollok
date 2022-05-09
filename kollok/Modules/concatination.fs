module concatination
    open System

    let rec append1 l1 l2 = 
        match l1 with
        [] -> l2
        | (h::t) -> h::(append1 t l2);;


    let input () = 
        let x = Console.ReadLine().Split()
        [for i in x -> 
            try
                Convert.ToInt32(i)
            with 
                | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]
    
    let run() = 
        printfn "This module prints concatination of two arrays\nInput 2 arrays to start."
        printfn "Enter the first List: "
        let l1 = input ()
        printfn "Enter the second List: "
        let l2 = input ()
        printfn " The result of append list1 list2 is: %A" (append1 l1 l2)