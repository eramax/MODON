using Domains;
using System;
using UiBuilder;

namespace Queries
{
    public class PermissionService : CrudService<PermissionVM, Permission>
    {
        public PermissionService()
        {
            if(Page == null)
            {
                Page = new UiPage<PermissionVM>("صلاحية", "الصلاحيات", "PermissionConfig");
                Page.Field("DisplayName", "اسم العرض", x => x?.DisplayName, true);
                Page.Field("Name", "الصلاحية", x => x?.Name, true);
                Page.RowButtons.Add(new FormButton<PermissionVM>("تعديل", "/PermissionConfig/Set").AddParameter("id", x => x?.Id));
                Page.RowButtons.Add(new FormButton<PermissionVM>("حذف", "/PermissionConfig/Delete").AddParameter("id", x => x?.Id));
                Include(x => x.Roles);
            }
            if (FormPage == null)
            {
                FormPage = new UiPage<PermissionVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
                FormPage.LookupMulipleSelect("RoleIds", "مجموعات المستخدمين", x => x?.Roles?.GetIds(), LookupType.Role, null, false);
               
            }
            if (ListPage == null) ListPage = Page;
        }
    }
}
