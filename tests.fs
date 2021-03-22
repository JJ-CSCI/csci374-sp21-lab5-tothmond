//------------------------------
//   DO NOT MODIFY THIS FILE
//------------------------------
module Test

open System
open Expecto
open Expecto.Impl
open Expecto.Logging
open Expecto.Logging.Message
open Assignment

let tests =
  let tree1 = Node(Leaf(2), Leaf(3))
  let tree2 = Leaf(10)
  let tree3 = Node(Node(Leaf(1), Node(Leaf(2), Leaf(3))), Node(Node(Leaf(4), Leaf(5)), Leaf(6)))
  testList "Tests" [
    testCase "t1" (fun () ->
        Expect.equal (prod tree1) 6 "(prod tree1) = 6"
        Expect.equal (prod tree2) 10 "(prod tree2) = 10"
        Expect.equal (prod tree3) 720 "(prod tree3) = 720"
    );
    testCase "t2" (fun () ->
        let res1 = Node(Leaf(3), Leaf(4))
        let res2 = Leaf(5)
        let res3 = Node(Node(Leaf(2), Node(Leaf(4), Leaf(6))), Node(Node(Leaf(8), Leaf(10)), Leaf(12)))
        Expect.equal (map (fun x->x+1) tree1) res1 "map (fun x->x+1) tree1"
        Expect.equal (map (fun x->x/2) tree2) res2 "map (fun x->x+1) tree2"
        Expect.equal (map (fun x->x*2) tree3) res3 "map (fun x->x+1) tree3"
    );
    testCase "t3" (fun () ->
        Expect.equal (foldStr (+) string tree1) "23" "foldStr (fun x-> string x) tree1"
        Expect.equal (foldStr (+) string tree2) "10" "foldStr (fun x-> string x) tree2"
        Expect.equal (foldStr (fun x y ->"{"+x+","+y+"}") (fun x-> "["+(string x)+"]") tree3) "{{[1],{[2],[3]}},{{[4],[5]},[6]}}" "foldStr (fun x-> string x) tree3"
    );
  ]

[<EntryPoint>]
let main args =
  let customFail = { TestPrinters.defaultPrinter with
                        failed = fun n m d ->
                            let lines = m.Split('\n')
                            let res = Array.tryFindIndex (fun (s:string) -> s.Contains("tests.fs")) lines
                            let i = if res.IsNone then 3 else res.Value
                            let newmsg = lines.[0..i] |> Array.fold (fun r s -> r + s + "\n") ""
                            async {
                              do! logger.log LogLevel.Error (
                                    eventX "{testName} failed in {duration}. {message}"
                                    >> setField "testName" n
                                    >> setField "duration" d
                                    >> setField "message" (newmsg.TrimEnd('\n')))
                            }
                    }
  let config = [
    Printer customFail
  ]
  runTestsWithCLIArgs config args tests
