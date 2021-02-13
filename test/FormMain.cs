using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MControl.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using test.Demo;

namespace test
{
    public partial class FormMain : MFormWithTitle
    {
        public FormMain()
        {
            InitializeComponent();

            Sidebar.Width = 40;
            mTreeView1.Visible = false;
        }

        #region 侧栏开关按键设置
        private void butSidebar_MouseEnter(object sender, EventArgs e)
        {
            butSidebar.BackColor = Color.FromArgb(255, 80, 80, 80);
        }

        private void butSidebar_MouseLeave(object sender, EventArgs e)
        {
            butSidebar.BackColor = Color.FromArgb(255, 40, 40, 40);
        }

        /// <summary>
        /// 打开或关闭侧栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSidebar_Click(object sender, EventArgs e)
        {
            if(Sidebar.Width == 40)
            {
                for (int i = 0; i < 5; i++)
                {
                    Sidebar.Width += 36;
                }
                mTreeView1.Visible = true;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Sidebar.Width -= 36;
                }
                mTreeView1.Visible = false;
            }
        }

        #endregion


        private void mTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.panelShow.Controls.Clear();
            switch(e.Node.Text.Trim())
            {
                case "带标题的窗体":
                    {
                        Form form = new MFormWithTitle();
                        form.Show();
                        break;
                    }
                case "按键":
                    {
                        DButtons dButtons = new DButtons();
                        dButtons.Dock = DockStyle.Fill;
                        this.panelShow.Controls.Add(dButtons);
                        break;
                    }
            }
        }
    }
}
