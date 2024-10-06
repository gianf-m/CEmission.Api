using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CO2.EntityFramework {
    public static class QueryableExtensions {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate) {
            return condition
                ? query.Where(predicate)
                : query;
        }
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate) {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }
    }
}
