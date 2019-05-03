using System;
using System.Collections.Generic;
using System.Linq;

namespace UiBuilder
{
    public class FormButton<TEnt> where TEnt : class
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public Func<TEnt, bool> Condition { get; set; }
        public Dictionary<string, Func<TEnt, object>> Parameters { get; set; }

        public FormButton(string name, string action, Func<TEnt, bool> condition = null)
        {
            Name = name;
            Action = action;
            Condition = condition;
        }
        public FormButton<TEnt> AddParameter(string name, Func<TEnt, object> func)
        {
            if (Parameters == null) Parameters = new Dictionary<string, Func<TEnt, object>>();
            if (Parameters.ContainsKey(name)) Parameters.Remove(name);
            Parameters.Add(name, func);
            return this;
        }
        public string Url(TEnt entity)
        {
            var url = this.Action + "?";
            url = Parameters.Data().Aggregate(url, (current, pr) => current + $"{pr.Key}={pr.Value(entity)}&");
            return url.TrimEnd('&');
        }
    }
}
