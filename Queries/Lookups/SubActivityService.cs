using Domains;
using UiBuilder;

namespace Queries
{
    public class SubActivityService : CrudService<SubActivityVM,SubActivity>
    {
        public SubActivityService()
        {
            if(Page == null)
            {
                Page = new UiPage<SubActivityVM>("نشاط فرعي", "الانشطة الفرعية", "SubActivityConfig");
                Page.Field("Name", "النشاط الفرعي", x => x?.Name,true);
                Page.LookupSelect("MainActivity_Id", "النشاط الرئيسي", x => x?.MainActivity_Id, LookupType.MainActivity, null, true);
                Include(x => x.MainActivity);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<SubActivityVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
            }
            if(ListPage == null)
            {
                ListPage = new UiPage<SubActivityVM>(Page);
                ListPage.RowButtons.Add(new FormButton<SubActivityVM>("تعديل", "/SubActivityConfig/Set").AddParameter("id", x => x?.Id));
                ListPage.RowButtons.Add(new FormButton<SubActivityVM>("حذف", "/SubActivityConfig/Delete").AddParameter("id", x => x?.Id));
            }
        }
    }
}
