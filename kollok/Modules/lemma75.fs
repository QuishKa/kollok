module Lemma7_5

    open System

    let rec append (l1 : 'a list) l2 = 
        if l1.IsEmpty = true then l2
        else l1.Head :: (append l1.Tail l2)

    let rec rev (lst : 'a list) =
        if lst.IsEmpty = true then []
        else append (rev lst.Tail) [lst.Head]

    let input () = 
        let x = Console.ReadLine().Split()
        [for i in x -> 
            try
                Convert.ToInt32(i)
            with 
                | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]

    let run () =
        printfn "This module implements the functions append (concatenation) and rev (reversal) of lists, and also demonstrates Lemma 7.5 (it is displayed below)." 
        printfn "Enter the first List: "
        let list1 = input ()
        printfn "Enter the second List: "
        let list2 = input ()
        let res1 = rev (append list1 list2)
        let res2 = append (rev list2) (rev list1)
        printfn "Lemma 7.5: rev (append list1 list2) = append (rev list2) (rev list1)"
        printfn "List 1: %A" (list1)
        printfn "List 2: %A" (list2)
        printfn "The result of rev (append list1 list2): %A" (res1)
        printfn "The result of append (rev list2) (rev list1): %A" (res2)
        if res1 = res2 then printfn "The lemma showed the true result!"
        else printfn "Something is wrong..."

        printfn "\nLet's do the operations step by step to make it clearer."
        printfn "Let's start with the first expression rev (append list1 list2)."
        printfn "1. The result of append list1 list2 is: %A" (append list1 list2)
        printfn "2. Full expressoin result: %A" (rev (append list1 list2))
        printfn "Then let's move on to the second expression append (rev list2) (rev list1)."
        printfn "1. The result of rev list2 is: %A" (rev list2)
        printfn "2. The result of rev list1 is: %A" (rev list1)
        printfn "3. Full expressoin result: %A" (append (rev list2) (rev list1))

        printfn "\n\nConsider the proof on a specific examples."
        let l1 = []
        let l2 = list2
        printfn "We know that rev (append l1 l2) in case of empty l1 will be equal to:"
        printfn "1. rev (append [] l2). And the result is: %A" (rev (append [] l2))
        printfn "2. rev l2. And the result is: %A" (rev l2)
        printfn "3. append (rev l2) []. And the result is: %A" (append (rev l2) [])
        printfn "4. append (rev l2) (rev []). And the result is: %A" (append (rev l2) (rev []))
        printfn "Which brings us to: append (rev l2) (rev l1). The result of this expression will be the following: %A" (append (rev l2) (rev l1))
        printfn "Also consider the result of the original expression: %A" (rev (append l1 l2))
        let l1 = list1
        printfn "\nIf l1 is non-empty and we know that rev (append t l2) = append (rev l2) (rev t),"
        printfn "then rev (append l1 l2) will be equal to:"
        printfn "1. rev (append (h :: t) l2). And the result is: %A" (rev (append (l1.Head :: l1.Tail) l2))
        printfn "2. rev (h :: (append t l2)). And the result is: %A" (rev (l1.Head :: (append l1.Tail l2)))
        printfn "3. append (rev (append t l2)) [h]. And the result is: %A" (append (rev (append l1.Tail l2)) [l1.Head])
        printfn "4. append (append (rev l2) (rev t)) [h]. And the result is: %A" (append (append (rev l2) (rev l1.Tail)) [l1.Head])
        printfn "5. append (rev l2) (append (rev t) [h]). And the result is: %A" (append (rev l2) (append (rev l1.Tail) [l1.Head]))
        printfn "6. append (rev l2) (rev (h :: t)). And the result is: %A" (append (rev l2) (rev (l1.Head :: l1.Tail)))
        printfn "Which brings us to: append (rev l2) (rev l1). The result of this expression will be the following: %A" (append (rev l2) (rev l1))
        printfn "Also consider the result of the original expression: %A" (rev (append l1 l2))