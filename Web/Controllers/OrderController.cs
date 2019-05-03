using Commands;
using Domains;
using Queries;

namespace Web.Controllers
{
    public class FacilityOrderController :  CrudController<FacilityOrderService, SaveFacilityOrderService, AddFacilityOrder, AddFacilityOrderVM>
    { }
}