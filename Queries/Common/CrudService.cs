using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domains;
using Infrastructure;
using UiBuilder;

namespace Queries
{
    public abstract class CrudService<TViewModel, TEntity> 
        where TViewModel : class
        where TEntity : class, IBaseEntity
    {
        public static UiPage<TViewModel> Page { get; set; }
        public static UiPage<TViewModel> FormPage { get; set; }
        public static UiPage<TViewModel> ListPage { get; set; }
        public static UiPage<TViewModel> DetailsPage { get; set; }
        public static UiPage<TViewModel> FilterPage { get; set; }
        public static List<Expression<Func<TEntity, bool>>> Filters { get; set; }
        public static List<Expression<Func<TEntity, object>>> IncludeProps { get; set; }
        public UnitWork uw { get; set; }
        protected CrudService() { uw = new UnitWork(); }

        public CrudService<TViewModel, TEntity> AddFilter(object value, Expression<Func<TEntity, bool>> filter)
        {
            if (value == null) return this;
            var sv = value.ToString();
            if(!string.IsNullOrWhiteSpace(sv) && sv != "0") Filters.Add(filter);
            return this;
        }
        public CrudService<TViewModel, TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            if (IncludeProps == null) IncludeProps = new List<Expression<Func<TEntity, object>>>();
            IncludeProps.Push(includes);
            return this;
        }
        public virtual UiView Filter(TViewModel vm = null) => new ViewBuilder<TViewModel>(FilterPage ?? FormPage ?? Page).Filter(vm);
        public virtual UiView List(TViewModel vm , IMDResponse res = null)
            => new ViewBuilder<TViewModel>(ListPage,res).List(uw.QueryEntity<TEntity>().GetListFiltered<TViewModel>(Filters, IncludeProps?.ToArray()));
        public virtual UiView Form(long? id, IMDResponse res = null) 
            => (id.HasValue) ? new ViewBuilder<TViewModel>(FormPage,res).Form(uw.QueryEntity<TEntity>().GetByID<TViewModel>(id, false, IncludeProps?.ToArray())) 
                : new ViewBuilder<TViewModel>(FormPage,res).Form();
        public virtual UiView Form(TViewModel vm, IMDResponse res = null) => new ViewBuilder<TViewModel>(FormPage,res).Form(vm);
        public virtual UiView Details(long? id, IMDResponse res = null)
            => (id.HasValue) ? new ViewBuilder<TViewModel>(DetailsPage,res).Details(uw.QueryEntity<TEntity>().GetByID<TViewModel>(id, false, IncludeProps?.ToArray())) 
                : new ViewBuilder<TViewModel>(DetailsPage,res).Details();
    }
}
