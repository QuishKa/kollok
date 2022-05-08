module gcd
    open System
    
    let input = 
        let xy = Console.ReadLine().Split()
        [for i in xy -> 
            try
                Convert.ToInt32(i)
            with
                | :? System.Exception -> printfn $"This value is not an integer: {i}"; 0
        ]
    
    let rec gcd x y = 
        if y = 0 then x
        else gcd y (x % y)
    
    let run = 
        let xy = input
        if xy.Length = 2 then Console.WriteLine(gcd xy[0] xy[1])
        else Console.WriteLine("There must be two integers")
