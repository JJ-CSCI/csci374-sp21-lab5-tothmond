# Lab 5

## Problems

In this lab, you will write functions that contain pattern matching expressions.

**!!! DO NOT USE LOOPS, MUTABLE VARIABLES, OR ANY LIBRARY FUNCTIONS. ONLY RECURSION AND PATTERN MATCHING IS ALLOWED !!!**


Let's define an integer union type called `BinaryTree` that has two constructors:

- `Leaf` :: `int -> Tree`
- `Node` :: `Tree * Tree -> Tree`

Trees of this type will contain a single piece of data of type `int` at each leaf.

```fsharp
type Tree =
    | Node of Tree * Tree
    | Leaf of int
```

Test your type:

```fsharp
> let tree = Node(Node(Leaf(1), Node(Leaf(2), Leaf(3))), Node(Node(Leaf(4), Leaf(5)), Leaf(6)));;
val tree : Tree =
  Node
    (Node (Leaf 1, Node (Leaf 2, Leaf 3)),
     Node (Node (Leaf 4, Leaf 5), Leaf 6))
```

### Problem 1

Write a recursive function `prod: Tree -> int` that returns a product of the elements stored in the leafs of a tree object.

### Problem 2

Define a function `map :: (int -> int) -> Tree> -> Tree` that operates on trees the same way that `List.map` operates on lists. In other words, `map` should take a function and apply it to every integer value stored in a leaf within a `Tree` object.

## Problem 3

Define a function `foldStr :: (string -> string -> string) -> (int -> string) -> Tree -> string` that operates on trees similarly to `List.fold` operates on lists. In other words, the function `int-> string` should replace a value at the `Leaf` of the tree, and the function of type `string -> string -> string` should replace the `Node` constructor in the tree.

## Test

Press **Run** button to execute and test your program.

- Or run `make test` command in the command line to verify the correctness of your program.

## Submission

- Commit & push all changes that to the corresponding assignment repository on GitHub, using the **Repl.it** interface - **Version control** tab.
  - Make sure that you committed changes to following files:
    - `main.fs`
- Submit the link of the assignment GitHub repository in the corresponding assignment submission the Blackboard.
  - Open corresponding assignment on the Blackboard
  - In **Assignment Submission** section, press **Write Submission** button
  - Paste your assignment repository link in the **Text Submission** box
  - Submit the assignment

### Before You Submit

You are required to test that your submission works properly before submission. Make sure that your program compiles without errors. Once you have verified that the submission is correct, you can submit your work.

### Coding Style

In any programming project, matching the existing coding style is important. Having different coding styles intermixed leads to confusion and bugs. Students are required to follow the particular existing coding style that maintains the indentation style in `.fs` and `.fsx` files using spaces, not tabs.

- *Indentation*: The indentation style for your work have to be 4 spaces. Many students are taught to use tabs for indentation, which can make code very hard to read, especially when there are several levels of indentation.

For additional information, see [F# style guide](https://docs.microsoft.com/en-us/dotnet/fsharp/style-guide/) or [A comprehensive guide to F# Formatting Conventions](https://github.com/fsprojects/fantomas/blob/master/docs/FormattingConventions.md)
