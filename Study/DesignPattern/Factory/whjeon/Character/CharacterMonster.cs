using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class CharacterMonster : ICharacter
    {
        public Character Make()
        {
            return new Character()
            {
                Ascend = 3,
                Exp = 0,
                IsLocked = false,
                Index = 11111,
                Time = DateTime.Now,
                WeaponUid = 11111
            };
        }
    }
}
