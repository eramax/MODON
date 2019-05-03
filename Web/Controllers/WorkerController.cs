using Commands;
using Domains;
using System.Web.Mvc;
using Queries;

namespace Web.Controllers
{
    [Authorize]
    public class WorkerController : CrudController<WorkerService, BasicService<Worker, WorkerVM>, Worker, WorkerVM>
    { }
}