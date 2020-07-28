using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Builder_nong
{
    class Program
    {

        static void Main(string[] args)
        {
            Unit[] units;
            units = new Unit[3];


            units[0] = new Unit.UnitBuilder().setWeapon("총").setNick("종훈의총잡이").setSkin("파란스킨").build();
            units[1] = new Unit.UnitBuilder().setWeapon("칼").setNick("종훈의칼").setSkin("초록스킨").build();
            units[2] = new Unit.UnitBuilder().setWeapon("망치").setNick("종훈의망치").setSkin("빨강스킨").build();

            foreach (var unit in units)
            {
                unit.PrintAllEquip();
            }
        }
    }
}