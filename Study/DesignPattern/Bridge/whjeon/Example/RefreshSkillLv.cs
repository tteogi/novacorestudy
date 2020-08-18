using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Example
{
    class RefreshSkillLv : IRefresh
    {
        public void Refresh(object obj)
        {
            int lv = (int)obj;

            //int skillLv = DataClient.GetCharLevelBonusSkillLv(lv);

            //UI갱신을 담당하는 이벤트에 넘겨준다.
            //UIRefreshSkillEvent(skillLv);

            Console.WriteLine("skillLv:{0}", lv + 1);
        }
    }
}
