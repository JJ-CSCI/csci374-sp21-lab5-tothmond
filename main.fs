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
    
    |Leaf n -> Leaf (f (n))
    |Node(n1,n2) -> Node(map f n1, map f n2)
    

let rec foldStr (nf:string -> string -> string) (lf:int->string) (t:Tree) :string =
    match t with
    |Leaf n -> (lf (n))
    |Node(n1,n2) -> (nf (foldStr nf lf n1) (foldStr nf lf n2))