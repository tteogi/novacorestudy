using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class RewardGameTicket : IReward
    {
        public Reward Make()
        {
            return new Reward()
            {
                Name = "Reward_GameTicket"
            };
        }
    }
}
