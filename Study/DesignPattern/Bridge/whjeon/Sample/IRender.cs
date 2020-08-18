using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Sample
{
    //브릿지 인터페이스
    public interface IRender
    {
        //브릿지로 연결할 기능 정의
        void RenderLine(float radius);
    }
}
