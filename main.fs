module Assignment

type Tree =
    | Node of Tree * Tree
    | Leaf of int

let rec prod (t:Tree) :int =
    match t with
    
    |Leaf n -> n
    |Node(n1,n2) -> prod(n1) * prod(n2)

let rec map (f:int->int) (t:Tree) :Tree =
    match t with
    
    |Leaf n -> map f (t)
    |Node(n1,n2) -> f n2; map f (n1)
    

let rec foldStr (nf:string -> string -> string) (lf:int->string) (t:Tree) :string =
    ""
