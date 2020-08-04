using DesignPattern.SwitchCase.dy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Prototype.dy
{
    public static class PrototypeFactory
    {
        static Dictionary<string, WeaponPrototype> _weapons;

        static PrototypeFactory()
        {

        }

        public static WeaponPrototype GetWeapon(string parent)
        {
            var weapon = (WeaponPrototype)_weapons[parent].Clone();
            return weapon;
        }
    }
}