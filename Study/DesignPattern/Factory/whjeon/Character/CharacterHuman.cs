using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class CharacterHuman : ICharacter
    {
        public Character Make()
        {
            return new Character()
            {
                Ascend = 0,
                Exp = 0,
                IsLocked = false,
                Index = 999,
                Time = DateTime.Now,
                WeaponUid = 999
            };
        }
    }
}
