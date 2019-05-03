using Domains;
using UiBuilder;

namespace Queries
{
    public class FacilitiesGroupService : CrudService<FacilitiesGroupVM, FacilitiesGroup>
    {
        public FacilitiesGroupService()
        {
            if (Page == null)
            {
                Page = new UiPage<FacilitiesGroupVM>("مجمع", "المجمعات", "FacilitiesGroupConfig");
                Page.Field("Name", "اسم المجمع", x => x?.Name, true);
                //AddFilter(vm.Country_Id, x => x.IndustrialCity.City.CountryID == vm.Country_Id);
                //AddFilter(vm.City_Id, x => x.IndustrialCity.City_Id == vm.City_Id);
                //AddFilter(vm.IndustrialCity_Id, x => x.IndustrialCity_Id == vm.IndustrialCity_Id);
                //AddFilter(vm.Name, x => x.Name == vm.Name);
                //AddFilter(vm.Lang, x => x.Lang == vm.Lang);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<FacilitiesGroupVM>(Page);
                FormPage.LookupParantSelect("Country_Id", "الدولة", x => x.IndustrialCity_Id, LookupType.IndustrialCity, 1, true);
                FormPage.LookupParantSelect("City_Id", "المدينة", x=> x.IndustrialCity_Id, LookupType.IndustrialCity,0, true, null, "Country_Id");
                FormPage.LookupSelect("IndustrialCity_Id", "المدينة الصناعية", x => x?.IndustrialCity_Id, LookupType.IndustrialCity,null, true,null, "City_Id");
                FormPage.Number("Lang", "الاحداثي س", x => x?.Lang, false);
                FormPage.Number("Late", "الاحداثي ص", x => x?.Late, false);
                FormPage.Number("ZoomLevel", "الزوم", x => x?.ZoomLevel, false);
                FormPage.Hidden("Id", x => x?.Id);
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<FacilitiesGroupVM>(Page);
                ListPage.Number("Lang", "الاحداثي س", x => x?.Lang);
                ListPage.Number("Late", "الاحداثي ص", x => x?.Late);
                ListPage.Number("ZoomLevel", "الزوم", x => x?.ZoomLevel);
                ListPage.RowButtons.Add(new FormButton<FacilitiesGroupVM>("تعديل", "/FacilitiesGroupConfig/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<FacilitiesGroupVM>("حذف", "/FacilitiesGroupConfig/Delete").AddParameter("id", x => x?.Id));
            }
        }
    }
}
