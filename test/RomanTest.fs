module RomanTest

open Expecto

module R = Roman

[<Tests>]
let tests =
    testList "Roman" [

        testList "Additive notation" [
            testCase "One letter" <| fun _ ->
                Expect.equal "I" (R.additiveNotation 1 "I") "Replicate letter once"
            testCase "Two letters" <| fun _ ->
                Expect.equal "II" (R.additiveNotation 2 "I") "Replicate letter twice"
            testCase "Three letters" <| fun _ ->
                Expect.equal "III" (R.additiveNotation 3 "I") "Replicate letter three times"
        ]

        testList "Decimal number to roman" [
        testCase "Number 0" <| fun _ ->
            Expect.equal None (R.fromDecimal 0) "No conversion from decimal 0 to roman"
        testCase "Roman overflow" <| fun _ ->
            Expect.equal None (R.fromDecimal 4000) "No conversion for such a big number: 4000"
            Expect.equal None (R.fromDecimal 59999) "No conversion for such a big number: 59999"
        testCase "Number 1" <| fun _ ->
            Expect.equal (Some "I") (R.fromDecimal 1) "Conversion from 1 to I"
        testCase "Number 2" <| fun _ ->
            Expect.equal (Some "II") (R.fromDecimal 2) "Conversion from 2 to II"
        testCase "Number 3" <| fun _ ->
            Expect.equal (Some "III") (R.fromDecimal 3) "Conversion from 3 to III"
        testCase "Number 4" <| fun _ ->
            Expect.equal (Some "IV") (R.fromDecimal 4) "Conversion from 4 to IV"
        testCase "Number 5" <| fun _ ->
            Expect.equal (Some "V") (R.fromDecimal 5) "Conversion from 5 to V"
        testCase "Number 6" <| fun _ ->
            Expect.equal (Some "VI") (R.fromDecimal 6) "Conversion from 6 to VI"
        testCase "Number 7" <| fun _ ->
            Expect.equal (Some "VII") (R.fromDecimal 7) "Conversion from 7 to VII"
        testCase "Number 8" <| fun _ ->
            Expect.equal (Some "VIII") (R.fromDecimal 8) "Conversion from 8 to VIII"
        testCase "Number 9" <| fun _ ->
            Expect.equal (Some "IX") (R.fromDecimal 9) "Conversion from 9 to IX"
        testCase "Number 10" <| fun _ ->
            Expect.equal (Some "X") (R.fromDecimal 10) "Conversion from 10 to X"
        testCase "Number 41" <| fun _ ->
            Expect.equal (Some "XLI") (R.fromDecimal 41) "Conversion from 41 to XLI"
        testCase "Number 78" <| fun _ ->
            Expect.equal (Some "LXXVIII") (R.fromDecimal 78) "Conversion from 78 to LXXVIII"
        testCase "Number 901" <| fun _ ->
            Expect.equal (Some "CMI") (R.fromDecimal 901) "Conversion from 901 to CMI"
        testCase "Number 999" <| fun _ ->
            Expect.equal (Some "CMXCIX") (R.fromDecimal 999) "Conversion from 999 to CMXCIX"
        testCase "Number 1000" <| fun _ ->
            Expect.equal (Some "M") (R.fromDecimal 1000) "Conversion from 1000 to M"
        testCase "Number 3999" <| fun _ ->
            Expect.equal (Some "MMMCMXCIX") (R.fromDecimal 3999) "Conversion from 3999 to MMMCMXCIX"
    ]
    ]