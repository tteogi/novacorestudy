using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Sample
{
    //브릿지패턴의 브릿지를 사용할수있는 구상클래스이다.(그리는 동작을 인터페이스화 한다)
    public abstract class Shape
    {
        //브릿지 구상클래스가 아닌 상위 인터페이스를 사용하여 커플링을 줄인다.
        protected IRender renderer;

        //사용하고자 하는 브릿지를 연결해준다.
        public Shape(IRender renderer)
        {
            this.renderer = renderer;
        }

        //그리는 함수는 구상클래스의 알고리즘을 사용한다.
        public abstract void Draw();
        //사용자 정의 함수
        public abstract void Resize(float factor);
    }
}
