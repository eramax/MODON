//using Domains;
//using Domains.Lookups;
//using Infrastructure.Common;
//using System;
//using System.Data.SqlClient;
//using System.Web.Mvc;
//using Tester.Common;

//namespace Tester.Tests
//{
//    public class _2_CheckReadRepo : ITest
//    {
//        public void Run()
//        {
//            // Testing Adding
//            UnitWork uw = new UnitWork();
//            var newActivity = new MainActivity() { Name = "newActivity" };
//            uw.Command<MainActivity>().Insert(newActivity);
//            uw.Save();
//            TestResult.Result("Added new Activity", newActivity.Id != 0, newActivity);

//            UnitWork uw2 = new UnitWork();
//            var addedActivity = uw2.Query<MainActivity>().GetByID(newActivity.Id);
//            TestResult.Result("compare get with insert", addedActivity.Equals(newActivity), addedActivity);

//            UnitWork uw3 = new UnitWork();
//            var sub1 = new SubActivity() { Name = "sub1", MainActivity_Id = addedActivity.Id };
//            uw3.Command<SubActivity>().Insert(sub1);
//            var sub2 = new SubActivity() { Name = "sub2", MainActivity_Id = addedActivity.Id };
//            uw3.Command<SubActivity>().Insert(sub2);
//            uw3.Save();

//            TestResult.Result("Insert Sub1", sub1.Id != 0, sub1);
//            TestResult.Result("Insert Sub2", sub2.Id != 0, sub2);

//            UnitWork uw4 = new UnitWork();
//            var ac1 = uw4.Command<MainActivity>().GetByID(newActivity.Id);
//            TestResult.Result("compare command get with query get", ac1.SubActivities.Count == 2, ac1);


//            //ac1.Name = "updated ac1";
//            //string acref = ac1.Ref;
//            //uw4.Command<MainActivity>().Update(ac1);
//            //uw4.Save();

//            //var versions = uw4.Query<MainActivity>().Exec("select * from MainActivity where Ref = @ref",
//            //    new SqlParameter("@ref", acref));
//            //TestResult.Result("Get All versions of audit", versions.Count == 2, versions);

//            //var c = uw4.AuditEntity<MainActivity>().GetAllVersions(ac1.Id, null, null, x => x.SubActivities);
//            //TestResult.Result("Get All versions of audit", c.Count == 2, c);



//            var count1 = uw.Query<SubActivity>().Count(x => x.MainActivity_Id == 98);
//            TestResult.Result("check count function", count1 == 2, count1);

//            var ac3 = uw.Query<MainActivity>().Get(x => x.Id == 98);
//            //var ac3 = uw.QueryEntity<MainActivity>().GetByID(98);

//            TestResult.Result("check ac3 get", ac3.Count == 1, ac3);

//            var deletedItem = uw.QueryEntity<MainActivity>().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() } , x => x.Id == 125);
//            TestResult.Result("check ac3 get", deletedItem.Count == 0, deletedItem);

//            uw.Command<Country>().Insert(new Country() { Name = "المملكة العربية السعودية" });
//            uw.Command<Country>().Insert(new Country() { Name = "سوريا" });
//            uw.Command<Country>().Insert(new Country() { Name = "الكويت" });
//            uw.Command<Country>().Insert(new Country() { Name = "العراق" });
//            uw.Command<Country>().Insert(new Country() { Name = "مصر" });
//            uw.Command<Country>().Insert(new Country() { Name = "السودان" });
//            uw.Command<Country>().Insert(new Country() { Name = "امريكا" });
//            uw.Save();

//        }
//    }

//}
