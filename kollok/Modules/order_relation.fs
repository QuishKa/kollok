module order_relation
    open System

    let run() =
        printf "Enter the first number:"
        let input1 = Console.ReadLine()
        printf "Enter the second number:"
        let input2 = Console.ReadLine()   

        let mutable x1 = 1
        let mutable i = 0
        let mutable y1 = 1

        while (Char.IsDigit(input2[i]) && i<>input2.Length-1) do
            y1<-y1+1
            i<-i+1
            printf ""

        i<-0

        while (Char.IsDigit(input1[i]) && i<>input1.Length-1) do
            x1 <- x1+1
            i<-i+1
            printf ""

        let separate =
            let rec separate (n:int) (x:string) (y:string) =
                let d = (int)x[n] - (int)y[n]
                if (abs(d) >= 1 || n=x.Length-1 || n=y.Length-1) then d
                else separate (n + 1) x y
            separate 0

        if x1=y1 then do
            let real_gt x y = separate x y > 0
            let real_e x y = separate x y = 0
            let real_lt x y = separate x y < 0


            let res1 = real_gt input1 input2
            let res2 = real_e input1 input2
            let res3 = real_lt input1 input2

            if res1 then printfn $"{input1} > {input2}"
            elif res2 then printfn $"{input1} = {input2}"
            else printfn $"{input1} < {input2}"
        elif x1<y1 then printfn $"{input1} < {input2}"
        else printfn $"{input1} > {input2}"
