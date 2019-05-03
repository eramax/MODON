using Commands;
using Domains;
using System.Web.Mvc;
using Queries;
using System;

namespace Web.Controllers
{
    [Authorize]
    public class CrudController<TService, SaveService, TEntity, TViewModel> : BaseController
          where TService : CrudService<TViewModel, TEntity>, new()
          where TEntity : class, IBaseEntity, new()
          where TViewModel : class, IEntityKey, new()
          where SaveService : class, ISaveService<TEntity, TViewModel>, new()
    {
        public virtual ActionResult Index(TViewModel vm)
        {
            var model = new TService().List(vm);
            return Return(model);
        }
        public virtual ActionResult Set(long? id)
        {
            var model = new TService().Form(id);
            return Return(model);
        }
        public virtual ActionResult SetVM(TViewModel vm, IMDResponse res = null)
        {
            var model = new TService().Form(vm, res);
            return Return(model);
        }
        public virtual ActionResult Save(TViewModel vm)
        {
            var res = MDResponse.New();
            new SaveService().Save(vm , ref res);
            return Return<TViewModel>(ref res, vm, Redirect("/"), RedirectToAction("SetVM", vm));
        }

        public virtual ActionResult Delete(long? id)
        {
            IMDResponse res = new MDResponse();
            new SaveService().Delete(id, ref res);
            return Redirect("/");
        }

        public virtual ActionResult Filter()
        {
            var model = new TService().Filter();
            return Partial(model);
        }
        public virtual ActionResult Details(long? id)
        {
            var model = new TService().Details(id);
            return Return(model);
        }
    }
}