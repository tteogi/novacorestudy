using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Example
{
    class RefreshExpBar : IRefresh
    {
        public void Refresh(object obj)
        {
            (int fromExp, int toExp) tuple = (ValueTuple<int, int>)obj;

            //UI갱신을 담당하는 이벤트에 넘겨준다.
            //UIRefreshExpEvent(fromexp,toExp);

            Console.WriteLine("fromExp:{0}, toExp:{1}", tuple.fromExp, tuple.toExp);
        }
    }
}
