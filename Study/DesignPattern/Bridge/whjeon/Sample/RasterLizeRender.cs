using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Bridge.whjeon.Sample
{
    //픽셀 방식으로 그리는 브릿지
    class RasterLizeRender : IRender
    {
        public void RenderLine(float radius)
        {
            Console.WriteLine("PixelLine => radius - {0}", radius);
        }
    }
}
