// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

namespace KPTech.WS.Mvu.FSharp.Extensions

open System.Runtime.CompilerServices

open WebSharper
open WebSharper.UI
open WebSharper.Mvu

[<Extension; Sealed; JavaScript>]
type RenderExtension =
            
    [<Extension; Inline>]
    static member FromRenderFunc(func: System.Func<System.Action<'Message>,View<'Model>,'Rendered>) : Dispatch<'Message> -> View<'Model> -> 'Rendered = 
        let f (d: Dispatch<'Message>) (v: View<'Model>) : 'Rendered =
            let dispatchAction : System.Action<'Message> = System.Action<'Message>(fun msg -> d msg)
            func.Invoke(dispatchAction, v)
        f