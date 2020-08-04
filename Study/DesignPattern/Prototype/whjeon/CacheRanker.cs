using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPattern.Prototype.whjeon
{
    public class CacheRanker
    {
        private Rank yeterdayRank = new Rank();

        private void GetDataFromDB()
        {
            string dir = "../../ranking.json";

            if (System.IO.File.Exists(dir))
            {
                string strJson = System.IO.File.ReadAllText(dir);

                Rank dbRank = JsonConvert.DeserializeObject<Rank>(strJson) as Rank;
                yeterdayRank = dbRank;
            }

            Thread.Sleep(2000);
        }

        public List<User> GetYesterDayRanker()
        {
            if (yeterdayRank.Ranker == null)
            {
                GetDataFromDB();
                return yeterdayRank.DeepCopy().Ranker;
            }
            else
            {
                return yeterdayRank.DeepCopy().Ranker;
            }
        }
    }
}
