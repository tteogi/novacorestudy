using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    public interface IFactory
    {
        Goods Make(GoodsType type);
    }
}
