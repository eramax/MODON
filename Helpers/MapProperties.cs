using System.Linq;
using System.Reflection;

namespace Helpers
{
    public static class MapProperties
    {
        public static TSeconType Map<TFirstType, TSeconType>(TFirstType SourceObject, TSeconType DesitnationObject)
        {
            DesitnationObject.GetType().GetProperties().ToList()
                .ForEach(delegate (PropertyInfo x)
                {
                    if (SourceObject.GetType().GetProperties().Any((PropertyInfo a) => a.Name == x.Name))
                    {
                        x.SetValue(DesitnationObject, (from a in SourceObject.GetType().GetProperties()
                                                       where a.Name == x.Name
                                                       select a).FirstOrDefault().GetValue(SourceObject));
                    }
                });
            return DesitnationObject;
        }
    }
}
