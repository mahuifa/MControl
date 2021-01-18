/*****************************************************************************************************
文件名: MFormWithTitle.cs
作  者: MHF
描  述: 当前类为带标题栏的自定义窗口类
版  本: 0.1.0
日  期: 2021.1.14
功  能：1、窗口图标的设置、隐藏；
        2、标题显示在窗口左上角、居中显示；
        3、鼠标点击标题栏移动窗口；
        4、鼠标缩放窗口大小；
        5、设置标题字体
        6、设置窗体阴影
        7、设置窗体边框圆角半径
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MControl.Forms
{
    public partial class MFormWithTitle : Form
    {
        public MFormWithTitle()
        {
            InitializeComponent();
        }


        #region 窗体边框阴影设置
        #region 窗体边框阴影效果变量申明
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        #endregion

        bool m_ShowFormShadow = false;
        /// <summary>
        ///  获取或设置窗体传统是否显示阴影。
        /// </summary>
        /// <returns>
        /// 窗体传统是否显示阴影。
        /// </returns>
        [Category("自定义属性"), Description("设置窗体是否显示阴影。")]
        public bool ShowFormShadow
        {
            get
            {
                return m_ShowFormShadow;
            }
            set
            {
                m_ShowFormShadow = value;
               if(value)
               {
                    SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
               }
            }
        }

        #endregion

        #region 标题栏设置

        /// <summary>
        ///  获取或设置窗体的图标。
        /// </summary>
        /// <returns>
        /// System.Drawing.Icon，表示窗体的图标。
        /// </returns>
        [Category("自定义属性"), Description("设置窗体的图标。")]
        public new Icon Icon
        {
            get
            {
                return base.Icon;
            }
            set
            {
                base.Icon = value;
                Icon icon = value;
                MemoryStream mStream = new MemoryStream();
                icon.Save(mStream);
                Image image = Image.FromStream(mStream);
                Micon.Image = image;
            }
        }

        private bool g_bMiconVisible = true;                                       //不使用变量控制则会出现初始化时先初始化Title，后初始化icon，导致Micon被Title覆盖
        /// <summary>
        /// 获取或设置一个值，该值指示是否在窗体的标题栏中显示图标。
        /// </summary>
        /// <returns>
        /// 如果窗体在标题栏中显示图标，则为 true；否则为 false。 默认值为 true。
        /// </returns>
        [Category("自定义属性"), Description("设置一个值，该值指示是否在窗体的标题栏中显示图标。")]
        public new bool ShowIcon
        {
            get
            {
                return g_bMiconVisible;
            }
            set
            {
                g_bMiconVisible = value;
                Micon.Visible = value;
                UpdateTitle();
            }
        }

        /// <summary>
        /// 更改图标、标题后刷新标题位置
        /// </summary>
        private void UpdateTitle()
        {
            if (g_bMiconVisible)
            {
                if (m_TitlePosition)
                {
                    this.Title.Location = new Point(40, 10);
                }
                else
                {
                    this.Title.Location = new Point((this.Size.Width - Title.Size.Width) / 2, 10);
                }
            }
            else
            {
                if (m_TitlePosition)
                {
                    this.Title.Location = new Point(10, 10);
                }
                else
                {
                    this.Title.Location = new Point((this.Size.Width - Title.Size.Width) / 2, 10);
                }
            }
        }

        /// <summary>
        ///  获取或设置标题栏的背景色。
        /// </summary>
        /// <returns>
        ///  表示控件背景色的 System.Drawing.Color。 默认为 System.Drawing.SystemColors.ActiveCaption;
        ///  属性的值。
        /// </returns>
        [Category("自定义属性"), Description("设置标题栏颜色")]
        public Color TitleBarColor
        {
            get
            {
                return TitleBar.BackColor;
            }
            set
            {
                TitleBar.BackColor = value;
            }
        }

        /// <summary>
        /// 获取或设置窗口的标题。
        /// </summary>
        /// <returns>
        /// 窗口的标题。
        /// </returns>
        [Category("自定义属性"), Description("设置窗口的标题。")]
        public new string Text
        {
            get
            {
                return Title.Text;
            }
            set
            {
                Title.Text = value;
                base.Text = value;

                UpdateTitle();
            }
        }

        /// <summary>
        /// 获取或设置窗口标题的字体。
        /// </summary>
        /// <returns>
        /// 窗口的标题字体。
        /// </returns>
        [Category("自定义属性"), Description("设置窗口标题的字体。")]
        public Font TitleFont
        {
            get
            {
                return Title.Font;
            }
            set
            {
                Title.Font = value;
            }
        }

        private bool m_TitlePosition = true;                                      //保存标题位置
        /// <summary>
        /// 获取或设置窗口标题的位置。
        /// </summary>
        /// <returns>
        /// 返回true表示标题在标题栏左边，返回false表示标题在标题栏中间。
        /// </returns>
        [Category("自定义属性"), Description("设置窗口标题的位置。")]
        public bool TitlePosition
        {
            get
            {
                return m_TitlePosition;
            }
            set
            {
                m_TitlePosition = value;
                UpdateTitle();
            }
        }

        /// <summary>
        /// 窗口大小变化是保证标题居中显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormWithTitle_SizeChanged(object sender, EventArgs e)
        {
            if (!m_TitlePosition)
            {
                Title.Location = new Point((this.Size.Width - Title.Size.Width) / 2, 10);
            }
        }
        #endregion

        #region 按键高亮

        /// <summary>
        /// 鼠标进入控件后控件高亮
        /// </summary>
        /// <param name="p_Control"></param>
        private void ButHighlight(Control p_Control, Color p_color)
        {
            p_Control.BackColor = p_color;
        }

        /// <summary>
        /// 鼠标离开控件范围后还原控件颜色
        /// </summary>
        /// <param name="p_Control"></param>
        private void ButRestoreColor(Control p_Control)
        {
            p_Control.BackColor = TitleBar.BackColor;
        }

        private void ButClose_MouseEnter(object sender, EventArgs e)
        {
            ButHighlight(ButClose, Color.Silver);
        }

        private void ButClose_MouseLeave(object sender, EventArgs e)
        {
            ButRestoreColor(ButClose);
        }

        private void ButMaxmum_MouseEnter(object sender, EventArgs e)
        {
            ButHighlight(ButMaxmum, Color.Silver);
        }

        private void ButMaxmum_MouseLeave(object sender, EventArgs e)
        {
            ButRestoreColor(ButMaxmum);
        }

        private void ButMinmum_MouseEnter(object sender, EventArgs e)
        {
            ButHighlight(ButMinmum, Color.Silver);
        }

        private void ButMinmum_MouseLeave(object sender, EventArgs e)
        {
            ButRestoreColor(ButMinmum);
        }

        #endregion

        #region 窗口缩放

        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;      //左边界
        const int HTRIGHT = 11;     //右边界
        const int HTTOP = 12;       //上边界
        const int HTTOPLEFT = 13;   //左上角
        const int HTTOPRIGHT = 14;  //右上角
        const int HTBOTTOM = 15;    //下边界
        const int HTBOTTOMLEFT = 0x10;    //左下角
        const int HTBOTTOMRIGHT = 17;     //右下角
        /// <summary>
        /// 窗口大小缩放
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        #region 窗口移动
        private Point m_PointMouse;                   //保存鼠标移动前的坐标
        /// <summary>
        /// 鼠标在标题栏按下后开始监听鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            Point l_Point = this.Location;
            this.Location = new Point(l_Point.X + (MousePosition.X - m_PointMouse.X),                                     //设置窗口位置
                l_Point.Y + (MousePosition.Y - m_PointMouse.Y));
            m_PointMouse = MousePosition;                                                                                 //记录当前鼠标坐标
        }

        /// <summary>
        /// 鼠标移动事件，获取鼠标当前坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_PointMouse = MousePosition;
                this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);          //添加鼠标移动监听事件
            }
        }

        /// <summary>
        /// 鼠标按键释放后停止监听鼠标坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.TitleBar.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);              //释放鼠标移动监听事件
        }

        #endregion

        #region 窗口按键功能
        private void ButMinmum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButMinmum_MouseDown(object sender, MouseEventArgs e)
        {
            ButHighlight(ButMinmum, Color.Gray);
        }

        private void ButMinmum_MouseUp(object sender, MouseEventArgs e)
        {
            ButRestoreColor(ButMinmum);
        }

        private void ButMaxmum_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.ButMaxmum.Image = global::MControl.Resource1.RestoreBlack;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.ButMaxmum.Image = global::MControl.Resource1.MaximizeBlack;
            }
        }

        private void ButMaxmum_MouseDown(object sender, MouseEventArgs e)
        {
            ButHighlight(ButMaxmum, Color.Gray);
        }

        private void ButMaxmum_MouseUp(object sender, MouseEventArgs e)
        {
            ButRestoreColor(ButMaxmum);
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButClose_MouseDown(object sender, MouseEventArgs e)
        {
            ButHighlight(ButClose, Color.Gray);
        }

        private void ButClose_MouseUp(object sender, MouseEventArgs e)
        {
            ButRestoreColor(ButClose);
        }

        /// <summary>
        /// 双击标题栏最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_DoubleClick(object sender, EventArgs e)
        {
            ButMaxmum_Click(null, null);
        }
        #endregion

        #region 设置窗体边框圆角半径

        int m_nBorderRadius = 10;
        /// <summary>
        ///  获取或设置窗体边框圆角半径。
        /// </summary>
        /// <returns>
        ///  窗体边框圆角半径
        /// </returns>
        [Category("自定义属性"), Description("设置窗体边框圆角半径。")]
        public int BorderRadius 
        {
            get
            {
                return m_nBorderRadius * 2;
            }
            set
            {
                m_nBorderRadius = value / 2;
            }
        }

        private void MFormWithTitle_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath oPath = new GraphicsPath();
            int x = 0;
            int y = 0;
            int w = Width;
            int h = Height;
            int a = 16;
            oPath.AddArc(x, y, m_nBorderRadius, m_nBorderRadius, 180, 90);                                           //绘制左上角
            oPath.AddArc(w - m_nBorderRadius, y, m_nBorderRadius, m_nBorderRadius, 270, 90);                         //绘制右上角
            oPath.AddArc(w - m_nBorderRadius, h - m_nBorderRadius, m_nBorderRadius, m_nBorderRadius, 0, 90);         //绘制右下角
            oPath.AddArc(x, h - m_nBorderRadius, m_nBorderRadius, m_nBorderRadius, 90, 90);                          //绘制左下角
            oPath.CloseAllFigures();
            Region = new Region(oPath);
        }

        #endregion
    }

}
