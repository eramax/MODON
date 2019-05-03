using Domains;
using Infrastructure;
using System;

namespace Commands
{
    public static class RulesSetup
    {
        public static void Setup()
        {
            RuleRepository<UserAccount>.AddRule(UserTypes.Client, c =>  c.Client_Id == CurrentUser.ClientId);
            RuleRepository<UserAccount>.AddRule(UserTypes.Super, c => false);
            RuleRepository<UserAccount>.AddRule(UserTypes.Manager, c => c.Id == CurrentUser.UserId);



            RuleRepository<UserAccount>.AddModifier(UserTypes.Client, x => x.Client_Id = CurrentUser.ClientId);
            RuleRepository<UserAccount>.AddModifier(UserTypes.Client, x => x.SSID = CurrentUser.Username);
            RuleRepository<UserAccount>.AddModifier(UserTypes.Client, x => x.IsEnabled = 2);

        }
    }
}
