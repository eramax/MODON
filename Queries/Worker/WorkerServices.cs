using Domains;
using System.Collections.Generic;
using UiBuilder;

namespace Queries
{
    public class WorkerService : CrudService<WorkerVM, Worker>
    {
        public WorkerService()
        {
            if (Page == null)
            {
                Page = new UiPage<WorkerVM>("العمالة ", "إدارة العمالة", "Worker");
                Page.Panels = new List<string>(new string[] { "المرفقات", });
                Page.Field("Name", "اسم العامل", x => x?.Name, true, null, 12);
                Page.Field("IDCardNumber", "رقم الهوية", x => x?.IDCardNumber, true);
                Page.LookupSelect("NationalityId", "الجنسية", x => x?.NationalityId, LookupType.Nationality, null, true);
                Page.LookupSelect("RelegionId", "الديانة", x => x?.RelegionId, LookupType.Relegion,null, true);
            }
            if (ListPage == null)
            {
                ListPage = new UiPage<WorkerVM>(Page);
                ListPage.RowButtonsGroup = true;
                ListPage.RowButtons.Add(new FormButton<WorkerVM>("عرض", "/Worker/Details").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<WorkerVM>("تعديل", "/Worker/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<WorkerVM>("حذف", "/Worker/Delete").AddParameter("id", x => x?.Id));
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<WorkerVM>(Page);
                FormPage.HijriDate("IDCardStartDate", "تاريخ اصدار الاقامة", x => x?.IDCardStartDate, true);
                FormPage.HijriDate("IDCardExpireDate", "تاريخ انتهاء الاقامة", x => x?.IDCardExpireDate, true);
                FormPage.Date("BirthDate", "تاريخ الميلاد", x => x?.BirthDate, true);
                FormPage.Number("PhoneNumber", "رقم الهاتف / الجوال", x => x?.PhoneNumber, true);
                FormPage.Field("JobName", "المهنة", x => x?.JobName, true);
                FormPage.LookupMulipleSelect("IndustrialCityId", "المدن الصناعية التى يعمل بها", x => x?.IndustrialCities, LookupType.IndustrialCity,null, true);
                FormPage.Field("EmployeerName", "اسم صاحب العمل / الكفيل", x => x?.EmployeerName, true);
                FormPage.FileInput("IDPictureFile", "إرفاق صورة هوية العامل", x => x?.IDPictureFile, true, 0);
                FormPage.FileInput("WorkerPictureFile", "إرفاق صورة شخصية العامل", x => x?.WorkerPictureFile, true,0);
                FormPage.Hidden("Id", x => x?.Id);
            }
            if (DetailsPage == null)
            {
                DetailsPage = new UiPage<WorkerVM>(FormPage);
            }
        }
    }
}
