using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Adapter.whjeon
{
    public class Adapter : IAdapterReqRes
    {
        IAdapterReqRes req = null;

        public Adapter(IAdapterReqRes reqSlot)
        {
            req = reqSlot;
        }

        public ushort GetSlot() => req.GetSlot();

        public int GetSkipCost() => req.GetSkipCost();
    }
}
