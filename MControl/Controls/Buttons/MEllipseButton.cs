/*****************************************************************************************************
文件名: MEllipseButton.cs
作  者: MHF
描  述: 当前类为自定义的椭圆圆形Button类
版  本: 0.1.0
日  期: 2021.2.6
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
using System.Windows.Forms;

namespace MControl.Controls.Buttons
{
    public partial class MEllipseButton : UserControl
    {
        public MEllipseButton()
        {
            InitializeComponent();

            //使用双缓冲解决快速刷新时闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        #region 字段
        string m_strText = "Button";
        Color m_ColorText = Color.Black;
        Color m_colorBack = Color.White;
        Font m_FontText = new Font("宋体", 12, FontStyle.Regular);
        Bitmap m_bitmap = null;                                                      //控件默认的样式
        Bitmap m_bitmapBack = null;                                                   //控件默认的样式
        bool m_bMouseDown = false;                                                    //鼠标是否按下
        int m_nMouseDown = 0;                       
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
                PaintBackImage();
                PaintImage();
            }
        }

        /// <summary>
        /// 获取或设置控件文本的颜色。
        /// </summary>
        /// <returns>
        /// 控件文本的颜色。
        /// </returns>
        [Category("自定义属性"),Description("设置控件文本的颜色。")]
        public Color TextColor
        {
            get
            {
                return m_ColorText;
            }
            set
            {
                m_ColorText = value;
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

        #endregion

        /// <summary>
        /// 绘制发光背景
        /// </summary>
        private void PaintBackImage()
        {

            m_bitmapBack = new Bitmap(this.Width, this.Height);                                          //创建画布
            Graphics l_graphics = Graphics.FromImage(m_bitmapBack);                                      //创建画图对象
            l_graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath graphicsPath = new GraphicsPath();
            int l_nHeight = this.Height;
            /*********************************** <绘制发光背景> **********************************************/
            graphicsPath.AddLine(l_nHeight / 2, 0, this.Width - l_nHeight / 2, 0);
            graphicsPath.AddArc(new RectangleF(this.Width - l_nHeight, 0, l_nHeight, l_nHeight), 270, 180);
            graphicsPath.AddLine(this.Width - l_nHeight / 2, l_nHeight, l_nHeight / 2, l_nHeight);
            graphicsPath.AddArc(new RectangleF(0, 0, l_nHeight, l_nHeight), 90, 180);

            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.CenterColor = Color.FromArgb(114, 230, 0);
            pathGradientBrush.CenterPoint = new PointF(this.Width / 2, this.Height / 2);
            pathGradientBrush.SurroundColors = new Color[] { Color.Transparent };
            pathGradientBrush.SetBlendTriangularShape(0.2f, 1f);
            l_graphics.FillPath(pathGradientBrush, graphicsPath);
            pathGradientBrush.Dispose();
            l_graphics.Dispose();
        }

        /// <summary>
        /// 重绘Button样式
        /// </summary>
        private void PaintImage()
        {
            m_bitmap = new Bitmap(this.Width, this.Height);                                          //创建画布
            Graphics l_graphics = Graphics.FromImage(m_bitmap);                                      //创建画图对象
            l_graphics.SmoothingMode = SmoothingMode.AntiAlias;                                      //抗锯齿
            GraphicsPath graphicsPath = new GraphicsPath();
            int l_nHeight = this.Height;

            /*********************************** <绘制Button主体> **********************************************/
            graphicsPath = new GraphicsPath();
            int l_nDiff = this.Height / 5;
            graphicsPath.AddLine(l_nHeight / 2 + l_nDiff, l_nDiff, this.Width - l_nHeight / 2 - l_nDiff, l_nDiff);
            graphicsPath.AddArc(new RectangleF(this.Width - l_nHeight, l_nDiff, l_nHeight - l_nDiff * 2, l_nHeight - l_nDiff * 2), 270, 180);
            graphicsPath.AddLine(this.Width - l_nHeight, l_nHeight - l_nDiff, l_nHeight / 2 + l_nDiff, l_nHeight - l_nDiff);
            graphicsPath.AddArc(new RectangleF(l_nDiff * 2, l_nDiff, l_nHeight - l_nDiff * 2, l_nHeight - l_nDiff * 2), 90, 180);
            l_graphics.FillPath(new SolidBrush(m_colorBack), graphicsPath);

            /*********************************** <绘制Button阴影> **********************************************/
            LinearGradientBrush l_lgp = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(150,255,255,255), Color.FromArgb(150, 1, 1, 1), 85);
            l_lgp.SetSigmaBellShape(1f);
            l_graphics.FillPath(l_lgp, graphicsPath);
            graphicsPath.Dispose();

            /*********************************** <绘制Text> **********************************************/
            SizeF l_sizeF = l_graphics.MeasureString(m_strText, m_FontText);                            //计算文本的宽高
            Color l_colorText = m_bMouseDown ? m_colorBack : m_ColorText;
            l_graphics.DrawString(m_strText, m_FontText, new SolidBrush(l_colorText), new PointF((this.Width - l_sizeF.Width) / 2, (this.Height - l_sizeF.Height) / 2));

            l_graphics.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(m_bitmapBack == null || m_bitmap == null)
            {
                PaintBackImage();
                PaintImage();
            }
            e.Graphics.DrawImage(m_bitmapBack, new PointF(0,0));
            e.Graphics.DrawImage(m_bitmap, new PointF(0,0));
        }

        /// <summary>
        /// 按键按下
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            m_bMouseDown = true;
            PaintImage();
            this.Refresh();
        }

        /// <summary>
        /// 按键释放
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            m_bMouseDown = false;
            PaintImage();
            this.Refresh();
        }

        /// <summary>
        /// 固定长宽比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MEllipseButton_SizeChanged(object sender, EventArgs e)
        {
            this.Width = this.Height * 3;
            PaintBackImage();
            PaintImage();
        }
    }
}
