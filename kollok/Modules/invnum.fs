module inverse_number
    open System
    let log2 =
        let rec log2 (x:float) y =
            if x < 1.0 then y
            else log2 (x/2.0) (y + 1.0) in
            fun x -> log2 (x-1.0) 0.0

    let msd = 
        let rec msd n x = 
            let a = floor(x * 10.0**n) in
            let b = a/(10.0**n) in
            if abs(b) > 1.0 then n
            else msd (n+1.0) x
        msd 0.0

    let real_inv (x:float) (n:float) = 
        let x0 = floor(x) in
        let k = 
            if x0 > 1.0 then
                let r:float = (log2 x0) - 1.0 in
                let k0:float = n + 1.0 - 2.0 * r in
                if k0 < 0.0 then 0.0
                else k0
            else
                let p:float = msd x in
                n + 2.0 * p + 1.0 in
        let c:float = floor(x * 10.0**k)

        (2.0**(n+k)) / (c/10.0**k)
        
    let run =
        printfn "Enter a number the inverse version of which you want to calculate"
        let a = Convert.ToDouble(Console.ReadLine())
        printfn "Enter the precision"
        let b = Convert.ToDouble(Console.ReadLine())
        Console.WriteLine(real_inv a b)
        0