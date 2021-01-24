/*****************************************************************************************************
文件名: MRoundButtons.cs
作  者: MHF
描  述: 当前类为自定义的圆形Button类
版  本: 0.1.0
日  期: 2021.1.23
功  能：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MControl.Tools;
namespace MControl.Controls.Buttons
{
    public class MRoundButton: UserControl
    {
        public MRoundButton()
        {
            this.Width = 50;
            this.Height = 50;

            //使用双缓冲解决快速刷新时闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);


            m_toolTip.AutoPopDelay = 2000;
            m_toolTip.InitialDelay = 500;
            m_toolTip.ReshowDelay = 2000;
            m_toolTip.ShowAlways = true;
            m_toolTip.SetToolTip(this, m_strText);
        }

        #region 字段
        MToolTip m_toolTip = new MToolTip();
        Color m_colorBack = Color.FromArgb(255, 0, 114, 230);                      //按键背景色
        string m_strText = "MRoundButton";                                         //Button文本
        int m_nButSize = 40;                                                       //按键直径
        int m_nFrameWide = 5;                                                      //边框宽度

        Bitmap m_bitmap = null;                                                   //控件默认的样式
        Bitmap m_bitmapCilck = null;                                              //控件点击的样式

        #endregion

        #region 属性

        /// <summary>
        ///  获取或设置控件的背景色。
        /// </summary>
        /// <returns>
        /// 控件背景色
        /// </returns>
        [Category("自定义属性"), Description("设置控件的背景色。")]
        public virtual Color MBackColor
        { 
            get
            {
                return m_colorBack;
            }
            set
            {
                m_colorBack = value;
                PaintImage();
            }
        }

        /// <summary>
        ///  获取或设置控件的文本。
        /// </summary>
        /// <returns>
        /// 控件的文本。
        /// </returns>
        [Category("自定义属性"), Description("设置控件的文本。")]
        public string MText
        {
            get
            {
                return m_strText;
            }
            set
            {
                m_strText = value;
                m_toolTip.SetToolTip(this, m_strText);
            }
        }
        #endregion

        #region 绘制图片

        /// <summary>
        /// 重绘Button样式
        /// </summary>
        private void PaintImage()
        {
            m_bitmap = new Bitmap(this.Width, this.Height);                                          //创建画布
            Graphics l_graphics = Graphics.FromImage(m_bitmap);                                      //创建画图对象
            l_graphics.SmoothingMode = SmoothingMode.AntiAlias;                                      //抗锯齿

            //画阴影
            GraphicsPath l_gp = new GraphicsPath();
            l_gp.AddEllipse(new RectangleF(m_nFrameWide, m_nFrameWide, m_nButSize, m_nButSize));
            PathGradientBrush l_pb = new PathGradientBrush(l_gp);
            l_pb.CenterColor = Color.FromArgb(255, 38, 38, 38);
            l_pb.CenterPoint = new PointF(m_nButSize / 4, m_nButSize / 4);
            l_pb.SurroundColors = new Color[] { Color.Transparent }; ;
            l_pb.SetSigmaBellShape(0.15f, 1f);
            l_graphics.FillPath(l_pb, l_gp);

            //画按键主体
            int l_frameWidth = m_nButSize - m_nFrameWide ;
            SolidBrush l_brush = new SolidBrush(m_colorBack);              
            l_graphics.FillEllipse(l_brush, new RectangleF(m_nFrameWide / 2, m_nFrameWide / 2, l_frameWidth, l_frameWidth));

            //画边框亮面
            l_gp = new GraphicsPath();
            l_gp.AddArc(new RectangleF(0, 0, m_nButSize, m_nButSize), 0, 360);
            l_gp.AddArc(new RectangleF(m_nFrameWide / 2, m_nFrameWide/2, l_frameWidth, l_frameWidth), 0, 360);
            LinearGradientBrush l_lgp = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 242, 242, 242), Color.FromArgb(255, 51, 51, 51), LinearGradientMode.ForwardDiagonal);
            l_lgp.SetSigmaBellShape(0.7f);
            l_graphics.FillPath(l_lgp, l_gp);

            //画边阴影面
            l_gp = new GraphicsPath();
            l_gp.AddArc(new RectangleF(m_nFrameWide / 2, m_nFrameWide/2, m_nButSize- m_nFrameWide, m_nButSize - m_nFrameWide), 0, 360);
            l_gp.AddArc(new RectangleF(m_nFrameWide, m_nFrameWide, m_nButSize - m_nFrameWide * 2, m_nButSize - m_nFrameWide * 2), 0, 360);
            l_lgp = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 51, 51, 51), Color.FromArgb(255, 242, 242, 242), LinearGradientMode.ForwardDiagonal);
            l_graphics.FillPath(l_lgp, l_gp);

            l_graphics.Dispose();
        }

        /// <summary>
        /// 与控件主体样式分离，绘制Button点击样式
        /// </summary>
        private void PaintClick(bool p_bCilck)
        {
            m_bitmapCilck = new Bitmap(this.Width, this.Height);                                          //创建画布
            Graphics l_graphics = Graphics.FromImage(m_bitmapCilck);                                      //创建画图对象
            l_graphics.SmoothingMode = SmoothingMode.AntiAlias;                                           //抗锯齿

            Rectangle l_recFrame = new Rectangle(m_nFrameWide, m_nFrameWide, m_nButSize, m_nButSize);     
            GraphicsPath l_gp = new GraphicsPath();
            l_recFrame = new Rectangle(m_nFrameWide, m_nFrameWide, m_nButSize - m_nFrameWide * 2, m_nButSize - m_nFrameWide * 2);           //圆的大小
            l_gp.AddEllipse(l_recFrame);
            LinearGradientBrush l_Brush;
            if (p_bCilck)
            {
                l_Brush = new LinearGradientBrush(l_recFrame, Color.FromArgb(250, 1, 1, 1), Color.Transparent, LinearGradientMode.ForwardDiagonal);
            }
            else
            {
                l_Brush = new LinearGradientBrush(l_recFrame, Color.Transparent, Color.FromArgb(250, 1, 1, 1), LinearGradientMode.ForwardDiagonal);
            }
            l_graphics.FillPath(l_Brush, l_gp);
            l_graphics.Dispose();
        }

        #endregion

        #region 事件
        /// <summary>
        /// 重绘Button
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Color.Transparent;                                 //禁止修改背景色
            e.Graphics.DrawImage(m_bitmap, new PointF(0, 0));
            e.Graphics.DrawImage(m_bitmapCilck, new PointF(0, 0));
            //Graphics l_graphics = this.CreateGraphics();                      //不能使用this获取Graphics
            //l_graphics.Dispose();                                             //使用双缓冲时不能释放，否则会报错
        }


        /// <summary>
        /// 按键按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            PaintClick(true);
            this.Refresh();
        }

        /// <summary>
        /// 按键释放
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            PaintClick(false);
            this.Refresh();
        }

        /// <summary>
        /// 固定长宽比
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Height = this.Width;
            m_nFrameWide = this.Width / 10;
            m_nButSize = this.Width - m_nFrameWide;
            PaintImage();
            PaintClick(false);
        }

        #endregion
    }
}
