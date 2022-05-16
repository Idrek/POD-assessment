module Roman

type Math = System.Math
type String = System.String

let additiveNotation (times: int) (letter: string) : string =
    String.replicate times letter

let fromDecimal (number: int) : Option<string> =
    let romanLetters : array<int * string> = [|
        (1000, "M")
        (900, "CM")
        (500, "D")
        (400, "CD")
        (100, "C")
        (90, "XC")
        (50, "L")
        (40, "XL")
        (10, "X")
        (9, "IX")
        (5, "V")
        (4, "IV")
        (1, "I")
    |]
    match number with
    | 0 -> None
    // https://www.romannumerals.org/blog/which-is-the-biggest-number-in-roman-numerals-6
    | n when n >= 4000 -> None
    | n ->
        (*
            Traverse `romanLetters` from highest to lowest value and substract from the
            remainder value of `n` until equals zero.
        *)
        ((List.empty, n), romanLetters) ||> Array.fold (fun (state, n) (value, letter)  ->
            match n with
            | 0 -> (state, n)
            | n -> 
                let (quotient: int, remainder: int) = Math.DivRem(n, value)
                match quotient, remainder with
                | 0, r -> (state, n)
                | q, 0 -> (additiveNotation q letter :: state, 0)
                | q, r -> (additiveNotation q letter :: state, r)
        ) |> fst |> List.rev |> String.Concat |> Some
