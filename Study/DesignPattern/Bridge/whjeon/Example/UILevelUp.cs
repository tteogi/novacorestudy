using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Example
{
    public class UILevelUp : IUIRefresh
    {
        public IRefresh Bridge { get; set; }

        //example Field
        //[SerializeField] Button buttonClose, buttonLevelUp;

        public void SetRefreshBridge<T>(T t) where T : IRefresh
        {
            Bridge = t;
        }

        public void UIRefresh(object value)
        {
            if (Bridge == null)
                return;
            Bridge.Refresh(value);
            Bridge = null;
        }
    }
}
