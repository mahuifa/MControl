/*****************************************************************************************************
文件名: MPlotTool.cs
作  者: MHF
描  述: 绘图工具类
版  本: 0.1.0
日  期: 2021.1.16
功  能：
*****************************************************************************************************/

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
            g.SmoothingMode = SmoothingMode.AntiAlias;                                  //设置后可抗锯齿，但是绘图下方会出现一条细小的白线
            g.InterpolationMode = InterpolationMode.High;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        }
    }
}
