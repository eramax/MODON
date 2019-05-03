using System.Collections.Generic;

namespace Domains
{
    public class Lookup : List<SelectItem>
    {
        public LookupType? Parant { get; set; }
        public Lookup() { }
        public Lookup(List<SelectItem> lst) { lst.ForEach(x => { x.Selected = false; Add(x); }); }
        public Lookup(List<SelectItem> lst, LookupType type) { lst.ForEach(x => { x.Selected = false; Add(x); }); Parant = type; }
    }
}
