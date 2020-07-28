using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class Program
    {
        static void CheckBaseType(Goods good)
        {
            if (good.BaseType == typeof(Reward))
            {
                Reward reward = (Reward)good;
                Console.WriteLine(reward.ToString());

            }
            else if (good.BaseType == typeof(Character))
            {
                Character character = (Character)good;
                Console.WriteLine(character.ToString());
            }
        }

        static void Main(string[] args)
        {
            Factory<RewardFactory> rewardFactory = new Factory<RewardFactory>();
            Goods good = rewardFactory.Make(GoodsType.Character);
            CheckBaseType(good);

            Factory<CharacterFactory> characterFactory = new Factory<CharacterFactory>();
            good = characterFactory.Make(GoodsType.Character);
            CheckBaseType(good);
        }
    }
}
