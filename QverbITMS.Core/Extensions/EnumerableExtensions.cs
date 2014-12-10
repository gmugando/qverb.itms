using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core.Extensions
{
    public static class EnumerableExtensions
    {
        #region IEnumerable

        private class Status
        {
            public bool EndOfSequence;
        }

        private static IEnumerable<T> TakeOnEnumerator<T>(IEnumerator<T> enumerator, int count, Status status)
        {
            while (--count > 0 && (enumerator.MoveNext() || !(status.EndOfSequence = true)))
            {
                yield return enumerator.Current;
            }
        }


        /// <summary>
        /// Slices the iteration over an enumerable by the given chunk size.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="chunkSize">SIze of chunk</param>
        /// <returns>The sliced enumerable</returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> items, int chunkSize = 100)
        {
            if (chunkSize < 1)
            {
                throw new ArgumentException("Chunks should not be smaller than 1 element");
            }
            var status = new Status { EndOfSequence = false };
            using (var enumerator = items.GetEnumerator())
            {
                while (!status.EndOfSequence)
                {
                    yield return TakeOnEnumerator(enumerator, chunkSize, status);
                }
            }
        }


        /// <summary>
        /// Performs an action on each item while iterating through a list. 
        /// This is a handy shortcut for <c>foreach(item in list) { ... }</c>
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="source">The list, which holds the objects.</param>
        /// <param name="action">The action delegate which is called on each item while iterating.</param>
        //[DebuggerStepThrough]
        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T t in source)
            {
                action(t);
            }
        }

        /// <summary>
        /// Casts the objects within a list into another type.
        /// </summary>
        /// <typeparam name="T">The type of the source objects.</typeparam>
        /// <typeparam name="U">The target type of the objects.</typeparam>
        /// <param name="source">The list, which holds the objects.</param>
        /// <param name="converter">The delegate function which is responsible for converting each object.</param>
        public static IEnumerable<TTarget> Transform<TSource, TTarget>(this IEnumerable<TSource> source, Converter<TSource, TTarget> converter)
        {
            foreach (TSource s in source)
                yield return converter(s);
        }

        /// <summary>
        /// Shorthand extension method for converting enumerables into the arrays
        /// </summary>
        /// <typeparam name="TSource">The type of the source array.</typeparam>
        /// <typeparam name="TTarget">The type of the target array.</typeparam>
        /// <param name="self">The collection to convert.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>target array instance</returns>
        public static TTarget[] ToArray<TSource, TTarget>(this IEnumerable<TSource> source, Func<TSource, TTarget> converter)
        {
            //Guard.ArgumentNotNull(() => source);
            //Guard.ArgumentNotNull(() => converter);

            return source.Select(converter).ToArray();
        }

        public static bool Exists<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            return source.Count(func) > 0;
        }

        public static IEnumerable<T> CastValid<T>(this IEnumerable source)
        {
            return source.Cast<object>().Where(o => o is T).Cast<T>();
        }

        public static bool HasItems(this IEnumerable source)
        {
            return source != null && source.GetEnumerator().MoveNext();
        }

        public static int GetCount(this IEnumerable source)
        {
            return source.AsQueryable().GetCount();
        }

        public static bool IsNullOrEmpty(this IEnumerable source)
        {
            return (source == null || !source.HasItems());
        }

        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> source)
        {
            return new ReadOnlyCollection<T>(source.ToList());
        }

        

        #endregion

     

    }
}
