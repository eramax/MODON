using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Domains;

namespace System
{
    public static class CurrentUser
    {
        public static IPrincipal User => HttpContext.Current?.User;
        public static string Username => User.Username();
        public static long? UserId => User.UserId();
        public static long? ClientId => HttpContext.Current.User.Client_Id();
        public static string Role => HttpContext.Current.User.Role();
    }

    public static class UserExtension
    {
        public static long? UserId(this IPrincipal user) => user.Valid() ? user.Identity.GetUserId<long>() as long? : null;
        public static string Username(this IPrincipal user) => user.Valid() ? user.Identity.GetUserName() : null;

        public static string FullName(this IPrincipal user) => user.Valid()
            ? (user.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type == "FullName")?.Value
            : null;

        public static string Email(this IPrincipal user) => user.Valid()
            ? (user.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type == "Email")?.Value
            : null;

        private static bool Valid(this IPrincipal user) => user != null;
        public static bool IsAdmin(this IPrincipal user) => user.Valid() && user.IsInRole(UserTypes.Admin);
        public static bool IsClient(this IPrincipal user) => user.Valid() && user.IsInRole(UserTypes.Client);
        public static bool IsEmployee(this IPrincipal user) => user.Valid() && user.IsInRole(UserTypes.Employee);
        public static bool IsManager(this IPrincipal user) => user.Valid() && user.IsInRole(UserTypes.Manager);
        public static bool IsSuper(this IPrincipal user) => user.Valid() && user.IsInRole(UserTypes.Super);
        public static long? Client_Id(this IPrincipal user)
        {
            var x = ((ClaimsIdentity)user.Identity).FindFirst("Client_Id").Value;
            if (!string.IsNullOrEmpty(x) && long.TryParse(x, out var result)) return result;
            return null;
        }
        public static string Role(this IPrincipal user)
        {
            if (user.IsAdmin()) return UserTypes.Admin;
            else if (user.IsSuper()) return UserTypes.Super;
            else if (user.IsManager()) return UserTypes.Manager;
            else if (user.IsEmployee()) return UserTypes.Employee;
            else if (user.IsClient()) return UserTypes.Client;
            else return "";
        }
    }
}
