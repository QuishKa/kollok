module Lemma_74

    open System

    let rec append list1  list2 = 
        match list1 with
        []->list2
        |(h::t)->h::(append t list2);;

    

    let input () = 
        let x = Console.ReadLine().Split()
        [for i in x -> Convert.ToInt32(i)]

    
    let run() =
        
        let list1 = []
        let list2=[]
        printfn "Enter the complete the list: "
        let list3 = input ()
        let result1 = append list2 list1
        let result2= append list3 list1 
        printfn "Verification of the assertion of Lemma 7.4"
        printfn "List 1: %A" (list1)
        printfn "List 2: %A" (list2)
        printfn "List 3: %A" (list3)
        printfn "The result of append list2 list1: %A" (result1)
        printfn "The result of append list3 list1: %A" (result2)
        
  