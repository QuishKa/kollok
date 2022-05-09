module tail_recursion
    open System

    
    let rec tfact x n =
        if n = 0 then x
        else tfact (x * n) (n-1)

    let fact n = tfact 1 n


    let rec input() = 
            try 
                Convert.ToInt32(Console.ReadLine())
            with
                | :? System.Exception -> printfn "Enter a number."; input()

    let run() =
        printf "\nThis module is designed to calculate the factorial of a number using tail recursion\n"
        printf "\nEnter a single integer\n"
        let n = input()
        Console.WriteLine(fact n)