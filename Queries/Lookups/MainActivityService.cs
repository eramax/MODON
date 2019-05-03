using Domains;
using UiBuilder;

namespace Queries
{
    public class MainActivityService : CrudService<MainActivityVM,MainActivity>
    {
        public MainActivityService()
        {
            if (Page == null)
            {
                Page = new UiPage<MainActivityVM>("نشاط رئيسي", "الانشطة الرئيسية" , "MainActivityConfig");
                Page.Field("Name", "اسم النشاط", x => x?.Name, true);
                Page.Hidden("Id", x => x?.Id);
                Page.RowButtons.Add(new FormButton<MainActivityVM>("تعديل", "/MainActivityConfig/Set").AddParameter("id", x => x?.Id));
                Page.RowButtons.Add(new FormButton<MainActivityVM>("حذف", "/MainActivityConfig/Delete").AddParameter("id", x => x?.Id));
            }
            if (FormPage == null) FormPage = Page;
            if (ListPage == null) ListPage = Page;
        }
    }
}
