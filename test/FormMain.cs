using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MControl.Forms;

namespace test
{
    public partial class FormMain : FormWithTitle
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             this.Icon = new Icon(@"C:\Users\mhf\Pictures\图标\飞机.ico");
            if(this.Text == "主窗口")
            {
                this.Text = "标题窗口";
            }
            else
            {
                this.Text = "主窗口";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.TitlePosition = !this.TitlePosition;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ShowIcon = !this.ShowIcon;
        }
    }
}
