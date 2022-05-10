module useful_combinator
    open System
    
    let input() = 
        let x = Console.ReadLine().Split()
        [for i in x -> 
            try
                Convert.ToInt32(i)
            with
                | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]
    
    
    let rec itlist f t b =
        match t with
        [] -> b
        | (h::t) -> f h (itlist f t b)
    
    let exists p l = itlist (fun h a -> p(h) || a) l false
    
    let mem x l = exists (fun y -> y = x) l
    
    let insert x l =
        if mem x l then l else x::l
    
    let union l1 l2 = itlist insert l1 l2
    
    let setify l = union l []
    
    let run() = 
        printf "This module is designed to convert a list to a set."
        printf "\nEnter a list of integers: "
        let intList = input()
        
        let res = setify(intList)
        printfn "Result set: %A" res
