module Assignment

type Tree =
    | Node of Tree * Tree
    | Leaf of int

let rec prod (t:Tree) :int =
    0

let rec map (f:int->int) (t:Tree) :Tree =
    t

let rec foldStr (nf:string -> string -> string) (lf:int->string) (t:Tree) :string =
    ""
