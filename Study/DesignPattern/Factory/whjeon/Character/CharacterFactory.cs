using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class CharacterFactory : IFactory
    {
        ICharacter _character;

        Goods IFactory.Make(GoodsType type)
        {
            switch (type)
            {
                case GoodsType.GameAsset:
                case GoodsType.Weapon:
                case GoodsType.BattleItem:
                    _character = null;
                    break;
                case GoodsType.GameTicket:
                    _character = new CharacterHuman();
                    break;
                case GoodsType.Character:
                    _character = new CharacterMonster();
                    break;
            }

            if (_character == null)
            {
                Console.WriteLine("Character isnt't Maked");
                return null;
            }
            Goods outGoods = _character.Make();
            outGoods.BaseType = typeof(Character);
            return outGoods;
        }
    }
}
