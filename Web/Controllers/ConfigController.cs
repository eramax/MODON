using Commands;
using Domains;
using System.Web.Mvc;
using Queries;

namespace Web.Controllers
{
    public class CountryConfigController : CrudController<CountryService, BasicService<Country,CountryVM>, Country, CountryVM> { }
    public class JobConfigController : CrudController<JobService, BasicService<Job, JobVM>, Job, JobVM> { }
    public class CityConfigController : CrudController<CityService, BasicService<City, CityVM>, City, CityVM>  { }
    public class IndustrialCityConfigController : CrudController<IndustrialCityService, BasicService<IndustrialCity, IndustrialCityVM>, IndustrialCity, IndustrialCityVM> { }
    public class FacilitiesGroupConfigController : CrudController<FacilitiesGroupService, BasicService<FacilitiesGroup, FacilitiesGroupVM>, FacilitiesGroup, FacilitiesGroupVM>    { }
    public class MainActivityConfigController : CrudController<MainActivityService, BasicService<MainActivity, MainActivityVM>, MainActivity, MainActivityVM>    { }
    public class SubActivityConfigController : CrudController<SubActivityService, BasicService<SubActivity, SubActivityVM>, SubActivity, SubActivityVM>    { }
    public class RoleConfigController : CrudController<RoleService, SaveRoleService, Role, RoleVM>    { }
    public class PermissionConfigController : CrudController<PermissionService, SavePermissionService, Permission, PermissionVM>    { }

    public class ConfigController : BaseController
    {
        public ActionResult SystemReboot()
        {
            LookupService.Init();
            return RedirectToAction("/","Home");
        }
    }
}