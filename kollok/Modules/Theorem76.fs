module Theorem76

    open System

    let rec reverce list = 
        match list with
        | [] -> []
        | head :: tail -> reverce tail @ [head]

    let rec input() =
        let list= Console.ReadLine().Split()
        match list with
        | [|""|] -> []
        | _ -> [for i in list -> try Convert.ToInt32(i) with | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]
        
    let run() =
        printfn "This module reverses the list"
        printf "Enter the list, separating the elements by a space: "
        let list1 = input()
        let li1 = reverce list1
        printf "Function result (reversed list): "
        printfn "%A" li1

