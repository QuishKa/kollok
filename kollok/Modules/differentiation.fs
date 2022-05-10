module differentiation

type term = //Discriminated unions (Размеченные объединения)
    | Var of string
    | Const of string
    | Fn of string * term list
    

let rec differentiate x tm =
    match tm with // Аналог if-case 
    | Const _ -> Const "0"
    | Var y -> if y = x then Const "1" else Const "0" // Переменная
    | Fn ("-", [f]) -> Fn("-", [differentiate x f]) // Унарное отрицание
    | Fn ("+", [f; g]) -> Fn("+", [differentiate x f; differentiate x g]) // Сумма
    | Fn ("-", [f; g]) -> Fn("-", [differentiate x f; differentiate x g]) // Разность
    | Fn ("*", [f; g]) -> // Произведение
        Fn("+", [
            Fn("*", [differentiate x f; g]);
            Fn("*", [f; differentiate x g])
        ])
    | Fn ("inv", [f]) ->
        chain x f ( // Возведение в степень (-1)
            Fn("-", [
                Fn("inv", [
                    Fn("^", [
                        f; Const "2"
                    ])
                ])
            ])
        )
    | Fn ("^", [f; n]) -> //Возведение в степень
        chain x f (
            Fn ("*", [
                n; Fn("^", [
                    f; Fn("-", [n; Const "1"]) 
                ])
            ])
        )
    | Fn("exp", [f]) -> chain x f tm // Экспонента
    | Fn("ln", [f]) -> chain x f (Fn("inv", [f])) // Логарифмирование
    | Fn("sin", [f]) -> chain x f (Fn("cos", [f])) // Синус
    | Fn("cos", [f]) -> chain x f ( // Косинус
        Fn("-", [Fn("sin", [f])])
        )
    | Fn("/", [f; g]) -> // Частное
        differentiate x (
            Fn("*", [
                f; Fn("inv", [g])
            ])
        )
    | Fn("tg", [f]) -> // Тангенс
        differentiate x (
            Fn("/", [
                Fn("sin", [f])
                Fn("cos", [f])
            ])
            )
    | Fn("ctg", [f]) -> // Котангенс
        differentiate x (
            Fn("inv", [
                Fn("tg", [f])
            ])
        )
    | _ -> Var "Error"
    
        
and chain x g f = // Цепное правило дифференцирования f - производная внешней функции, g - внутренняя
    Fn("*", [differentiate x g; f])
    
let int2string (i : int) = string i
let string2int (s : string) = int s

let simp tm =
    match tm with
    | Fn("+", [Const x; Const y]) ->
        Const(int2string (
            (string2int x) + (string2int y)
        ))
    | Fn("-", [Const x; Const y]) ->
        Const(int2string (
            (string2int x) - (string2int y)
        ))
    | Fn("*", [Const x; Const y]) ->
        Const(int2string (
            (string2int x) * (string2int y)
        ))
    | Fn("/", [Const x; Const y]) ->
        Const(int2string (
            (string2int x) / (string2int y)
        ))
    | Fn("+",[Const "0"; t]) -> t
    | Fn("+",[t; Const "0"]) -> t
    | Fn("-",[t; Const "0"]) -> t
    | Fn("-",[Const "0"; t]) -> Fn("-",[t])
    | Fn("+",[t1; Fn("-",[t2])]) -> Fn("-",[t1; t2])
    | Fn("*",[Const "0"; _]) -> Const "0"
    | Fn("*",[_; Const "0"]) -> Const "0"
    | Fn("*",[Const "1"; t]) -> t
    | Fn("*",[t; Const "1"]) -> t
    | Fn("*",[Fn("-",[t1]); Fn("-",[t2])]) -> Fn("*",[t1; t2])
    | Fn("*",[Fn("-",[t1]); t2]) -> Fn("-",[Fn("*",[t1; t2])])
    | Fn("*",[t1; Fn("-",[t2])]) -> Fn("-",[Fn("*",[t1; t2])])
    | Fn("-",[Fn("-",[t])]) -> t
    | t -> t
    


let rec dsimp tm =
    match tm with
    | Fn(fn, args) -> simp(Fn(fn, List.map dsimp args))
    | t -> simp t
    
     
let rec toStr t =
    match t with
    | Fn(unar, [f]) -> unar + "(" + toStr f + ")"
    | Fn(binar, [f; g]) -> "(" + toStr f + binar + toStr g + ")"
    | Const(c) -> c
    | Var(v) -> v
    | _ -> "Err"
    
let derive (x: string) (f:term) =
    toStr (dsimp (differentiate x f))
  
let run() =
    printfn "Open this module in F# Interactive"
  