using Domains;
using UiBuilder;

namespace Queries
{
    public class IndustrialCityService : CrudService<IndustrialCityVM, IndustrialCity>
    {
        public IndustrialCityService()
        {
            if (Page == null)
            {
                Page = new UiPage<IndustrialCityVM>("مدينة صناعية", "المدن الصناعية" , "IndustrialCityConfig");
                Page.Field("Name", "المدينة الصناعية", x => x?.Name, true);
                Page.LookupParantSelect("Country_Id", "الدولة", x => x?.City_Id, LookupType.City, 0, true);
                Page.LookupSelect("City_Id", "المدينة", x => x?.City_Id, LookupType.City, null, true, null, "Country_Id");
                Page.Number("Lang", "الاحداثي س", x => x?.Lang, false);
                Page.Number("Late", "الاحداثي ص", x => x?.Late, false);
                Page.Number("ZoomLevel", "الزوم", x => x?.ZoomLevel, false);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<IndustrialCityVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<IndustrialCityVM>(Page);
                ListPage.RowButtons.Add(new FormButton<IndustrialCityVM>("تعديل", "/IndustrialCityConfig/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<IndustrialCityVM>("حذف", "/IndustrialCityConfig/Delete").AddParameter("id", x => x?.Id));
            }
        }
    }
}
