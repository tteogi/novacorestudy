using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_nong
{
    public class UnitBuilder
    {
        private string _nick;
        private string _weapon;
        private string _skin;

        public UnitBuilder()
        {

        }

        public UnitBuilder setNick(string nick)
        {
            _nick = nick;
            return this;
        }

        public UnitBuilder setWeapon(string weapon)
        {
            _weapon = weapon;
            return this;
        }

        public UnitBuilder setSkin(string skin)
        {
            _skin = skin;
            return this;
        }

        public void PrintAllEquip()
        {
            Console.WriteLine("이름 : " + _nick);
            Console.WriteLine("무기 : " + _weapon);
            Console.WriteLine("무기 : " + _skin);
        }
    }
}
