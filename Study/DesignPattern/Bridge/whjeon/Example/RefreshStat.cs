using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Example
{
    class RefreshStat : IRefresh
    {
        public void Refresh(object obj)
        {
            int lv = (int)obj;
            //var levelUp = DataClient.GetCharLevelUp(lv);
            //var ascend = DataClient.GetCharAscend(characterData.Grade, characterInfo.Model.Ascend);            
            //int hp = StatUtils.GetStatValue(StatType.Hp, characterData.Hp, CharacterType.Character, levelUp, ascend, characterData.Grade, weaponInfo);
            //int atk = StatUtils.GetStatValue(StatType.Atk, characterData.Atk, CharacterType.Character, levelUp, ascend, characterData.Grade, weaponInfo);
            //int def = StatUtils.GetStatValue(StatType.Def, characterData.Def, CharacterType.Character, levelUp, ascend, characterData.Grade, weaponInfo);


            //UI갱신을 담당하는 이벤트에 넘겨준다.
            //UIRefreshStatEvent(hp,atk,def);

            Console.WriteLine("hp:{0}, atk:{1}, def:{2}", lv * 50, lv * 2, lv * 3);
        }
    }
}
