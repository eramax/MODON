using System;
using Domains;
using UiBuilder;

namespace Queries
{
    public class RoleService : CrudService<RoleVM, Role>
    {
        public RoleService()
        {
            if (Page == null)
            {
                Page = new UiPage<RoleVM>("مجموعة مستخدمين", "مجموعات المستخدمين", "RoleConfig");
                Page.Field("DisplayName", "اسم العرض", x => x?.DisplayName, true);
                Page.Field("Name", "الصلاحية", x => x?.Name, true);
                Page.RowButtons.Add(new FormButton<RoleVM>("تعديل", "/RoleConfig/Set").AddParameter("id", x => x?.Id));
                Page.RowButtons.Add(new FormButton<RoleVM>("حذف", "/RoleConfig/Delete").AddParameter("id", x => x?.Id));
                Include(x => x.Permissions);
            }
            if(FormPage == null)
            {
                FormPage = new UiPage<RoleVM>(Page);
                FormPage.Hidden("Id", x => x?.Id);
                FormPage.LookupMulipleSelect("PermissionsIds", "الصلاحيات", x => x?.Permissions?.GetIds(), LookupType.Permission, null, false);
            }
            if (ListPage == null) ListPage = Page;
        }
    }
}
