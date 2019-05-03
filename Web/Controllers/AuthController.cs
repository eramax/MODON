using Commands;
using Domains;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Queries;
using System;

namespace Web.Controllers
{
    public class AuthController : CrudController<UserAccountService, BasicService<UserAccount, UserAccountVM>, UserAccount, UserAccountVM>
    {
        public override ActionResult Save(UserAccountVM vm)
        {
            var service = new AuthService();
            var res = MDResponse.New();
            service.UserAccountSet(vm, ref res);
            return Redirect("/", "Auth");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new ClientVM();
            return View("Login", model);
        }
        [AllowAnonymous]
        public ActionResult Register(ClientVM model)
        {
            return View("Register");
        }
        [AllowAnonymous]
        public ActionResult LoginSet(ClientVM model)
        {
            var authService = new AuthService();
            authService.Login(model);
            return Redirect("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult RegisterSet(ClientVM model)
        {
            var authService = new AuthService();
            var res = MDResponse.New();
            authService.ClientSet(model, ref res);
            return Return<ClientVM>(ref res, model, Redirect("Index", "Home"), Redirect("Register"));
        }
        public ActionResult Logout()
        {
            var authService = new AuthService();
            authService.Logout();
            return Redirect("Login");
        }
        public ActionResult ChangeMyPassword()
        {
            var model = new UserAccountService().ChangePasswordForm(User.UserId());
            return Return(model);
        }
        public ActionResult ChangePassword(long id)
        {
            var model = new UserAccountService().ChangePasswordForm(id);
            return Return(model);
        }
        public ActionResult ChangePasswordSave(UserAccountVM vm)
        {
            var authService = new AuthService();
            if (vm.Id == 0) vm.Id = User.Identity.GetUserId<long>();
            authService.ChangePassword(vm);
            return RedirectHome();
        }
        public ActionResult Activate(long id)
        {
            var authService = new AuthService();
            authService.Activate(id);
            return RedirectHome();
        }
        public ActionResult DeActivate(long id)
        {
            var authService = new AuthService();
            authService.DeActivate(id);
            return RedirectHome();
        }
        public ActionResult ResetMyPassword(UserAccountVM vm)
        {
            var authService = new AuthService();
            authService.ResetPassword(User.UserId(), vm);
            return Redirect("Login");
        }
    }
}