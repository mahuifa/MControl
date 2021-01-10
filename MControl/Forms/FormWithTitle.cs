using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        #region 按键高亮
        /// <summary>
        /// 鼠标进入控件后控件高亮
        /// </summary>
        /// <param name="p_Control"></param>
        private void ButHighlight(Control p_Control)
        {
            Color color = TitleBar.BackColor;
            p_Control.BackColor = Color.FromArgb(color.R + 20, color.G + 20, color.B + 20);
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
            ButHighlight(ButClose);
        }

        private void ButClose_MouseLeave(object sender, EventArgs e)
        {
            ButRestoreColor(ButClose);
        }

        private void ButMaxmum_MouseEnter(object sender, EventArgs e)
        {
            ButHighlight(ButMaxmum);
        }

        private void ButMaxmum_MouseLeave(object sender, EventArgs e)
        {
            ButRestoreColor(ButMaxmum);
        }

        private void ButMinmum_MouseEnter(object sender, EventArgs e)
        {
            ButHighlight(ButMinmum);
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
            this.Location = new Point(l_Point.X + (MousePosition.X - m_PointMouse.X), l_Point.Y + (MousePosition.Y - m_PointMouse.Y));
            m_PointMouse = MousePosition;
        }

        /// <summary>
        /// 鼠标移动事件，获取鼠标当前坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                m_PointMouse = MousePosition;
                this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            }
        }

        /// <summary>
        /// 鼠标按键释放后停止监听鼠标坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.TitleBar.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
        }

        #endregion
    }
}
