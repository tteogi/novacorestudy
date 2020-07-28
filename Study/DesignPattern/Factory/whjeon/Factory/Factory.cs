using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
    public class Factory<T> where T : IFactory, new()
    {
        T factory = new T();

        public Goods Make(GoodsType type)
        {
            return factory.Make(type);
        }
    }
}
