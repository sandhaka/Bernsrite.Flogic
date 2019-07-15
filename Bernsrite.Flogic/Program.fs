﻿namespace Bernsrite.Flogic

open System

module Program =

    [<EntryPoint>]
    let main _ =

        (*
        Assume:
            =(+(0,a), a)
        Then:
            +(0, s(a))
            = s(+(0,a))    [by a + s(b) = s(a + b)]
            = s(a)         [by assumption]
        *)

        let proofOpt =
            // "∀x.=(+(0,x), x)"
            // "=(+(0,0), 0)"
            "(=(+(0,a), a) -> =(+(0,s(a)), s(a)))"
            // "(=(+(0,a), a) -> =(s(+(0,a)), s(a)))"
                |> Language.parse Peano.language
                |> LinearResolution.tryProve Peano.language Peano.axioms
        printfn "%A" proofOpt

        0
