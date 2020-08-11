using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Adapter.whjeon
{
    class Program
    {
        public static void Start() 
        {
            Request.CollectCrafting res1 = new Request.CollectCrafting() { Slot = 1 };
            Request.CollectProduction res2 = new Request.CollectProduction() { Slot = 2 };

            Console.WriteLine(new Adapter(res1).GetSlot());
            Console.WriteLine(new Adapter(res2).GetSlot());

            Request.SkipBuilding res3 = new Request.SkipBuilding() { Slot = 1, Cost = 1000 };
            Request.SkipCraftingTimer res4 = new Request.SkipCraftingTimer() { Slot = 2, CurrentSkipCost = 2000 };

            Console.WriteLine(new Adapter(res3).GetSkipCost());
            Console.WriteLine(new Adapter(res4).GetSkipCost());
        }
    }
}
