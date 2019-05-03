using Domains;
using System.Collections.Generic;
using UiBuilder;
using System;

namespace Queries
{
    public class FacilityService : CrudService<FacilityVM, Facility>
    {
        public FacilityService()
        {
            if (Page == null)
            {
                Page = new UiPage<FacilityVM>("منشأة", "المنشأت", "Facility");
                Page.Panels = new List<string>(new string[] { "بيانات المنشأة", "بيانات النشاط السابق", "بيانات النشاط", "بيانات موقع المنشأة", "بيانات الاحداثيات والعنوان" });
                Include(x => x.FacilitiesGroup, x => x.IndustrialCity, x => x.Client, x => x.SubActivities);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<FacilityVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
                FormPage.Field("Name", "أسم المنشأة", x => x?.Name, true);
                FormPage.Number("Space", "المساحة", x => x?.Space, true);
                FormPage.Email("Email", "البريد الالكتروني", x => x?.Email, true);

                FormPage.LookupSelect("InternalOldActivity", "المنشاة لديها نشاط سابق داخل المدينة الصناعية", x => x?.InternalOldActivity, LookupType.TrueFalse,null, true, 1);
                FormPage.LookupSelect("ExternalOldActivity", "المنشاة لديها نشاط سابق خارج المدينة الصناعية", x => x?.ExternalOldActivity, LookupType.TrueFalse, null, true, 1);

                FormPage.LookupParantSelect("MainActivity_Id", "النشاط الرئيسي", x=> x?.SubActivities?.GetIds(), LookupType.SubActivity, 0, true, 2);
                FormPage.LookupMulipleSelect("SubActivities2", "النشاط الفرعي", x => x?.SubActivities?.GetIds(), LookupType.SubActivity, null, true, 2, "MainActivity_Id");

                FormPage.LookupParantSelect("Country_Id", "الدولة", x => x?.IndustrialCity_Id, LookupType.IndustrialCity, 1, true, 3);
                FormPage.LookupParantSelect("City_Id", "المدينة", x => x?.IndustrialCity_Id,  LookupType.IndustrialCity, 0, true, 3, "Country_Id");
                FormPage.LookupSelect("IndustrialCity_Id", "المدينة الصناعية", x => x?.IndustrialCity_Id, LookupType.IndustrialCity, null, true, 3, "City_Id");
                FormPage.LookupSelect("FacilitiesGroup_Id", "المجمع", x => x?.FacilitiesGroup_Id,  LookupType.FacilitiesGroup, null, false, 3, "IndustrialCity_Id");
                FormPage.Field("OtherFacilitiesGroup", "مجمع او عقار اخر", x => x?.OtherFacilitiesGroup, false, 3);
                FormPage.Field("FacilitiesGroupOwner", "مالك العقار", x => x?.FacilitiesGroupOwner, false, 3);

                FormPage.Field("Address", "العنوان", x => x?.Address, false, 4);
                FormPage.Number("Lang", "الاحداثي س", x => x?.Lang, false, 4);
                FormPage.Number("Late", "الاحداثي ص", x => x?.Late, false, 4);
            }
            if(DetailsPage == null)
            {
                DetailsPage = new UiPage<FacilityVM>(FormPage);
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<FacilityVM>(Page);
                ListPage.RowButtonsGroup = true;
                ListPage.Field("Name", "أسم المنشأة", x => x?.Name, true);
                ListPage.LookupSelect("IndustrialCity_Id", "المدينة الصناعية", x => x?.IndustrialCity_Id, LookupType.IndustrialCity, null, true, 3, "City_Id");
                ListPage.RowButtons.Add(new FormButton<FacilityVM>("عرض", "/Facility/Details").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<FacilityVM>("تعديل", "/Facility/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<FacilityVM>("حذف", "/Facility/Delete").AddParameter("id", x => x?.Id));
            }
        }
    }
}
