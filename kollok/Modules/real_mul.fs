module real_mul
    open System

    let input() = 
        let xn = Console.ReadLine().Split()
        [for i in 0 .. (xn.Length-1) -> 
            let v = xn[i] in
            try
                if i<2 then Convert.ToDouble(v)
                else Convert.ToInt32(v)
            with
                | :? System.Exception -> printfn $"This incorrect value : {v}"; 0
        ]

    
    let log2 =
        let rec log2 (x:float) y =
            if x < 1.0 then y
            else log2 (x/2.0) (y + 1.0) in
            fun x -> log2 (x-1.0) 0.0

    let fl x n =
        2.0**n * x

    let mul x y n =
        let n2 = n + 2.0 in

        let r = n2 / 2.0 in
        let s = n2 - r in
        let xr = fl x r in
        let ys = fl y s in
        let p = log2 xr in
        let q = log2 ys in
        if p = 0 && q = 0 then 
            0.0 
        else 
            let k = q + r + 1.0 in
            let l = p + s + 1.0 in
            let m = p + q + 4.0 in
            System.Math.Round ( (fl x k) * (fl y l) / 2.0**m ,0) / 2.0**n


    let run() = 
        printfn "This module multiplies two real numbers (with precision 1/2^n).\nEnter an two real number and \"n\" to start."
        let xn = input() 
        if xn.Length = 3 then Console.WriteLine(mul xn[0] xn[1] xn[2])
        else Console.WriteLine("Incorrect input")