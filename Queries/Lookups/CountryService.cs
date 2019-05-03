using Domains;
using UiBuilder;

namespace Queries
{
    public class CountryService : CrudService<CountryVM, Country>
    {
        public CountryService()
        {
            if (Page == null)
            {
                Page = new UiPage<CountryVM>("دولة", "الدول", "CountryConfig");
                Page.Field("Name", "الدولة", x => x?.Name, true);
                Page.Number("Lang", "الاحداثي س", x => x?.Lang, false);
                Page.Number("Late", "الاحداثي ص", x => x?.Late, false);
                Page.Number("ZoomLevel", "الزوم", x => x?.ZoomLevel, false);
                Page.Hidden("Id", x => x?.Id);
                Page.RowButtons.Add(new FormButton<CountryVM>("تعديل", "/CountryConfig/Set").AddParameter("id", x => x?.Id));
                Page.RowButtons.Add(new FormButton<CountryVM>("حذف", "/CountryConfig/Delete").AddParameter("id", x => x?.Id));
            }
            if (FormPage == null) FormPage = Page;
            if (ListPage == null) ListPage = Page;
        }
    }
}
