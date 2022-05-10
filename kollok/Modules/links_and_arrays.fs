module links_and_arrays

  let input() = 
    System.Convert.ToInt32(System.Console.ReadLine());

  let run() = 
    let x  = ref 6;
    System.Console.WriteLine(  "Enter the integer number: ");
    x := input();
    printfn "The current value of the variable: %A" !x;
    System.Console.WriteLine(  "Enter the integer you are going to change the value to: ");
    x := input();
    printfn "The current value of the variable: %A" !x;
    x := !x + !x;
    printfn "The current value of the variable (*2): %A" !x;
    printfn "The current value of the variable without dereference: %A" x;

    let array = [| for i in 1 .. 5 -> 0 |];
    printfn "Array: %A" array;
    printfn "The value of the element at index 1: %d" (Array.get array 1);
    Array.set array 1 10;
    printfn "Replacing element at index 1 with 10: %A" array;
    printfn "The value of the element at index 1: %d " (Array.get array 1);
    printfn "Press any key..."