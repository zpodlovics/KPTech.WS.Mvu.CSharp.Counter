// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

using System;
using WebSharper;
using WebSharper.UI;
using WebSharper.UI.Client;
using KPTech.WS.Mvu.FSharp.Extensions;
using static WebSharper.UI.Client.Html;
using Console = WebSharper.JavaScript.Console;
using Doc = WebSharper.UI.Doc;

namespace KPTech.WS.Mvu.CSharp.Increment.App
{
    
    [JavaScript]
    public class Program
    {        
        public static Model InitModel() {
            return new Model(0);
        }
        
        public static Model Update(Msg msg, Model model)
        {
            Console.Log("Update:" + msg.Id);
            switch (msg.Id)
            {
                case 1:
                    return new Model(model.Counter+1);
                case 2:
                    return new Model(model.Counter-1);
                default:
                    return model;
            }
        }

        public static Func<Msg, Model, Model> UpdateFunc = Update;

        public static Doc Render(Action<Msg> dispatch,
            View<Model> view)
        {
            var doc = div(
                button("Increment",() => dispatch(new Increment()),null),
                span(text("Value: " + view.V.Counter)),
                button("Decrement",() => dispatch(new Decrement()),null)
            );

            return doc;
        }

        public static Func<Action<Msg>, View<Model>, Doc> renderFunc = Render;
        
        [SPAEntryPoint]
        public static void ClientMain()
        {
            Model initialModel = InitModel();
            var updateF = FSharpConvert.Fun(UpdateFunc);
            var renderF = renderFunc.FromRenderFunc();
            //var renderF = RenderExtension.FromRenderFunc(renderFunc);

            var remoteDevOptions = new RemoteDev.Options()
            {
                hostname = "localhost",
                port = 8000
            };
            var app = WebSharper.Mvu.App.CreateSimple(initialModel, updateF, renderF);
            app = WebSharper.Mvu.App.WithRemoteDev(remoteDevOptions, app);
            Doc doc = WebSharper.Mvu.App.Run(app); 
            doc.RunById("main");
        }
    }
}
