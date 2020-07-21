using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whjeon
{
    class RewardFactory
    {
        IReward _reward;

        public RewardFactory(RewardType type)
        {
            switch (type)
            {
                case RewardType.GameAsset:
                case RewardType.Weapon:
                case RewardType.BattleItem:
                    _reward = null;
                    break;
                case RewardType.GameTicket:
                    _reward = new RewardGameTicket();
                    break;
                case RewardType.Character:
                    _reward = new RewardCharacter();
                    break;
            }
        }

        public Reward Make()
        {
            if (_reward == null)
            {
                Console.WriteLine("Reward isnt't Maked");
                return null;
            }
            return _reward.Make();
        }
    }
}
