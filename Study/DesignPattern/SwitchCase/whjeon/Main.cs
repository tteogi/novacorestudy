using System;


namespace whjeon
{
    public enum RewardType
    {
        GameAsset = 1,
        GameTicket = 2,
        Weapon = 3,
        BattleItem = 4,
        Character = 5,
    }

    class Main
    {
        public void Start() 
        {
            RewardFactory factory = null;
            Reward reward = null;

            factory = new RewardFactory(RewardType.Character);
            reward = factory.Make();
            if (reward != null)
                Console.WriteLine(reward.Name);

            factory = new RewardFactory(RewardType.GameTicket);
            reward = factory.Make();
            if (reward != null)
                Console.WriteLine(reward.Name);
        }
    }
}
