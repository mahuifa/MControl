/*****************************************************************************************************
文件名: MTreeView.cs
作  者: MHF
描  述: 自定义TreeView类
版  本: 0.1.0
日  期: 2021.1.14
功  能：1、重绘节点；
        2、设置节点中文本对齐方式；
        
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using MControl.Tools;

namespace MControl.Controls
{
    public partial class MTreeView : TreeView
    {


        public MTreeView()
        {

            this.FullRowSelect = true;
            this.HotTracking = true;

            this.HideSelection = false;
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.ItemHeight = 50;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.ShowLines = false;
            this.ShowRootLines = false;
            this.ShowPlusMinus = false;
            this.BorderStyle = BorderStyle.None;
        }

        #region 颜色
        Color m_ColorNodeSelect = Color.FromArgb(255, 144, 144, 144);                     //选中节点的颜色
        Color m_ColorNodeHot = Color.FromArgb(255, 80, 80, 80);                           //鼠标进入节点的颜色
        Color m_ColorNodDefault = Color.FromArgb(40, 40, 40);                             //节点默认颜色

        Color m_ColorSelectText = Color.FromArgb(255,32,32,32);                           //选中节点后字体的颜色
        Color m_ColorTextHot = Color.FromArgb(255,200,200,222);                           //鼠标进入节点后字体的颜色
        Color m_ColorTextDefault = Color.FromArgb(255, 200, 200, 222);                    //字体默认颜色
        #endregion

        #region 字体
        Font m_FontNodeSelect = new Font("宋体", 14, FontStyle.Bold);                    //选中节点后字体
        Font m_FontNodeHot = new Font("宋体", 12, FontStyle.Bold);                       //鼠标进入节点后字体
        Font m_FontNodeDefault = new Font("宋体", 12, FontStyle.Bold);                   //节点默认字体
        #endregion


        #region 设置节点文本对齐方式
        int m_nTextAlign = (int)ContentAlignment.TopLeft;

        /// <summary>
        ///  获取或设置TreeView节点上的文本对齐方式。
        /// </summary>
        /// <returns>
        ///  System.Drawing.ContentAlignment 值之一。 默认值为 MiddleCenter。
        /// </returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">
        /// 分配的值不是 System.Drawing.ContentAlignment 值之一。
        /// </exception>
        public ContentAlignment TextAlign
        {
            get
            {
                return (ContentAlignment)m_nTextAlign;
            }
            set
            {

                //判断枚举中是否存在传入的值
                Array array = Enum.GetValues(typeof(ContentAlignment));
                int l_nLen = 0;
                foreach (ContentAlignment i in array)
                {
                    if(i == value)
                    {
                        break;
                    }
                    l_nLen++;
                }
                if(l_nLen == array.Length)
                {
                    throw (new System.ComponentModel.InvalidEnumArgumentException());
                }

                m_nTextAlign = (int)value;
                this.Update();                       
            }
        }

        /// <summary>
        /// 获取节点文本绘制的坐标
        /// </summary>
        /// <param name="e.Node"></param>
        /// <param name="p_strText"></param>
        /// <param name="p_font"></param>
        /// <returns></returns>
        private PointF GetTextPoint(DrawTreeNodeEventArgs e, string p_strText, Font p_font)
        {
            Graphics l_graphics = this.CreateGraphics();
            SizeF l_sizeF = l_graphics.MeasureString(p_strText, p_font);                                                   //计算文本的宽高
            int l_nWidth = e.Bounds.Width;
            int l_nHeight = e.Bounds.Height;
            PointF l_pointF = new PointF(e.Bounds.Left + (l_nWidth - (int)l_sizeF.Width) / 2,                              //默认居中
                e.Bounds.Top + (l_nHeight - (int)l_sizeF.Height) / 2 );


            switch (m_nTextAlign)
            {
                case (int)ContentAlignment.TopLeft:
                    {
                        l_pointF.X = e.Bounds.Left + 1;
                        l_pointF.Y = e.Bounds.Top + 1;
                        break;
                    }
                case (int)ContentAlignment.TopCenter:
                    {
                        l_pointF.Y = e.Bounds.Top + 1;
                        break;
                    }
                case (int)ContentAlignment.TopRight:
                    {
                        l_pointF.X = e.Bounds.Right - (int)l_sizeF.Width - 1;
                        l_pointF.Y = e.Bounds.Top + 1;
                        break;
                    }
                case (int)ContentAlignment.MiddleLeft:
                    {
                        l_pointF.X = e.Bounds.Left + 1;
                        break;
                    }
                case (int)ContentAlignment.MiddleCenter:
                    {
                        //默认
                        break;
                    }
                case (int)ContentAlignment.MiddleRight:
                    {
                        l_pointF.X = e.Bounds.Right - (int)l_sizeF.Width - 1;
                        break;
                    }
                case (int)ContentAlignment.BottomLeft:
                    {
                        l_pointF.X = e.Bounds.Left + 1;
                        l_pointF.Y = e.Bounds.Bottom - (int)l_sizeF.Height - 1;
                        break;
                    }
                case (int)ContentAlignment.BottomCenter:
                    {
                        l_pointF.Y = e.Bounds.Bottom - (int)l_sizeF.Height - 1;
                        break;
                    }
                case (int)ContentAlignment.BottomRight:
                    {
                        l_pointF.X = e.Bounds.Right - (int)l_sizeF.Width - 1;
                        l_pointF.Y = e.Bounds.Bottom - (int)l_sizeF.Height -1;
                        break;
                    }
                default:
                    {
                        //默认
                        break;
                    }
            }

            return l_pointF;
        }
        #endregion

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            e.Graphics.SetDrawhigh();

            //节点背景绘制
            if (e.Node.IsSelected)                                        //选中节点
            {
                e.Graphics.FillRectangle(new SolidBrush(m_ColorNodeSelect), e.Bounds);
                e.Graphics.DrawString(e.Node.Text, m_FontNodeSelect, new SolidBrush(m_ColorSelectText), GetTextPoint(e, e.Node.Text, m_FontNodeSelect));
            }
            else if ((e.State & TreeNodeStates.Hot) != 0)                //鼠标进入节点
            {
                e.Graphics.FillRectangle(new SolidBrush(m_ColorNodeHot), e.Bounds);
                e.Graphics.DrawString(e.Node.Text, m_FontNodeHot, new SolidBrush(m_ColorTextHot), GetTextPoint(e, e.Node.Text, m_FontNodeHot));
            }
            else                                                        //其它状态
            {
                e.Graphics.FillRectangle(new SolidBrush(m_ColorNodDefault), e.Bounds);
                e.Graphics.DrawString(e.Node.Text, m_FontNodeDefault, new SolidBrush(m_ColorTextDefault), GetTextPoint(e, e.Node.Text, m_FontNodeDefault));
            }
           
        }

    }

}
