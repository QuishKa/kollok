module Berezkin   (*Программа проводит работу с последовательностью вычислений двумя различными способами
                    Также рассматриваются и поясняются особенности работы с ссылочными ячейками в f#*)
    open System

    let Input() = 
            let y = Console.ReadLine().Split()
            [for i in y -> 
                try
                    Convert.ToInt32(i)
                with
                    | :? System.Exception -> printfn $"Skipped value \"{i}\", not a number"; 0]

    let rec input() = 
            try 
                Convert.ToInt32(Console.ReadLine())
            with
                | :? System.Exception -> printfn "Enter a number."; input()
                
    let run() =
        printf $"Enter number x: "
        let mutable x = input() //Осуществим ввод переменной с клавиатуры
        x <- x + 1 // Проведем последовательность действий
        x <- x + 1
        x <- x + 1
        x <- x + 1
        printf $"Enter number a: "
        let mutable a = input()
        let _  = a <- a + 1 in // Проведем последовательность действий
        let _  = a <- a + 1 in
        let _  = a <- a + 1 in
        let _  = a <- a + 1 in
        printf $"Enter array data: "
        let mutable data = [] 
        data <- Input() //Ввод данных с клавиатуры
        match List.tryFindIndex(fun x -> x = 0) data with
            | Some index -> data <- List.removeAt index data
            | None -> None |> ignore
        let refData = ref data
        printf $"{x}\n" // Выведем результат
        printf $"{a}\n" // Выведем результат
        printfn "%A\n" refData // Выведем результат
    
    //let swap(x) =
        //try
            //x <- true
        //with
        //| :? System.Exception -> printfn $"Error in change!"; При попытке присвоения через операцию try with data значений нового типа boolean возникает ошибка типизации данных
    //swap(data)
