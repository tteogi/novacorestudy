using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Adapter.whjeon
{
    public interface IAdapterReqRes
    {
        public ushort GetSlot() => default(ushort);

        public int GetSkipCost() => default(int);
    }
}
