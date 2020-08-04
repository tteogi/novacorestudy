using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Prototype.dy
{
    public class WeaponConfig
    {
        public string Name;
        public string Parent;
        public string Spell;
        public int MinAttack;
        public int MaxAttack;
    }


    public class Sample
    {
        public void MainMethod()
        {
            var weaponConfigs = LoadData();
            foreach(var config in weaponConfigs)
            {
                var bow = PrototypeFactory.GetWeapon(config.Parent) as Bow;
                if(bow != null)
                {
                    bow.MinAttack = config.MinAttack != 0 ? config.MinAttack : bow.MinAttack;
                    bow.MaxAttack = config.MaxAttack != 0 ? config.MaxAttack : bow.MaxAttack;
                    var magicBow = bow as MagicBow;
                    if (magicBow != null)
                        magicBow.Spell = config.Spell != null ? config.Spell : magicBow.Spell;
                }
            }
        }

        public WeaponConfig[] LoadData()
        {
            // todo data load
            return new WeaponConfig[3];
        }
    }
}
