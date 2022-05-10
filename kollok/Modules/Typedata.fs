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

    printf $"Введите значение x: "
    let mutable x = input() //Осуществим ввод переменной с клавиатуры
    x <- x + 1 // Проведем последовательность действий
    x <- x + 1
    x <- x + 1
    x <- x + 1
    printf $"Введите значение a: "
    let mutable a = input()
    let _  = a <- a + 1 in // Проведем последовательность действий
    let _  = a <- a + 1 in
    let _  = a <- a + 1 in
    let _  = a <- a + 1 in
    printf $"Введите значения массива data(без пробелов): "
    let mutable data = [] 
    data <- Input() //Ввод данных с клавиатуры
    let refData = ref data
                
    let run() =
    printf $"{x}\n" // Выведем результат
    printf $"{a}\n" // Выведем результат
    printfn "%A\n" refData // Выведем результат
    
    //let swap(x) =
        //try
            //x <- true
        //with
        //| :? System.Exception -> printfn $"Error in change!"; При попытке присвоения через операцию try with data значений нового типа boolean возникает ошибка типизации данных
    //swap(data)
