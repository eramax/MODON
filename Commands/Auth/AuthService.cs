using Domains;
using Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Web;

namespace Commands
{
    public class AuthService
    {
        private static IOwinContext Context => HttpContext.Current.GetOwinContext();
        private static IAuthenticationManager AuthenticationManager => Context.Authentication;
        private static ApplicationUserManager UserManager => Context.GetUserManager<ApplicationUserManager>();
        private static ApplicationSignInManager SignInManager => Context.Get<ApplicationSignInManager>();

        public void Login(ClientVM model, bool useActiveDirectory = false)
        {
            if (model?.UserName == null || model.Password == null) return;
            if (useActiveDirectory) return;
            var user = UserManager.Find(model.UserName, model.Password);
            DoLogin(user);
        }

        public void DoLogin(UserAccount user)
        {
            if (user == null || user.IsEnabled != 1) return;
            var userIdentity = user.GenerateUserIdentity(UserManager);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, userIdentity);
        }

        public void ChangePassword(UserAccountVM vm)
        {
            if (vm?.Password == null || vm.Password != vm.Password2 || vm.Id == 0) return;
            var user = UserManager.FindById(vm.Id);
            if (user == null) return;
            user.PasswordHash = UserManager.PasswordHasher.HashPassword(vm.Password);
            var result = UserManager.Update(user);
        }


        public UserAccount UserAccountSet(UserAccountVM vm, ref IMDResponse res)
        {
            //--------- TBD check this account is allowed to be updated from this user.??
            if (vm == null) return null;
            var uw = new UnitWork();
            if (vm.Password != null) vm.PasswordHash = UserManager.PasswordHasher.HashPassword(vm.Password);
            if (vm.Id == 0)
            {
                vm.IsEnabled = 1; 
                vm.SecurityStamp = Guid.NewGuid().ToString();
            }
            vm.IndustrialCities = DbHelper.ManyToMany<UserAccount, IndustrialCity>(uw, vm, x => x.IndustrialCities, vm.IndustrialCitiesIds, ref res);
            var us = uw.Command<UserAccount>().MapAndSaveDiff(vm, ref res);
            uw.Save(ref res);
            return us;
        }

        public void ClientSet(ClientVM vm , ref IMDResponse res)
        {
            var us = vm.To<UserAccountVM>();
            var user = UserAccountSet(us, ref res);
            if (!res.HasNoErrors || user == null) return;
            var client = BasicService.SaveEntity<Client>(vm, ref res);
            DbHelper.OneToMany<UserAccount>(new UnitWork(), x => x.Client_Id = client.Id, ref res, user);
            UserManager.AddToRole(user.Id, "client");
            DoLogin(user);
        }

        public void EmployeeSet(EmployeeVM vm, ref IMDResponse res)
        {
            var user = UserAccountSet(vm.UserAccountVM, ref res);
            if (!res.HasNoErrors || user == null) return;
            vm.UserAccount_Id = user.Id;
            var emp = BasicService.SaveEntity<Employee>(vm, ref res);
            UserManager.AddToRole(user.Id, "employee");
        }

        public void Activate(long userid)
        {
            var user = UserManager.FindById(userid);
            if (user == null) return;
            user.IsEnabled = 1;
            UserManager.Update(user);
        }
        public void DeActivate(long userid)
        {
            var user = UserManager.FindById(userid);
            if (user == null) return;
            user.IsEnabled = 2;
            UserManager.Update(user);
        }
        public void Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        public void ResetPassword(long? userid, UserAccountVM vm)
        {
            if (userid == null) return;
            var user = UserManager.FindById(userid.Value);
            if (user == null || vm == null || user.Email != vm.Email || user.SSID != vm.SSID ||
                user.PhoneNumber != vm.PhoneNumber) return;
            var random = new Random();
            var newpassword = random.Next(100000, 999999);
            vm.Password = newpassword.ToString();
            vm.Id = userid.Value;
            ChangePassword(vm);
            //*************** send sms with new code
        }
    }
}
