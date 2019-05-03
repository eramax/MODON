using Domains;
using System;

namespace UiBuilder
{
    public class UiParameter<T> where T : class
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public Func<T, object> Value { get; set; }
        public string UiType { get; set; }
        public Func<T, bool> Condition { get; set; }
        public Func<T, bool> Validation { get; set; }
        public bool ListOk { get; set; } = true;
        public bool FormOk { get; set; } = true;
        public bool FilterOk { get; set; } = true;
        public bool Required { get; set; }
        public string ChainedTo { get; set; }
        public int Width { get; set; }
        public int? PanelId { get; set; }
        public LookupType? LookupType { get; set; }
        public int? ParantLevel { get; set; }
    }
}
