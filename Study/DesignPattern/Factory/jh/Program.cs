using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Factory
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ObjectFactory objectFactory = new ObjectFactory();
            Object[] units;
            units = new Object[3];


            units[0] = objectFactory.CreateObject(eObjectType.Champion);
            units[1] = objectFactory.CreateObject(eObjectType.Building);
            units[2] = objectFactory.CreateObject(eObjectType.Monster);

            Console.WriteLine("<Before>");
            foreach (var unit in units)
            {
                unit.PrintInfo();

            }

            foreach (var unit in units)
            {
                unit.Update();

            }

            Console.WriteLine("<After>");
            foreach (var unit in units)
            {
                unit.PrintInfo();

            }
        }
    }
}
