using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Utils
{
    public static class ListExtentions
    {
        /// <summary>
        /// Splits the list into multiple chunks with the a given maximum lengths.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to work with.</param>
        /// <param name="amounts">The maximum size for each separated chunk.</param>
        /// <param name="aggregateFunction"></param>
        /// <returns>The splitted list.</returns>
        public static IList<string> AggregateSublist(this List<string> list, Func<string, string, string> aggregateFunction)
        {
            var lists = new List<string>();
            var index = 0;
            while (index < list.Count)
            {
                lists.Add(list.GetRange(index, 2).Aggregate(aggregateFunction));
                index += 2;
            }

            return lists;
        }
    }
}