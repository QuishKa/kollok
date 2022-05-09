module exn
    exception Failed of string
    exception Died
    exception DbZ
    exception Head_of_empty

    let DbZ x y: string =
        if (y = 0) then raise (DbZ)
        else string (x/y)

    let divide x y : string = 
        try DbZ x y with DbZ -> "Attempted to divide by zero."

    let hd(list: 'a list) : 'a = 
        if list.IsEmpty then raise(Head_of_empty)
        else list.Head

    let headstring (sl: string list) : string =
        try hd sl with Head_of_empty -> ""

    let run() = 
        printfn "%s" "This module illustrates how exceptions work.\n\n"

        let x, y, z = (10, 0, 2)
        let myArray = [| "hi"; "there"|]
        let list = myArray |> Array.toList
        let concatenatedLine = list |> String.concat " "
        let elist = []

        printfn "%s %d %s %d %s %s" "'1' - Exception 'Division by zero':\n\nResult with divisor not equal to zero ( x/z, where x =" x ", z =" z "): " (divide x z)
        printfn "%s %d %s %d %s %s %s" "Result of division by zero ( x/y, where x =" x ", y =" y "):" (divide x y) "\n"
        printfn "%s" "'2' - Exception 'Died' define\n"
        try raise (Died) with | Died -> printfn "%s" "Exception 'Died' is defined.\n"
        printfn "%s" "'3' - Using the 'raise' constructor\n"
        try raise (Failed "I don’t know why.") with | Failed(str) -> printfn "Ex Failed: %s\n" str
        printfn "%s%s%s %s" "'4' - An element from an empty list\n\nHead from '" concatenatedLine "':" (headstring list)
        printfn "%s %s" "Head from NULL list: "(headstring elist)