using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Example
{
    public interface IUIRefresh
    {
        IRefresh Bridge { get; set; }

        void UIRefresh(object value);
    }
}
