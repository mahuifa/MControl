﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MControl.Forms
{
    public partial class FormWithTitle : Form
    {
        public FormWithTitle()
        {
            InitializeComponent();

        }

        /// <summary>
        ///打开窗口 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormWithTitle_Load(object sender, EventArgs e)
        {
            InitTitleBar();
        }

        #region 初始化标题栏

        private void InitTitleBar()
        {
            //初始化标题位置
            if (m_TitlePosition == 1)
            {
                Title.Location = new Point((this.Size.Width - Title.Size.Width) / 2, 10);
            }

            //初始化图标
            if (m_ShowIcon)
            {
                Icon icon = this.Icon;
                MemoryStream mStream = new MemoryStream();
                icon.Save(mStream);
                Image image = Image.FromStream(mStream);
                Micon.Image = image;
            }
            if(!m_ShowIcon && m_TitlePosition == 0)
            {
                Title.Location = new Point(10, 10);
            }
        }

        private bool m_ShowIcon = true;                                   //是否显示窗口图标
        /// <summary>
        /// 是否显示窗口图标
        /// </summary>
        public bool ShowIcon
        {
            get
            {
                return m_ShowIcon;
            }
            set
            {
                m_ShowIcon = value;
            }
        }

        /// <summary>
        /// 设置、获取窗口标题栏背景色
        /// </summary>
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
          
        #region 标题显示位置
        /// <summary>
        /// 设置窗口标题位置
        /// </summary>
        public enum EnumTitlePosition
        {
            Left = 0,
            Center = 1
        }

        private int m_TitlePosition = 0;                                      //保存标题位置

        /// <summary>
        /// 窗口标题位置，使用EnumTitlePosition
        /// </summary>
        public int TitlePosition
        {
            get
            {
                return m_TitlePosition;
            }
            set
            {
                m_TitlePosition = value;
            }
        }


        /// <summary>
        /// 窗口大小变化是保证标题居中显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormWithTitle_SizeChanged(object sender, EventArgs e)
        {
            if(m_TitlePosition == 1)
            {
                Title.Location = new Point((this.Size.Width - Title.Size.Width) / 2, 10);
            }
        }

        #endregion

        
    }
}
