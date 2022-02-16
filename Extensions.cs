using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Risk_Assessment.Classes
{
    public static class Extensions
    {
        //https://stackoverflow.com/questions/6612938/razor-view-with-anonymous-type-model-class-it-is-possible

        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var item in anonymousDictionary)
            {
                expando.Add(item);
            }

            return (ExpandoObject)expando;
        }

        public static IList<ExpandoObject> ToExpandoList(this object anonymousObject)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();

            if (anonymousObject != null)
            {
                foreach (var o in ((IEnumerable<object>)anonymousObject))
                {
                    result.Add(o.ToExpando());
                }
            }

            return result;
        }
    }
}