using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Factory
{
    public enum eObjectType
    {
        Champion = 1,
        Building = 2,
        Monster = 3
    }
    public class ObjectFactory
    {
        public ObjectFactory()
        {

        }

        public Object CreateObject(eObjectType type)
        {
            Object obj = null;
            switch (type)
            {
                case eObjectType.Building:
                    obj = new Building(100, new Position(0, 0, 0));
                    break;
                case eObjectType.Champion:
                    obj = (new Champion.Builder()).SetHp(50).SetPosition(new Position(0, 0, 0)).CreateChampion();
                    break;
                case eObjectType.Monster:
                    obj = new Monster(150, new Position(0, 0, 0));
                    break;
            }
            return obj;
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position( int x, int y, int z )
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class Object
    {
        private string _type { get; }
        private int _hp { get; set; }
        protected Position _pos { get; set; }

        public Object(string type, int hp, Position pos)
        {
            _type = type;
            _hp = hp;
            _pos = pos;
        }

        public void PrintInfo()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(_type);
            Console.WriteLine("체력 : " + _hp);
            Console.WriteLine("위치 : (" + _pos.X + ',' + _pos.Y + ',' + _pos.Z + ")");
            Console.WriteLine("----------------------");
        }

        public void Update()
        {
            Move();
        }

        public virtual void Move()
        {

        }
    }

    public class Champion : Object
    {
        public Champion( int hp, Position pos ) : base("챔피언", hp, pos)
        {
        }

        public override void Move()
        {
            _pos.X += 1;
        }

        public class Builder
        {
            private int _hp { get; set; }
            private Position _pos { get; set; }

            public Builder()
            {

            }

            public Builder SetHp(int hp)
            {
                _hp = hp;
                return this;
            }

            public Builder SetPosition(Position pos)
            {
                _pos = pos;
                return this;
            }

            public Champion CreateChampion()
            {
                return new Champion(_hp, _pos);
            }
        }
    }

    public class Building : Object
    {
        public Building(int hp, Position pos) : base("건물", hp, pos)
        {
        }

        public override void Move()
        {
            _pos.Y += 1;
        }
    }

    public class Monster : Object
    {
        public Monster(int hp, Position pos) : base("몬스터", hp, pos)
        {
        }

        public override void Move()
        {
            _pos.Z += 1;
        }
    }
}
