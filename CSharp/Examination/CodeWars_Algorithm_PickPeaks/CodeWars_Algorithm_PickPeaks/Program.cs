using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars_Algorithm_PickPeaks
{
    class Program
    {
        public enum SEB
        {
            SMALLER,
            EQUAL,
            BIGGER
        };
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            if (arr.Length <= 1)
            {
                new Dictionary<string, List<int>>()
                {
                    ["pos"] = new List<int>(),
                    ["peaks"] = new List<int>()
                };
            }
            SEB[] map = new SEB[arr.Length - 1];
            int index = 0;
            var queueTime = arr.Aggregate((p, n) =>
            {
                if (p < n)
                    map[index] = SEB.SMALLER;
                else if (p == n)
                    map[index] = SEB.EQUAL;
                else
                    map[index] = SEB.BIGGER;
                index++;
                return n;
            });

            List<int> pos = new List<int>();
            List<int> peaks = new List<int>();
            index = 0;
            var mlist = map.ToList();
            var mapTrue = map.Aggregate((p, n) =>
            {
                int indexNum = index + 1;
                if (p == SEB.SMALLER && n == SEB.BIGGER)// && (l.LastIndexOf(SEB.SMALLER) > index || l.LastIndexOf(SEB.BIGGER)>index)
                {
                    pos.Add(indexNum);
                    peaks.Add(arr[indexNum]);
                }
                if (p == SEB.SMALLER && n == SEB.EQUAL)
                {
                    var slice = mlist.GetRange(indexNum, mlist.Count() - indexNum);

                    var bindex = slice.IndexOf(SEB.BIGGER);//-1
                    var sindex = slice.IndexOf(SEB.SMALLER);//0

                    if (bindex != -1)
                    {
                        if (bindex < sindex)
                        {
                            pos.Add(indexNum);
                            peaks.Add(arr[indexNum]);
                        }
                        else
                        {
                            if (sindex == -1)
                            {
                                pos.Add(indexNum);
                                peaks.Add(arr[indexNum]);
                            }
                        }
                    }
                }
                index++;
                return n;
            });

            dict.Add("pos", pos);
            dict.Add("peaks", peaks);
            return dict;
        }
        private static int[][] array =
        {
                new int[]{1,2,3,6,4,1,2,3,2,1},
                new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
                new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
                new int[]{2,1,3,1,2,2,2,2,1},
                new int[]{2,1,3,1,2,2,2,2},
                new int[]{ 17, 8, 13, 13, 14, 3, -5, -4, 16, 15, 5, 0, 4, 19, -3, 8, -5, 12, 5, 1, 8, 3, 19, 15, -5 },
                new int[]{ -1, 4, 2, -5, 10, 6, 15, 8, 8, 16, 16, 17 },
                new int[]{ 1,2,2}
            };
        static void Main(string[] args)
        {
            foreach (var item in array)
            {
                var dict = GetPeaks(item);
                Action<int> act = (n) => { Console.Write(n); Console.Write(' '); };
                dict["pos"].ForEach(act);
                Console.WriteLine();
                dict["peaks"].ForEach(act);
                Console.WriteLine();
                Console.WriteLine("----------");

            }


            Console.Read();
        }
    }
}
