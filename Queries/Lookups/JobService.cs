using Domains;
using UiBuilder;

namespace Queries
{
    public class JobService : CrudService<JobVM, Job>
    {
        public JobService()
        {
            if (Page == null)
            {
                Page = new UiPage<JobVM>("وظيفة", "الوظائف", "JobConfig");
                Page.Field("Name", "الوظيفة", x => x?.Name, true);
                Page.Hidden("Id", x => x?.Id);
                Page.RowButtons.Add(new FormButton<JobVM>("تعديل", "/JobConfig/Set").AddParameter("id", x => x?.Id));
                Page.RowButtons.Add(new FormButton<JobVM>("حذف", "/JobConfig/Delete").AddParameter("id", x => x?.Id));
            }
            if (FormPage == null) FormPage = Page;
            if (ListPage == null) ListPage = Page;
        }
    }
}
