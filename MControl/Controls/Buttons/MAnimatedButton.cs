/*****************************************************************************************************
文件名: MAnimatedButton.cs
作  者: MHF
描  述: 当前类为自定义的多样式动态button控件
版  本: 0.1.0
日  期: 2021.2.28
功  能：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MControl.Controls.Buttons
{
    [DefaultEvent("Click")]
    public partial class MAnimatedButton : UserControl
    {
        public MAnimatedButton()
        {
            InitializeComponent();

            //使用双缓冲解决快速刷新时闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
           /* m_timerAnimated.Interval = 10;
            m_timerAnimated.Elapsed += Timer_Elapsed;*/

        }

        #region 字段
        Bitmap m_bitmap = null;                                                       //控件默认的样式
        Bitmap m_bitmapAnimated = null;                                               //控件动画的样式
        int m_nBorderRadius = 10;                                                     //控件圆角半径
        Color m_ColorBack = Color.Red;                                                //控件背景色
        Color m_ColorText = Color.Black;                                              //文本颜色
        Font m_FontText = new Font("宋体", 12, FontStyle.Regular);
        string m_strText = "Button";                                                  //控件文本
        System.Timers.Timer m_timerAnimated = new System.Timers.Timer();                                           //动画定时器
        private System.Threading.Timer timerClose;
        bool m_bMouseState = false;                                                   //鼠标状态 false为进入，True为离开
        int m_nLineLen = 0;                                                           //动态线条长度
        #endregion


        #region 属性

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
                PaintImage();
            }
        }

        /// <summary>
        ///  获取或设置控件的文本字体。
        /// </summary>
        /// <returns>
        /// 控件的文本字体。
        /// </returns>
        [Category("自定义属性"), Description("设置控件的文本字体。")]
        public Font FontText
        {
            get
            {
                return m_FontText;
            }
            set
            {
                m_FontText = value;
                PaintImage();
            }
        }

        /// <summary>
        ///  获取或设置窗体边框圆角半径。
        /// </summary>
        /// <returns>
        ///  窗体边框圆角半径
        /// </returns>
        [Category("自定义属性"), Description("设置窗体边框圆角直径。")]
        public int BorderRadius
        {
            get
            {
                return m_nBorderRadius * 2;
            }
            set
            {
                if(value / 2 > this.Width || value / 2  > this.Height)
                {
                    m_nBorderRadius = ((this.Width > this.Height) ? this.Height : this.Width );
                }
                else
                {
                    m_nBorderRadius = value / 2;
                }
            }
        }

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
                return m_ColorBack;
            }
            set
            {
                m_ColorBack = value;
                PaintImage();
            }
        }
        #endregion

        #region 方法

        private void PaintImage()
        {
            m_bitmap = new Bitmap(this.Width, this.Height);                                          //创建画布
            Graphics l_graphics = Graphics.FromImage(m_bitmap);                                      //创建画图对象
            //l_graphics.SmoothingMode = SmoothingMode.AntiAlias;                                      //抗锯齿
            //l_graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;   
            /*********************************** <绘制Button主体> **********************************************/
            GraphicsPath graphicsPath = new GraphicsPath();
            int x = 0;
            int y = 0;
            int w = Width - 1;
            int h = Height - 1;
            int a = 16;
            graphicsPath.AddArc(x, y, m_nBorderRadius, m_nBorderRadius, 180, 90);                                           //绘制左上角
            graphicsPath.AddArc(w - m_nBorderRadius, y, m_nBorderRadius, m_nBorderRadius, 270, 90);                         //绘制右上角
            graphicsPath.AddArc(w - m_nBorderRadius, h - m_nBorderRadius, m_nBorderRadius, m_nBorderRadius, 0, 90);         //绘制右下角
            graphicsPath.AddArc(x, h - m_nBorderRadius, m_nBorderRadius, m_nBorderRadius, 90, 90);                          //绘制左下角
            graphicsPath.CloseAllFigures();
            l_graphics.FillPath(new SolidBrush(m_ColorBack), graphicsPath);

            /*********************************** <绘制Button文本> **********************************************/
            SizeF l_sizeF = l_graphics.MeasureString(m_strText, m_FontText);                            //计算文本的宽高
            l_graphics.DrawString(m_strText, m_FontText, new SolidBrush(m_ColorText), new PointF((this.Width - l_sizeF.Width) / 2, (this.Height - l_sizeF.Height) / 2));
            l_graphics.Dispose();

        }

        private void Timer_Elapsed(object sender)
        {

            //Console.WriteLine(DateTime.Now.ToString("ss:fff"));

            if (m_bMouseState)
            {
                if (m_nLineLen <= 0)
                {
                    timerClose.Dispose();
                    //m_timerAnimated.Enabled = false;
            Console.WriteLine("停止2  " + DateTime.Now.ToString("ss:fff"));
                    return;
                }
                m_nLineLen -= this.Width / 10;
            }
            else
            {
                if (m_nLineLen >= this.Width)
                {
                    timerClose.Dispose();
                    //m_timerAnimated.Enabled = false;
            Console.WriteLine("停止1  " + DateTime.Now.ToString("ss:fff"));
                    return;
                }
                m_nLineLen += this.Width / 10;
            }
/*           this.Invoke(new Action(() =>
            {
            Invalidate();
                Update();
            }));*/
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            m_bMouseState = false;
            timerClose = new System.Threading.Timer(new TimerCallback(Timer_Elapsed), this, 0, 1);
/*            m_timerAnimated.Start();
            m_timerAnimated.Enabled = true;*/
            Console.WriteLine("开始1  " + DateTime.Now.ToString("ss:fff"));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            m_bMouseState = true;
            timerClose = new System.Threading.Timer(new TimerCallback(Timer_Elapsed), this, 0, 1);
            Console.WriteLine("开始2  " + DateTime.Now.ToString("ss:fff"));
            /*            m_bMouseState = true;
                        m_timerAnimated.Enabled = true;*/
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_bitmap == null)
            {
                PaintImage();
            }
            e.Graphics.DrawImage(m_bitmap, new PointF(0, 0));
/*            if(m_bitmapAnimated != null)
            {
                e.Graphics.DrawImage(m_bitmapAnimated, new PointF(0, 0));
            }*/
            Pen l_pen = new Pen(Color.DodgerBlue, 3f);
            e.Graphics.DrawLine(l_pen, 0, this.Height - 3, m_nLineLen,this.Height - 3);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            BorderRadius = BorderRadius;
            PaintImage();
        }
        #endregion
    }
}
