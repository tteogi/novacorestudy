using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Sample
{
    //실제로 원하는 기능을 할수있는 구상클래스
    public class Circle : Shape
    {
        float radius = 0;

        //생성시 연결할 브릿지를 넣어주고 연결한다. -> base(renderer)
        public Circle(IRender renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        //연결한 브릿지에게 그려달라고 요청한다.
        public override void Draw()
        {
            renderer.RenderLine(radius);
        }
        //사용자 정의 함수
        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
}
