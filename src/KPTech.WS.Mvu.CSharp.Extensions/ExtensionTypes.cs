// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

/*
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.FSharp.Core;
using WebSharper;
using WebSharper.UI;

namespace KPTech.WS.Mvu.CSharp.Extensions
{
    [Serializable]
    [Sealed]
    [JavaScript]
    internal static class ExtensionTypes
    {
        [Serializable]
        private sealed class DispatchF<TMessage>
        {
            private readonly FSharpFunc<TMessage, Unit> _f;

            public DispatchF (FSharpFunc<TMessage, Unit> f)
            {
                _f = f;
            }

            internal void Invoke (TMessage msg)
            {
                _f.Invoke (msg);
            }
        }

        [Serializable]
        internal sealed class RenderF<TMessage, TModel, TRendered>: Microsoft.FSharp.Core.OptimizedClosures.FSharpFunc<FSharpFunc<TMessage,Unit>,View<TModel>,TRendered>
        {
            private readonly Func<Action<TMessage>, View<TModel>, TRendered> _func;

            [CompilerGenerated]
            [DebuggerNonUserCode]
            internal RenderF (Func<Action<TMessage>, View<TModel>, TRendered> func)
            {
                _func = func;
            }

            public override TRendered Invoke (FSharpFunc<TMessage, Unit> d, View<TModel> v)
            {
                Action<TMessage> action = new DispatchF<TMessage> (d).Invoke;
                return _func.Invoke (action, v);
            }
        }
}
}

*/