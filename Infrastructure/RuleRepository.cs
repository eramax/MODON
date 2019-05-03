using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class Rule<T> where T : class
    {
        public Expression<Func<T, bool>> Predicate;
        public void AddRule(Expression<Func<T, bool>> rule) => Predicate = Predicate == null ? rule : Predicate.And(rule);
        public Expression<Func<T, bool>> GetExpressions() => Predicate;
        //public string PropName { get; set; }
        //public string ErrorMessage { get; set; }
    }
    public static class RuleRepository<T> where T : class
    {
        //--------------- Check Model is not null
        //--------------- if insert you have to add  the Modifiers 
        //--------------- if update you have to add  the Modifiers
        //--------------- if delete you have to add  the Filters 
        //--------------- if select you have to add  the Filters 
        //--------------- Check Model is valid


        //---------- Dictionary RoleName and List of Rules for this role
        public static Dictionary<string, Rule<T>> Rules { get; set; }
        public static Dictionary<string, List<Action<T>>> Modifiers { get; set; }
        public static Expression<Func<T, bool>> GetExpressions(string role = "") => Rules?.Pop(role)?.GetExpressions();
        public static void AddRule(string role, Expression<Func<T, bool>> rule)
        {
            if (Rules == null) Rules = new Dictionary<string, Rule<T>>();
            if (!Rules.ContainsKey(role))
                Rules.Add(role, new Rule<T>());
            Rules.Pop(role).AddRule(rule);
        }
        public static bool IsValid(T entity, ref IMDResponse res)
        {
            return (entity != null && (res == null || res.HasNoErrors));
        }

        public static void AddModifier(string role, Action<T> modifer)
        {
            if (Modifiers == null) Modifiers = new Dictionary<string, List<Action<T>>>();
            if (!Modifiers.ContainsKey(role))
                Modifiers.Add(role, new List<Action<T>>());
            Modifiers.Pop(role).Add(modifer);
        }

        public static bool ProcessModifiers(string role, ref T entity, bool insert)
        {
            var check = true;
            if (!insert) check = CanIdoThis(role, ref entity);
            if (check)
            {
                if (Modifiers == null) return true;
                foreach (var modifier in Modifiers?.Pop(role).Data()) modifier(entity);
            }
            if (insert) check = CanIdoThis(role, ref entity);
            return check;
        }

        public static bool CanIdoThis(string role, ref T entity)
        {
            var lst = new List<T>() {entity}.AsQueryable();
            var conditions = GetExpressions(role);
            var count = lst.Count(conditions);
            return count >= 1;
        }
    }
}
