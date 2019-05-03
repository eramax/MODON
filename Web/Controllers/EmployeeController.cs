using Commands;
using Domains;
using System.Web.Mvc;
using Queries;
using System;

namespace Web.Controllers
{
    [Authorize(Roles = "employee,super,admin,manager")]
    public class EmployeeController : CrudController<EmployeeService, BasicService<Employee, EmployeeVM>, Employee, EmployeeVM>
    {
        public override ActionResult Save(EmployeeVM vm)
        {
            var authService = new AuthService();
            var res = MDResponse.New();
            authService.EmployeeSet(vm, ref res);
            return Return(ref res, vm, Redirect("/"), this.SetVM);
        }
    }
}