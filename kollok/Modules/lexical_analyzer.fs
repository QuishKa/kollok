module lexical_analyzer
    open System
    let is_alpha c = Char.IsLetter(c) || c='_' || c = '\''
    let is_digit c = Char.IsDigit(c)
    let is_space c = (c=' ')
    let is_other c = not(is_alpha c || is_digit c || is_space c)

    let get_char_type c =
        if is_alpha c then 1
        elif is_digit c then 2
        else 0

    let get_classification (str:string) = 
        if is_alpha str.[0] then "Name"
        elif is_digit str.[0] then "Num"
        else "Other"

    let add_elem_to_list (e:string) lst = 
        if e.Length = 0 then lst
        else lst @ [(get_classification e, e)]

    let rec analyse (input:string) (current_part:string) (result:(string*string) list) (typ:int) = 
        if input.Length = 0 then
            (add_elem_to_list current_part result)
        else 
            let c = input.[0]
            if c = ' ' then
                (analyse input.[1..input.Length] "" (add_elem_to_list current_part result) 0)
            elif is_other c then
                (analyse input.[1..input.Length] "" (add_elem_to_list (c.ToString()) (add_elem_to_list current_part result)) 0)
            elif is_digit c && typ <> 0 || is_alpha c && typ = 1 then
                (analyse input.[1..input.Length] (current_part+c.ToString()) result typ)
            else
                (analyse input.[1..input.Length] (c.ToString()) (add_elem_to_list current_part result) (get_char_type c))

    let run = 
        Console.Write("Enter the string: ")
        let a = Console.ReadLine();
        let result = analyse a "" [] 0
        printfn "Tokens list: %A" result