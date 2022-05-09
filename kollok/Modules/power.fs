module power
    open System

    let input() = 
        let xn = Console.ReadLine().Split()
        [for i in xn -> 
            try
                Convert.ToInt32(i)
            with
                | :? System.Exception -> printfn $"This value is not an integer: {i}"; 0
        ]

    let rec pow x n =
        if n = 0 then 1
        else x * pow x (n - 1)

    let run() = 
        printfn "This module calculates the power of a number.\nEnter an integer and a natural number (including 0) to start."
        let xn = input()
        if xn.Length = 2 && xn[1] >= 0 then Console.WriteLine(pow xn[0] xn[1])
        else Console.WriteLine("There must an integer and a natural number")
