using System;
using Domains;
using UiBuilder;

namespace Queries
{
    public class UserAccountService : CrudService<UserAccountVM, UserAccount>
    {
        private static UiPage<UserAccountVM> EditForm { get; set; }
        public UserAccountService()
        {
            if (Page == null)
            {
                Page = new UiPage<UserAccountVM>("حساب فرعي","الحسابات التابعة للمستثمر","Auth");
                Page.Panels.AddRange(new string[] { "بيانات التواصل", "بيانات كلمة المرور", "الصلاحيات" , "بيانات المستثمر" , "بيانات الموظف" });
                Page.Field("FullName", "الاسم بالكامل", x => x?.FullName, true,null,12);
                Page.Field("UserName", "اسم المستخدم", x => x?.UserName, true);
                Page.Number("SSID", "رقم الهوية", x => x?.SSID, true);
                Include(x => x.Client, x => x.IndustrialCities, x => x.Employee);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<UserAccountVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
                FormPage.Email("Email", "الايميل", x => x?.Email, true,0);
                FormPage.LookupSelect("CountryCode", "كود الدولة", x => x?.CountryCode, LookupType.CountryCode, null, true, 0);
                FormPage.Number("PhoneNumber", "رقم الجوال", x => x?.PhoneNumber, true,0);
                FormPage.LookupSelect("IsEnabled", "الحساب نشط", x => x?.IsEnabled, LookupType.TrueFalse, null, true, 0);
                FormPage.Password("Password", "كلمة المرور", x => "", true, 1, 6, x => x?.UserName == null);
                FormPage.Password("Password2", "تاكيد كلمة المرور", x => "", true, 1, 6, x => x?.UserName == null);
                FormPage.LookupMulipleSelect("IndustrialCitiesIds", "المدن الصناعية المصرح بها", x => x?.IndustrialCities?.GetIds(), LookupType.IndustrialCity, null, true, 2, null, 12);
            }
            if (EditForm == null)
            {
                EditForm = new UiPage<UserAccountVM>(FormPage);
                EditForm.Remove("Password");
                EditForm.Remove("Password2");
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<UserAccountVM>(Page) {RowButtonsGroup = true};
                ListPage.RowButtons.Add(new FormButton<UserAccountVM>("الملف الشخصي", "/Auth/Details").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<UserAccountVM>("تغير كلمة السر", "/Auth/ChangePassword", x => x.IsEnabled == 1).AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<UserAccountVM>("تعديل", "/Auth/Set", x => x.IsEnabled == 1).AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<UserAccountVM>("تنشيط", "/Auth/Activate", x => x.IsEnabled == 2).AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<UserAccountVM>("حظر", "/Auth/DeActivate", x => x.IsEnabled == 1).AddParameter("id", x => x?.Id));
            }
            if (DetailsPage == null)
            {
                DetailsPage = new UiPage<UserAccountVM>(EditForm);
                DetailsPage.Field("clinetName", "اسم المستثمر", x => x?.Client?.FullName, false, 3);
                DetailsPage.Field("organization", "اسم المؤسسة/الشركة", x => x?.Client?.Organization, false, 3);
                DetailsPage.Field("clientSSID", "رقم هوية المستثمر", x => x?.Client?.SSID, false, 3);
            }
        }
        public UiView ChangePasswordForm(long? id)
        {
            var ChangePassPage = new UiPage<UserAccountVM>() { Action = "Auth/ChangePasswordSave" };
            ChangePassPage.Hidden("Id", x => id);
            ChangePassPage.Password("Password", "كلمة المرور", x => x?.Password,true);
            ChangePassPage.Password("Password2", "تاكيد كلمة المرور", x => x?.Password2, true);
            return new ViewBuilder<UserAccountVM>(ChangePassPage, null).Form();
        }
    }
}
