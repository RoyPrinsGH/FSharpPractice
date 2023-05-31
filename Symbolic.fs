module Symbolic

type Expr =
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr
    | Pow of Expr * Expr
    | Const of int
    | Var of string

let rec simplify ex: Expr =
    match ex with
    | Add (Const c1, Const c2) -> simplify <| Const(int(c1) + int(c2))
    | Add (e1, Const(0)) -> simplify <| e1
    | Add (Const(0), e1) -> simplify <| e1
    | Add (e1, e2) when e1 <> simplify(e1) -> simplify <| Add(simplify(e1), e2)
    | Add (e1, e2) when e2 <> simplify(e2) -> simplify <| Add(e1, simplify(e2))
    | Add (e1, Add (e2, e3)) -> simplify <| Add(Add(e1, e2), e3)
    | Add (Add (e1, e2), e3) -> simplify <| Add(Add(e1, e3), e2)
    | _ -> ex

let start() =
    let expr = Add(Const(3), Add(Var("x"), Const(-3)))
    printfn "%A" (simplify expr)