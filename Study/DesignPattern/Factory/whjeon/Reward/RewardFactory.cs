using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class RewardFactory : IFactory
    {
        IReward _reward;

        Goods IFactory.Make(GoodsType type)
        {
            switch (type)
            {
                case GoodsType.GameAsset:
                case GoodsType.Weapon:
                case GoodsType.BattleItem:
                    _reward = null;
                    break;
                case GoodsType.GameTicket:
                    _reward = new RewardGameTicket();
                    break;
                case GoodsType.Character:
                    _reward = new RewardCharacter();
                    break;
            }

            if (_reward == null)
            {
                Console.WriteLine("Reward isnt't Maked");
                return null;
            }
            Goods outGoods = _reward.Make();
            outGoods.BaseType = typeof(Reward);
            return outGoods;
        }
    }
}
