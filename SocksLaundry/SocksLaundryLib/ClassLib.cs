using System;
using System.Collections.Generic;
using System.Linq;

namespace SocksLaundryLib
{
    public class ClassLib
    {

        //Do not delete or edit this method, you can only modify the block
        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            int pair_count = 0;

            // get pairs count already in C


            HashSet<int> distinct_vals = new HashSet<int>(cleanPile);
            var remaining = new List<int>();

            foreach (var v in distinct_vals)
            {
                if (cleanPile.Count(c => c == v) % 2 == 0)
                {
                    pair_count += Convert.ToInt32(cleanPile.Count(c => c == v) / 2);
                }
                else
                {
                    pair_count += Convert.ToInt32(cleanPile.Count(c => c == v) / 2);
                    remaining.Add(v);
                }
            }

            if (noOfWashes == 0)
            {
                return pair_count;
            }

            var lr = remaining.Count;

            foreach (var i in EnumerableUtilities.RangePython(lr - 1, -1, -1))
            {
                if (dirtyPile.Count(c => c == remaining[i]) > 0)
                {

                    var index = Array.FindIndex(dirtyPile, row => row == remaining[i]);
                    dirtyPile = dirtyPile.Where((d, idx) => idx != index).ToArray();

                    pair_count += 1;
                    noOfWashes -= 1;
                    if (noOfWashes == 0)
                    {
                        return pair_count;
                    }
                }
            }
            distinct_vals = new HashSet<int>(dirtyPile);


            foreach (var v in distinct_vals)
            {
                var matching_pairs = dirtyPile.Count(c => c == v) / 2;
                //var sequence = Enumerable.Range(matching_pairs,0);
                foreach (var i in Enumerable.Range(0, matching_pairs))
                {
                    noOfWashes -= 1;
                    if (noOfWashes == 0) return pair_count;
                    pair_count += 1;
                    noOfWashes -= 1;
                    if (noOfWashes == 0) return pair_count;
                }
            }
            return pair_count;
        }
        public static class EnumerableUtilities
        {
            public static IEnumerable<int> RangePython(int start, int stop, int step = 1)
            {
                if (step == 0)
                    throw new ArgumentException("Parameter step cannot equal zero.");

                if (start < stop && step > 0)
                {
                    for (var i = start; i < stop; i += step)
                    {
                        yield return i;
                    }
                }
                else if (start > stop && step < 0)
                {
                    for (var i = start; i > stop; i += step)
                    {
                        yield return i;
                    }
                }
            }

            public static IEnumerable<int> RangePython(int stop)
            {
                return RangePython(0, stop);
            }
        }

      
        /**
         * You can create various helper methods
         * */
    }
}
