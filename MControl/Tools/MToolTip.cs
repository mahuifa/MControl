using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MControl.Tools
{
    public class MToolTip:ToolTip
    {
        public MToolTip()
        {
            this.Popup += new PopupEventHandler(toolTip1_Popup);
            this.Draw += new DrawToolTipEventHandler(this.toolTip1_Draw);
            this.OwnerDraw = true;
        }

        #region 字段
        Color m_BackColor = Color.FromArgb(120, 0, 204, 255);                  //背景颜色
        Color m_FontColor = Color.Black;                                       //文本颜色
        Bitmap m_BackImage = null;                                             //透明背景
        #endregion

        #region 属性
        /// <summary>
        ///  获取或设置控件的背景色。
        /// </summary>
        /// <returns>
        /// 控件背景色
        /// </returns>
        [Category("自定义属性"), Description("设置控件的背景色。")]
        public new Color BackColor
        {
            get
            {
                return m_BackColor;
            }
            set
            {
                m_BackColor = value;
            }
        }

        /// <summary>
        ///  获取或设置文本的颜色。
        /// </summary>
        /// <returns>
        /// 文本的颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置文本的颜色。")]
        public Color FontColor
        {
            get
            {
                return m_FontColor;
            }
            set
            {
                m_FontColor = value;
            }
        }

        #endregion

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            m_BackImage = new Bitmap(e.ToolTipSize.Width, e.ToolTipSize.Height);
            var backGraphics = Graphics.FromImage(m_BackImage);
            backGraphics.CopyFromScreen(new Point(Cursor.Position.X, Cursor.Position.Y + 21), new Point(0, 0), e.ToolTipSize);
        }
        private void toolTip1_Draw(Object sender,DrawToolTipEventArgs e)
        {
            if(m_BackImage == null)
            {
                return;
            }
            Graphics l_graphics = Graphics.FromImage(m_BackImage);                             
            l_graphics.FillRectangle(new SolidBrush(m_BackColor), new Rectangle(e.Bounds.Location, e.Bounds.Size));      //绘制背景
            l_graphics.DrawString(e.ToolTipText, e.Font, new SolidBrush(m_FontColor), 2,2);                //绘制文本
            e.Graphics.DrawImage(m_BackImage, new Point(0, 0));
        }
    }
}
