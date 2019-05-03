using Domains;
using Infrastructure;
using System;

namespace Commands
{
    public class SaveFacilityService : BasicService<Facility, FacilityVM>
    {
        public override Facility Save(FacilityVM vm, ref IMDResponse res)
        {
            vm.SubActivities = DbHelper.ManyToMany<Facility, SubActivity>(uw, vm, x => x.SubActivities, vm.SubActivities2, ref res);
            return base.Save(vm,ref res);
        }
    }

    public class SaveFacilityOrderService : BasicService<AddFacilityOrder, AddFacilityOrderVM>
    {
        public override AddFacilityOrder Save(AddFacilityOrderVM vm, ref IMDResponse res)
        {
            vm.SubActivities = DbHelper.ManyToMany<Facility, SubActivity>(uw, vm, x => x.SubActivities, vm.SubActivitiesIds, ref res);
            var fac = uw.AuditEntity<Facility>().MapAndSaveAndDelete(vm, ref res);
            vm.Facility = fac;
            var ent = uw.AuditEntity<AddFacilityOrder>().MapAndSave(vm, ref res);
            uw.Save(ref res);
            return ent;
        }
    }
}
