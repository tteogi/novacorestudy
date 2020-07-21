using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whjeon
{
    class RewardGameTicket : Reward, IReward
    {
        public Reward Make()
        {
            return new Reward()
            {
                Name = "GameTicket"
            };
        }
    }
}
