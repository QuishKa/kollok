module Geometric_coordinates

open System

    let coordinations x1 y1 x2 y2 x3 y3 x4 y4 x5 y5 =
        if (((x1 - x2) * (y2 - y3)) = ((y1 - y2) * (x2 - x3))) 
        then printfn("Points 1, 2 and 3 lie on a common line")
        else printfn("Points 1, 2 and 3 NOT lie on a common line")

        if (((x1 - x2) * (y3 - y4)) = ((y1 - y2) * (x3 - x4))) 
        then printfn("Lines (1,2) and (3,4) are parallel")
        else printfn("Lines (1,2) and (3,4) NOT are parallel")
      
        if ((((x1 - x2) * (x3 - x4)) + ((y1 - y2) * (y3 - y4))) = 0) 
        then printfn("Lines (1,2) and (3,4) are perpendicular")
        else printfn("Lines (1,2) and (3,4) NOT are perpendicular")

        if (((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) = ((x3 - x4) * (x3 - x4) + (y3 - y4) * (y3 - y4))) 
        then printfn("Lines (1,2) and (3,4) have the same length")
        else printfn("Lines (1,2) and (3,4) NOT have the same length")

        if (((2 * x1) = (x2 + x3)) && ((2 * y1) = (y2 + y3))) 
        then printfn("Point 1 is the midpoint of line (2,3)")
        else printfn("Point 1 is NOT the midpoint of line (2,3)")

        if (((((x1 - x2) * (y2 - y3))) = ((y1 - y2) * (x2 - x3))) && ((((x1 - x4) * (y4 - y5))) = ((y1 - y4) * (x4 - x5)))) 
        then printfn("Lines (2,3) and (4,5) meet at point 1")
        else printfn("Lines (2,3) and (4,5) NOT meet at point 1")
        if ((x1 = x2) && (y1 = y2)) 
        then printfn("Points 1 and 2 are the same")
        else printfn("Points 1 and 2 are NOT the same")


     let input () = 
        let x = Console.ReadLine().Split()
        [for i in x -> Convert.ToInt32(i)]

      let run () =
         printfn("This module outputs geometric properties by coordinates\nEnter five points (x,y) each separated by a space to start")
         let coord = input()
         coordinations coord[0] coord[1] coord[2] coord[3] coord[4] coord[5] coord[6] coord[7] coord[8] coord[9] |> ignore