using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Example
{
    class Program
    {
        void Main() 
        {
            UILevelUp ui = new UILevelUp();

            int fromExp = 233; int toExp = 789;
            ui.SetRefreshBridge(new RefreshExpBar());
            ui.UIRefresh((fromExp, toExp));

            int lv = 10;
            ui.SetRefreshBridge(new RefreshStat());
            ui.UIRefresh(lv);

            ui.SetRefreshBridge(new RefreshSkillLv());
            ui.UIRefresh(lv);
        }
    }
}
