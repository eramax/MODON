using Commands;
using Domains;
using Queries;

namespace Web.Controllers
{
    public class FacilityController : CrudController<FacilityService, SaveFacilityService, Facility, FacilityVM>
    { }
}