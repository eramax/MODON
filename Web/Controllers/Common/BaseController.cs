using System;
using System.Web.Mvc;
using UiBuilder;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public IMDResponse mdResponse;
        public BaseController()
        {
            this.mdResponse = new MDResponse();
        }
        public ActionResult Return(UiView model)
        {
            if (Request.IsAjaxRequest())
                return PartialView("~/Views/base.cshtml", model);
            else
                return View("~/Views/base.cshtml", model);
        }

        public ActionResult Return<TModel>(ref IMDResponse res, TModel model, Func<ActionResult> successActionResult, Func<TModel, IMDResponse, ActionResult> failedActionResult)
            => res.HasNoErrors ? successActionResult() : failedActionResult(model, res);
        public ActionResult Return<TModel>(ref IMDResponse res, TModel model, ActionResult successActionResult, Func<TModel, IMDResponse, ActionResult> failedActionResult)
            => res.HasNoErrors ? successActionResult : failedActionResult(model, res);
        public ActionResult Return<TModel>(ref IMDResponse res, TModel model, ActionResult successActionResult,ActionResult failedActionResult)
            => res.HasNoErrors ? successActionResult : failedActionResult;
        public ActionResult RedirectHome() => RedirectToAction("/", "Home");
        public ActionResult Redirect(string action, string controller = null) 
            => RedirectToAction(action, controller);
        public ActionResult Partial(UiView model) => PartialView("~/Views/base.cshtml", model);
    }   
}