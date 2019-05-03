using Domains;
using System.Collections.Generic;
using System;
using UiBuilder;

namespace Queries
{
    public class FacilityOrderService : CrudService<AddFacilityOrderVM, AddFacilityOrder>
    {
        public FacilityOrderService()
        {
            if (Page == null)
            {
                Page = new UiPage<AddFacilityOrderVM>("طلب موافقة مبدائية لانشاء منشأة ", "طلبات الموافقة المبدائية", "FacilityOrder");
                Page.Panels = new List<string>(new string[] { "بيانات المنشأة", "بيانات النشاط السابق", "بيانات النشاط", "بيانات موقع المنشأة", "بيانات الاحداثيات والعنوان", "قائمة المبيعات", "قائمة المرفقات المطلوبة" });
                Page.Field("Name", "أسم المنشأة", x => x?.Facility?.Name, true, null, 12);
                Page.LookupSelect("IndustrialCity_Id", "المدينة الصناعية", x => x?.Facility?.IndustrialCity_Id, LookupType.IndustrialCity, null, true, 3, "City_Id");
                Include(x => x.Facility, x => x.Facility.Client, x => x.Facility.SubActivities);
                //AddFilter(vm.Address, x => x.Facility.Address == vm.Address);
                //AddFilter(vm.Name, x => x.Facility.Name == vm.Name);
                //AddFilter(vm.Lang, x => x.Facility.Lang == vm.Lang);
                //AddFilter(vm.Country_Id, x => x.Facility.IndustrialCity.City.CountryID == vm.Country_Id);
                //AddFilter(vm.City_Id, x => x.Facility.IndustrialCity.City_Id == vm.City_Id);
                //AddFilter(vm.IndustrialCity_Id, x => x.Facility.IndustrialCity_Id == vm.IndustrialCity_Id);
                //AddFilter(vm.FacilitiesGroup_Id, x => x.Facility.FacilitiesGroup_Id == vm.FacilitiesGroup_Id);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<AddFacilityOrderVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
                FormPage.Hidden("Facility_Id", x => x?.Facility_Id);

                FormPage.Number("Space", "المساحة", x => x?.Facility?.Space, true);
                FormPage.Email("Email", "البريد الالكتروني", x => x?.Facility?.Email, true);

                FormPage.LookupSelect("InternalOldActivity", "المنشاة لديها نشاط سابق داخل المدينة الصناعية", x => x?.Facility?.InternalOldActivity,LookupType.TrueFalse, null, true, 1);
                FormPage.LookupSelect("ExternalOldActivity", "المنشاة لديها نشاط سابق خارج المدينة الصناعية", x => x?.Facility?.ExternalOldActivity, LookupType.TrueFalse, null, true, 1);

                FormPage.LookupParantSelect("MainActivity_Id", "النشاط الرئيسي", x => x?.Facility?.SubActivities?.GetIds(), LookupType.SubActivity, 0, true, 2);
                FormPage.LookupMulipleSelect("SubActivities2", "النشاط الفرعي", x => x?.Facility?.SubActivities?.GetIds(), LookupType.SubActivity, null, true, 2, "MainActivity_Id");

                FormPage.LookupParantSelect("Country_Id", "الدولة", x => x?.Facility?.IndustrialCity_Id, LookupType.IndustrialCity, 1, true, 3);
                FormPage.LookupParantSelect("City_Id", "المدينة", x => x?.Facility?.IndustrialCity_Id, LookupType.IndustrialCity, 0, true, 3, "Country_Id");
                FormPage.LookupSelect("FacilitiesGroup_Id", "المجمع", x => x?.Facility?.FacilitiesGroup_Id, LookupType.FacilitiesGroup, null, false, 3, "IndustrialCity_Id");
                FormPage.Field("OtherFacilitiesGroup", "مجمع او عقار اخر", x => x?.Facility?.OtherFacilitiesGroup, false, 3);
                FormPage.Field("FacilitiesGroupOwner", "مالك العقار", x => x?.Facility?.FacilitiesGroupOwner, false, 3);

                FormPage.Field("Address", "العنوان", x => x?.Facility?.Address, false, 4,12);
                FormPage.Number("Lang", "الاحداثي س", x => x?.Facility?.Lang, false, 4);
                FormPage.Number("Late", "الاحداثي ص", x => x?.Facility?.Late, false, 4);

                FormPage.RepeaterInput("Sales", "", x=> null, true, 5);

                FormPage.FileInput("CommcommercialID", "السجل التجاري", x => x?.CommcommercialID, true,6);
                FormPage.FileInput("FacilitySpaceDesign", "مخطط كروكي لتصميم المنشأة", x => x?.FacilitySpaceDesign, true, 6);
                FormPage.MultipleFile("OtherFiles", "مرفقات اخري يمكنك اختيار اكثر من ملف", x => x?.OtherFiles, true, 6);
            }
            if (DetailsPage == null)
            {
                DetailsPage = new UiPage<AddFacilityOrderVM>(FormPage);
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<AddFacilityOrderVM>(Page);
                ListPage.RowButtonsGroup = true;
                ListPage.RowButtons.Add(new FormButton<AddFacilityOrderVM>("عرض", "/FacilityOrder/Details").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<AddFacilityOrderVM>("تعديل", "/FacilityOrder/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<AddFacilityOrderVM>("حذف", "/FacilityOrder/Delete").AddParameter("id", x => x?.Id));
            }
        }
    }
}
