using System;
using WebSharper;
using WebSharper.UI;
using Console = WebSharper.JavaScript.Console;
using Doc = WebSharper.UI.Doc;
using Html = WebSharper.UI.Client.Html;

namespace KPTech.WS.Mvu.CSharp.Counter
{
    [JavaScript]
    public static class Counter
    {
        public static Model Init()
        {
            return new Model(0);
        }

        public static Model Update(Msg msg, Model model)
        {
            Console.Log("Update:" + msg.Id);
            switch (msg.Id)
            {
                case 1:
                    return new Model(model.Counter + 1);
                case 2:
                    return new Model(model.Counter - 1);
                default:
                    return model;
            }
        }

        public static Func<Msg, Model, Model> UpdateFunc = Update;

        public static Doc Render(Action<Msg> dispatch,
            View<Model> view)
        {
            var doc = Html.div(
                Html.button("Increment", () => dispatch(new Increment()), null), 
                Html.span(Html.text("Value: " + view.V.Counter)), 
                Html.button("Decrement", () => dispatch(new Decrement()), null)
            );

            return doc;
        }

        public static Func<Action<Msg>, View<Model>, Doc> RenderFunc = Render;
    }
}