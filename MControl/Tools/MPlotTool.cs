using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace MControl.Tools
{
    public static class MPlotTool
    {

        /// <summary>
        /// 设置使用高质量绘图
        /// </summary>
        /// <param name="g"></param>
        public static void SetDrawhigh(this Graphics g)
        {
           // g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.High;
            //g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        }
    }
}
