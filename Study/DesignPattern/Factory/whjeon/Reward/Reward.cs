using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    class Reward : Goods
    {
        public int Type { get; set; }

        public int Index { get; set; }

        public long Id { get; set; }

        public int Amount { get; set; }

        public int Tier { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return "Reward" + Name;
        }
    }
}
