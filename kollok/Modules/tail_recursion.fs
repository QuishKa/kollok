module tail_recursion
    open System

    
    let rec tfact x n =
        if n = 0 then x
        else tfact (x * n) (n-1)

    let fact n = tfact 1 n


    let input = 
        let xy = Console.ReadLine().Split()
        [for i in xy -> 
            try
                Convert.ToInt32(i)
            with
                | :? System.Exception -> printfn $"This value is not an integer: {i}"; 0
        ]

    let run() =
        printf "\nThis module is designed to calculate the factorial of a number using tail recursion\n"
        prinf "\nEnter a single integer\n"
        let n = input
        if n.Length = 1 then Console.WriteLine(fact n)
        else printf "\nA single integer must be supplied to the input\n"