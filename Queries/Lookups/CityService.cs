using Domains;
using UiBuilder;

namespace Queries
{
    public class CityService : CrudService<CityVM,City>
    {
        public CityService()
        {
            if (Page == null)
            {
                Page = new UiPage<CityVM>("مدينة", "المدن", "CityConfig");
                Page.Field("Name", "المدينة", x => x?.Name, true);
                Page.LookupSelect("CountryID", "الدولة", x => x?.CountryID, LookupType.Country, null, true);
                Page.Number("Lang", "الاحداثي س", x => x?.Lang, false);
                Page.Number("Late", "الاحداثي ص", x => x?.Late, false);
                Page.Number("ZoomLevel", "الزوم", x => x?.ZoomLevel, false);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<CityVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<CityVM>(Page);
                ListPage.RowButtons.Add(new FormButton<CityVM>("تعديل", "/CityConfig/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<CityVM>("حذف", "/CityConfig/Delete").AddParameter("id", x => x?.Id));
            }
        }
    }
}
