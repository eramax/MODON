using Domains;
using System;
using UiBuilder;

namespace Queries
{
    public class EmployeeService : CrudService<EmployeeVM, Employee>
    {
        private static UiPage<EmployeeVM> EditForm { get; set; }
        public EmployeeService()
        {
            if (Page == null)
            {
                Page = new UiPage<EmployeeVM>("موظف", "الموظفين", "Employee");
                Page.Panels.AddRange(new string[] { "بيانات التواصل", "بيانات كلمة المرور", "الصلاحيات" });
                Page.Field("UserAccountVM[FullName]", "الاسم بالكامل", x => x?.UserAccount?.FullName, true, null, 12);
                Page.Field("UserAccountVM[UserName]", "اسم المستخدم", x => x?.UserAccount?.UserName, true);
                Page.Field("ADUsername", "الدليل النشط", x => x?.ADUsername, true);
                Page.Number("UserAccountVM[SSID]", "رقم الهوية", x => x?.UserAccount?.SSID, true);
                Include(x => x.UserAccount, x => x.UserAccount.IndustrialCities);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<EmployeeVM>(Page);
                FormPage.Field("UserAccountVM[FullName]", "الاسم بالكامل", x => x?.UserAccountVM?.FullName, true, null, 12);
                FormPage.Field("UserAccountVM[UserName]", "اسم المستخدم", x => x?.UserAccountVM?.UserName, true);
                FormPage.Field("ADUsername", "الدليل النشط", x => x?.ADUsername, true);
                FormPage.Number("UserAccountVM[SSID]", "رقم الهوية", x => x?.UserAccountVM?.SSID, true);
                FormPage.Hidden("Id", x => x?.Id);
                FormPage.Hidden("UserAccountVM[Id]", x => x?.UserAccountVM?.Id);
                FormPage.Email("UserAccountVM[Email]", "الايميل", x => x?.UserAccountVM?.Email, true, 0);
                FormPage.LookupSelect("Job_Id", "الوظيفة", x => x?.Job_Id, LookupType.Job, null, false, 0);
                FormPage.LookupSelect("UserAccountVM[CountryCode]", "كود الدولة", x => x?.UserAccountVM?.CountryCode, LookupType.CountryCode,null, true, 0);
                FormPage.Number("UserAccountVM[PhoneNumber]", "رقم الجوال", x => x?.UserAccountVM?.PhoneNumber, true, 0);
                FormPage.LookupSelect("UserAccountVM[IsEnabled]", "الحساب نشط", x => x?.UserAccountVM?.IsEnabled, LookupType.TrueFalse, null, true, 0);
                FormPage.Password("UserAccountVM[Password]", "كلمة المرور", x => "", true, 1, 6, x => x?.UserAccountVM?.UserName == null);
                FormPage.Password("UserAccountVM[Password2]", "تاكيد كلمة المرور", x => "", true, 1, 6, x => x?.UserAccountVM?.UserName == null);
                FormPage.LookupMulipleSelect("UserAccountVM[IndustrialCitiesIds]", "المدن الصناعية المصرح بها", x => x?.UserAccountVM?.IndustrialCities?.GetIds(), LookupType.IndustrialCity, null, true, 2,null,12);
            }
            if (EditForm == null)
            {
                EditForm = new UiPage<EmployeeVM>(FormPage);
                EditForm.Remove("Password");
                EditForm.Remove("Password2");
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<EmployeeVM>(Page) {RowButtonsGroup = true};
                ListPage.RowButtons.Add(new FormButton<EmployeeVM>("الملف الشخصي", "/Employee/Details").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<EmployeeVM>("تغير كلمة السر", "/Auth/ChangePassword", x => x?.UserAccount?.IsEnabled == 1).AddParameter("id", x => x?.UserAccount_Id));
                ListPage.RowButtons.Add(new FormButton<EmployeeVM>("تعديل", "/Employee/Set", x => x?.UserAccount?.IsEnabled == 1).AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<EmployeeVM>("تنشيط", "/Auth/Activate", x => x?.UserAccount?.IsEnabled == 2).AddParameter("id", x => x?.UserAccount_Id));
                ListPage.RowButtons.Add(new FormButton<EmployeeVM>("حظر", "/Auth/DeActivate", x => x?.UserAccount?.IsEnabled == 1).AddParameter("id", x => x?.UserAccount_Id));
            }
            if (DetailsPage == null)
            {
                DetailsPage = new UiPage<EmployeeVM>(EditForm);
            }
        }

        public override UiView Form(long? id, IMDResponse res = null)
        {
            if (id == null) return new ViewBuilder<EmployeeVM>(FormPage, res).Form();
            var vm = uw.QueryEntity<Employee>().GetByID<EmployeeVM>(id, false, IncludeProps.ToArray());
            if (vm != null) vm.UserAccountVM = vm.UserAccount.To<UserAccountVM>();
            return new ViewBuilder<EmployeeVM>(FormPage, res).Form(vm);
        }

        public override UiView Details(long? id, IMDResponse res = null)
        {
            if (id == null) return new ViewBuilder<EmployeeVM>(DetailsPage, res).Details();
            var vm = uw.QueryEntity<Employee>().GetByID<EmployeeVM>(id, false, IncludeProps.ToArray());
            if (vm != null) vm.UserAccountVM = vm.UserAccount.To<UserAccountVM>();
            return new ViewBuilder<EmployeeVM>(DetailsPage,res).Details(vm);
        }
    }
}
