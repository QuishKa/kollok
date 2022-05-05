open System
let input = 
    let x = Console.ReadLine().Split()
    [for i in x -> Convert.ToInt32(i)]
let x = example.add input
printfn "%A" x