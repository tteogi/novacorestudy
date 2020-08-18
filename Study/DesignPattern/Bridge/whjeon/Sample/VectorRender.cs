using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Sample
{
    //백터 방식으로 그리는 브릿지
    class VectorRenderer : IRender
    {
        public void RenderLine(float radius)
        {
            Console.WriteLine("VectorLine => radius - {0}", radius);
        }
    }
}
