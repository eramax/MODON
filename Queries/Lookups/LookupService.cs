using Domains;
using System;
using Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    public static class LookupService
    {
        public static void Init()
        {
            StaticLookups = new Dictionary<LookupType, Lookup>();
            StaticLookups.Push(LookupType.Nationality, new Lookup()
            {
                 new SelectItem(1,"سعودي"),
                 new SelectItem(2,"مصري"),
                 new SelectItem(3,"افغاني"),
                 new SelectItem(4,"تونسي"),
                 new SelectItem(5,"سوداني"),
                 new SelectItem(6,"قطري"),
                 new SelectItem(7,"اردني")
            });
            StaticLookups.Push(LookupType.Relegion, new Lookup()
            {
                 new SelectItem(1,"الاسلام"),
                 new SelectItem(2,"المسيحية"),
                 new SelectItem(3,"اليهودية"),
                 new SelectItem(4,"غير ذلك")
            });
            StaticLookups.Push(LookupType.Gender, new Lookup()
            {
                 new SelectItem(1,"ذكر"),
                 new SelectItem(2,"انثي"),
                 new SelectItem(3,"غير ذلك")
            });
            StaticLookups.Push(LookupType.CountryCode, new Lookup()
            {
                 new SelectItem(1,"966")
            });
            StaticLookups.Push(LookupType.TrueFalse, new Lookup()
            {
                 new SelectItem(1,"نعم"),
                 new SelectItem(2,"لا"),
            });

            StaticLookups.Push(LookupType.Country, new Lookup(new UnitWork().QueryEntity<Country>().Select(x => new SelectItem { Id = x.Id, Name = x.Name })));
            StaticLookups.Push(LookupType.City, new Lookup(new UnitWork().QueryEntity<City>().Select(x => new SelectItem { Id = x.Id, Name = x.Name, ParantID = x.CountryID }), LookupType.Country));
            StaticLookups.Push(LookupType.IndustrialCity, new Lookup(new UnitWork().QueryEntity<IndustrialCity>().Select(x => new SelectItem { Id = x.Id, Name = x.Name, ParantID = x.City_Id }), LookupType.City));
            StaticLookups.Push(LookupType.FacilitiesGroup, new Lookup(new UnitWork().QueryEntity<FacilitiesGroup>().Select(x => new SelectItem { Id = x.Id, Name = x.Name, ParantID = x.IndustrialCity_Id }), LookupType.IndustrialCity));
            StaticLookups.Push(LookupType.MainActivity, new Lookup(new UnitWork().QueryEntity<MainActivity>().Select(x => new SelectItem { Id = x.Id, Name = x.Name })));
            StaticLookups.Push(LookupType.SubActivity, new Lookup(new UnitWork().QueryEntity<SubActivity>().Select(x => new SelectItem { Id = x.Id, Name = x.Name, ParantID = x.MainActivity_Id }), LookupType.MainActivity));
            StaticLookups.Push(LookupType.Role, new Lookup(new UnitWork().QueryEntity<Role>().Select(e => new SelectItem() { Id = e.Id, Name = e.DisplayName })));
            StaticLookups.Push(LookupType.Permission, new Lookup(new UnitWork().QueryEntity<Permission>().Select(e => new SelectItem() { Id = e.Id, Name = e.DisplayName })));
            StaticLookups.Push(LookupType.Job, new Lookup(new UnitWork().QueryEntity<Job>().Select(e => new SelectItem() { Id = e.Id, Name = e.Name })));
        }


        private static Dictionary<LookupType, Lookup> StaticLookups { get; set; }
        public static string Names(LookupType? k1, object ids, int? ParnatLevel = 0, bool ReverseIdToParant = false)
        {
            if (StaticLookups == null) Init();
            if (k1 == null || ids == null) return null;
            return string.Join(" , ", PopList(k1, ids, ParnatLevel, ReverseIdToParant)?.Where(x => x.Selected == true)?.Select(x => x.Name) ?? null );
        }
        public static Lookup PopList(LookupType? k1, object childIds, int? ParnatLevel = null, bool ReverseIdToParant = false)
        {
            if (StaticLookups == null) Init();
            if (k1 == null) return null;
            var ids = new List<long>();
            if (childIds == null)
                return ReverseIdToParant ? PopParantList(k1, ids, ParnatLevel) : PopLookup(k1, ParnatLevel, ids);
            if (long.TryParse(childIds.ToString(), out var singleId))
                ids.Add(singleId);
            else ids = (childIds as List<long>);
            return ReverseIdToParant ? PopParantList(k1, ids, ParnatLevel) : PopLookup(k1, ParnatLevel, ids);
        }
        public static Lookup PopParantList(LookupType? k1, List<long> ids, int? ParnatLevel = 0)
        {
            if (ids == null || !k1.HasValue || StaticLookups == null || !StaticLookups.ContainsKey(k1.Value)) return null;
            var type = k1.Value;
            if (ParnatLevel.HasValue)
            {
                for (var i = ParnatLevel.Value; i >= 0 && StaticLookups[type].Parant.HasValue; i--)
                {
                    var tmp = StaticLookups[type].Where(x => ids.Contains(x.Id) && x.ParantID != null).GroupBy(x => x.ParantID).Select(x => x.First().ParantID.Value).ToList();
                    type = StaticLookups[type].Parant.Value;
                    ids = tmp;
                }
            }
            var Result = new Lookup(StaticLookups[type]);
            var query = (from it in Result
                         where ids.Contains(it.Id)
                         select it)
                        .Update(st => { st.Selected = true; });

            return Result;
        }
        public static Lookup PopLookup(LookupType? k1, int? ParnatLevel = null, List<long> selected = null)
        {
            if (selected == null) return StaticLookups[PopLookupKey(k1, ParnatLevel)];
            var Result = new Lookup(StaticLookups[PopLookupKey(k1, ParnatLevel)]);
            var query = (from it in Result
                         where selected.Contains(it.Id)
                         select it)
                        .Update(st => { st.Selected = true; });
            return Result;
        }
        private static LookupType PopLookupKey(LookupType? k1, int? ParnatLevel = null)
        {
            var type = k1.Value;
            var tmp = StaticLookups[type];
            if (!ParnatLevel.HasValue) return type;
            for (var i = ParnatLevel.Value; i >= 0 && StaticLookups[type].Parant.HasValue; i--)
            {
                type = StaticLookups[type].Parant.Value;
            }
            return type;
        }
    }
}
