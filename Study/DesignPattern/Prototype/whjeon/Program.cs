using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Prototype.whjeon
{
    class Program
    {        
        public static bool CheckIsDeepCopy(List<User> from, List<User> to)
        {
            string name = from[0].Name;
            from[0].Name = "asdf";
            bool result = from[0].Name != to[0].Name;
            from[0].Name = name;

            return result;
        }


        static void Main(string[] args)
        {
            CacheRanker cache = new CacheRanker();

            DateTime from = DateTime.Now;
            List<User> ranker_1 = cache.GetYesterDayRanker();
            DateTime to = DateTime.Now;
            Console.WriteLine("TotalSeconds - {0}", (to - from).TotalSeconds);

            from = DateTime.Now;
            List<User> ranker_2 = cache.GetYesterDayRanker();
            to = DateTime.Now;
            Console.WriteLine("TotalSeconds - {0}", (to - from).TotalSeconds);


            var isDeepCopy = CheckIsDeepCopy(ranker_1, ranker_2);
            Console.WriteLine($"IsDeepCopy? {isDeepCopy}");
        }
    }
}
