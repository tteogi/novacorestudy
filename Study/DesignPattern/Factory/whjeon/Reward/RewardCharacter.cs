using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class RewardCharacter : IReward
    {
        public Reward Make()
        {
            return new Reward()
            {
                Name = "Reward_Name"
            };
        }
    }
}
