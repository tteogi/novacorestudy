using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_nong
{
    public class Unit
    {
        private string _nick { get; }
        private string _weapon { get; }
        private string _skin { get; }

        public Unit(string nick, string weapon, string skin)
        {
            _nick = nick;
            _weapon = weapon;
            _skin = skin;
        }

        public void PrintAllEquip()
        {
            Console.WriteLine("이름 : " + _nick);
            Console.WriteLine("무기 : " + _weapon);
            Console.WriteLine("무기 : " + _skin);
        }

        public class UnitBuilder
        {
            private static string _nick { get; set; }
            private static string _weapon { get; set; }
            private static string _skin { get; set; }

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

            public Unit build()
            {
                return new Unit(_nick, _skin, _weapon);
            }
        }


    }
}