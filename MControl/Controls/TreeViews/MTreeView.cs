﻿/*****************************************************************************************************
文件名: MTreeView.cs
作  者: MHF
描  述: 自定义TreeView类
版  本: 0.1.0
日  期: 2021.1.14
功  能：1、重绘节点；
        2、设置节点中文本对齐方式；
        3、设置节点分割线是否显示、大小、颜色；
        4、设置节点图标显示方式、图标大小；
        5、设置节点单击打开；
        6、设置节点字体样式、颜色；
        7、设置节点背景色；
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using MControl.Tools;
using System.ComponentModel;

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

        #region 字段
        #region 枚举

        /// <summary>
        /// 节点图标模式
        /// </summary>
        public enum enumNodeImageMode
        {
            /// <summary>
            /// 不显示图标
            /// </summary>
            None = 0,
            /// <summary>
            /// 使用ImageList中的图片显示
            /// </summary>
            ImageList = 1,
            /// <summary>
            /// 只显示传入的展开、关闭节点图标
            /// </summary>
            OpenAndClose = 2
        };

        /// <summary>
        /// 节点图标显示位置
        /// </summary>
        public enum enumNodeImageAlign
        {
            Left = 0,
            Right = 1
        };
        #endregion

        #region 颜色
        /// <summary>
        /// 选中节点的颜色
        /// </summary>
        Color m_ColorNodeSelect = Color.FromArgb(255, 144, 144, 144);
        /// <summary>
        /// 鼠标进入节点的颜色
        /// </summary>
        Color m_ColorNodeHot = Color.FromArgb(255, 80, 80, 80);
        /// <summary>
        /// 节点默认颜色
        /// </summary>
        Color m_ColorNodDefault = Color.FromArgb(40, 40, 40);

        /// <summary>
        /// 选中节点后字体的颜色
        /// </summary>
        Color m_ColorSelectText = Color.FromArgb(255, 250, 250, 250);
        /// <summary>
        /// 鼠标进入节点后字体的颜色
        /// </summary>
        Color m_ColorTextHot = Color.FromArgb(255,250,250,250);
        /// <summary>
        /// 字体默认颜色
        /// </summary>
        Color m_ColorTextDefault = Color.FromArgb(255, 250, 250, 250);

        /// <summary>
        /// 节点分割线颜色
        /// </summary>
        Color m_ColorDividingLind = Color.FromArgb(255, 200, 200, 200);
        #endregion

        #region 字体
        /// <summary>
        /// 选中节点后字体
        /// </summary>
        Font m_FontNodeSelect = new Font("宋体", 14, FontStyle.Bold);
        /// <summary>
        /// 鼠标进入节点后字体
        /// </summary>
        Font m_FontNodeHot = new Font("宋体", 12, FontStyle.Bold);
        /// <summary>
        /// 节点默认字体
        /// </summary>
        Font m_FontNodeDefault = new Font("宋体", 12, FontStyle.Bold);
        #endregion

        #region 其它字段
        /// <summary>
        /// 节点文本对齐方式
        /// </summary>
        int m_nTextAlign = (int)ContentAlignment.TopLeft;
        /// <summary>
        /// 节点分割线粗细
        /// </summary>
        float m_fNodeDividingLineWidth = 1f;
        /// <summary>
        /// 是否显示节点分割线
        /// </summary>
        bool m_bNodeDividingLine = false;
        /// <summary>
        /// 设置节点图标模式
        /// </summary>
        int m_nNodeImageMode = (int)enumNodeImageMode.None;
        /// <summary>
        /// 设置节点图标显示位置
        /// </summary>
        int m_nNodeImageAlign = (int)enumNodeImageAlign.Left;
        #endregion

        #region 图片
        /// <summary>
        /// 节点关闭的图标
        /// </summary>
        Image m_imageNodeClose = null;
        /// <summary>
        /// 节点展开的图标
        /// </summary>
        Image m_imageNodeOpen = null;

        #endregion

        #endregion

        #region 复用函数
        /// <summary>
        /// 判断传入值是否存在于枚举中
        /// </summary>
        /// <param name="p_enumType"></param>
        /// <param name="p_nValue"></param>
        private void EnumContains(Type p_enumType, int p_nValue)
        {
            //判断枚举中是否存在传入的值
            Array array = Enum.GetValues(p_enumType);
            int l_nLen = 0;
            foreach (int i in array)
            {
                if (i == p_nValue)
                {
                    break;
                }
                l_nLen++;
            }
            if (l_nLen == array.Length)
            {
                throw (new System.ComponentModel.InvalidEnumArgumentException());
            }
        }
        #endregion

        #region 设置节点字体

        /// <summary>
        ///  获取或设置节点选中时的字体。
        /// </summary>
        /// <returns>
        ///  节点选中时的字体。
        /// </returns>
        [Category("自定义属性"), Description("设置节点选中时的字体。")]
        public Font FontNodeSelect
        {
            get
            {
                return m_FontNodeSelect;
            }
            set
            {
                m_FontNodeSelect = value;
            }
        }

        /// <summary>
        ///  获取或设置鼠标位于节点上时的字体。
        /// </summary>
        /// <returns>
        ///  鼠标位于节点上时的字体。
        /// </returns>
        [Category("自定义属性"), Description("设置鼠标位于节点上时的字体。")]
        public Font FontNodeHot
        {
            get
            {
                return m_FontNodeHot;
            }
            set
            {
                m_FontNodeHot = value;
            }
        }

        /// <summary>
        ///  获取或设置节点失去焦点时的字体。
        /// </summary>
        /// <returns>
        ///  节点失去焦点时的字体。
        /// </returns>
        [Category("自定义属性"), Description("设置节点失去焦点时的字体。")]
        public Font FontNodeDefault
        {
            get
            {
                return m_FontNodeDefault;
            }
            set
            {
                m_FontNodeDefault = value;
            }
        }


        /// <summary>
        ///  获取或设置节点选中时的字体颜色。
        /// </summary>
        /// <returns>
        ///  节点选中时的字体颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置节点选中时的字体颜色。")]
        public Color ColorSelectText
        {
            get
            {
                return m_ColorSelectText;
            }
            set
            {
                m_ColorSelectText = value;
            }
        }

        /// <summary>
        ///  获取或设置鼠标进入节点时的字体颜色。
        /// </summary>
        /// <returns>
        ///  鼠标进入节点时的字体颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置鼠标进入节点时的字体颜色。")]
        public Color ColorTextHot
        {
            get
            {
                return m_ColorTextHot;
            }
            set
            {
                m_ColorTextHot = value;
            }
        }

        /// <summary>
        ///  获取或设置节点失去焦点时的字体颜色。
        /// </summary>
        /// <returns>
        ///  节点失去焦点时的字体颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置节点失去焦点时的字体颜色。")]
        public Color ColorTextDefault
        {
            get
            {
                return m_ColorTextDefault;
            }
            set
            {
                m_ColorTextDefault = value;
            }
        }
        #endregion

        #region 设置节点背景色

        /// <summary>
        ///  获取或设置选中节点时节点的背景颜色。
        /// </summary>
        /// <returns>
        ///  选中节点时节点的背景颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置选中节点时节点的背景颜色。")]
        public Color ColorNodeSelect
        {
            get
            {
                return m_ColorNodeSelect;
            }
            set
            {
                m_ColorNodeSelect = value;
            }
        }

        /// <summary>
        ///  获取或设置鼠标进入节点时节点的背景颜色。
        /// </summary>
        /// <returns>
        ///  鼠标进入节点时节点的背景颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置鼠标进入节点时节点的背景颜色。")]
        public Color ColorNodeHot
        {
            get
            {
                return m_ColorNodeHot;
            }
            set
            {
                m_ColorNodeHot = value;
            }
        }

        /// <summary>
        ///  获取或设置失去焦点是节点的背景颜色。
        /// </summary>
        /// <returns>
        ///  失去焦点是节点的背景颜色。
        /// </returns>
        [Category("自定义属性"), Description("设置失去焦点是节点的背景颜色。")]
        public Color ColorNodDefault
        {
            get
            {
                return m_ColorNodDefault;
            }
            set
            {
                m_ColorNodDefault = value;
            }
        }

        #endregion

        #region 设置节点文本对齐方式

        /// <summary>
        ///  获取或设置TreeView节点上的文本对齐方式。
        /// </summary>
        /// <returns>
        ///  System.Drawing.ContentAlignment 值之一。 默认值为 MiddleCenter。
        /// </returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">
        /// 分配的值不是 System.Drawing.ContentAlignment 值之一。
        /// </exception>
        [Category("自定义属性"), Description("设置TreeView节点上的文本对齐方式。")]
        public ContentAlignment TextAlign
        {
            get
            {
                return (ContentAlignment)m_nTextAlign;
            }
            set
            {
                EnumContains(typeof(ContentAlignment), (int)value);                                                      //判断枚举中是否存在传入的值
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
            SizeF l_sizeF = l_graphics.MeasureString(p_strText, p_font);                            //计算文本的宽高
            int l_nWidth = e.Bounds.Width;
            int l_nHeight = e.Bounds.Height;
            PointF l_pointF = new PointF(e.Bounds.Left + (l_nWidth - (int)l_sizeF.Width) / 2,       //默认居中
                e.Bounds.Top + (l_nHeight - (int)l_sizeF.Height) / 2 );

            if(e.Bounds.Width == 0 && e.Bounds.Height == 0)                                        //去除打开节点时节点DrawTreeNodeEventArgs参数都为0时导致绘图出现残影
            {
                return new PointF(-10000, -10000);
            }
            switch (m_nTextAlign)
            {
                case (int)ContentAlignment.TopLeft:
                    {
                        l_pointF.X = e.Bounds.Left + (e.Node.Level * this.Indent);
                        if (m_nNodeImageAlign == 0 && this.ImageList != null)                      //显示图标时调整文本显示坐标
                        {
                            l_pointF.X += (this.ImageList.ImageSize.Width + 2);
                        }
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
                        if (m_nNodeImageAlign == 1 && this.ImageList != null)
                        {
                            l_pointF.X -= (this.ImageList.ImageSize.Width + 2);
                        }
                        l_pointF.Y = e.Bounds.Top + 1;
                        break;
                    }
                case (int)ContentAlignment.MiddleLeft:
                    {
                        l_pointF.X = e.Bounds.Left + (e.Node.Level * this.Indent);
                        if (m_nNodeImageAlign == 0 && this.ImageList != null)
                        {
                            l_pointF.X += (this.ImageList.ImageSize.Width + 2);
                        }
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
                        if (m_nNodeImageAlign == 1 && this.ImageList != null)
                        {
                            l_pointF.X -= (this.ImageList.ImageSize.Width + 2);
                        }
                        break;
                    }
                case (int)ContentAlignment.BottomLeft:
                    {
                        l_pointF.X = e.Bounds.Left + (e.Node.Level * this.Indent);
                        if (m_nNodeImageAlign == 0 && this.ImageList != null)
                        {
                            l_pointF.X += (this.ImageList.ImageSize.Width + 2);
                        }
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
                        if (m_nNodeImageAlign == 1 && this.ImageList != null)
                        {
                            l_pointF.X -= (this.ImageList.ImageSize.Width + 2);
                        }
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

        #region 设置节点分割线
        /// <summary>
        ///  获取或设置节点分割线显示。
        /// </summary>
        /// <returns>
        /// 节点分割线显示状态
        /// </returns>
        [Category("自定义属性"), Description("设置节点分割线是否显示。")]
        public bool NodeDividingLine
        { 
            get => m_bNodeDividingLine;
            set => m_bNodeDividingLine = value; 
        }

        /// <summary>
        ///  获取或设置节点分割线颜色。
        /// </summary>
        /// <returns>
        /// 节点分割线显示颜色
        /// </returns>
        [Category("自定义属性"), Description("设置节点分割线颜色。")]
        public Color NodeDividingLindColor
        {
            get => m_ColorDividingLind;
            set => m_ColorDividingLind = value;
        }

        /// <summary>
        ///  获取或设置节点分割线粗细。
        /// </summary>
        /// <returns>
        /// 节点分割线粗细
        /// </returns>
        [Category("自定义属性"), Description("设置节点分割线粗细。")]
        public float NodeDividingLindWidth
        {
            get => m_fNodeDividingLineWidth;
            set => m_fNodeDividingLineWidth = value;
        }
        #endregion

        #region 设置节点图标
        /// <summary>
        ///  获取或设置节点显示图标模式。
        /// </summary>
        /// <returns>
        /// 节点显示图标模式
        /// </returns>
        [Category("自定义属性"), Description("设置节点显示图标模式。")]
        public enumNodeImageMode NodeImageMode
        {
            get
            {
                return (enumNodeImageMode)m_nNodeImageMode;
            }
            set
            {

                EnumContains(typeof(enumNodeImageMode), (int)value);                                                      //判断枚举中是否存在传入的值
                m_nNodeImageMode = (int)value;
            }
        }

        /// <summary>
        ///  获取或设置节点关闭的图标。
        /// </summary>
        /// <returns>
        /// 节点关闭的图标
        /// </returns>
        [Category("自定义属性"), Description("设置节点关闭的图标。")]
        public Image ImageNodeClose
        {
            get
            {
                return m_imageNodeClose;
            }
            set
            {
                m_imageNodeClose = value;
            }
        }

        /// <summary>
        ///  获取或设置节点展开的图标。
        /// </summary>
        /// <returns>
        /// 节点展开的图标
        /// </returns>
        [Category("自定义属性"), Description("设置节点展开的图标。")]
        public Image ImageNodeOpen
        {
            get
            {
                return m_imageNodeOpen;
            }
            set
            {
                m_imageNodeOpen = value;
            }
        }

        /// <summary>
        ///  获取或设置节点图标的显示位置。
        /// </summary>
        /// <returns>
        /// 节点图标显示位置
        /// </returns>
        [Category("自定义属性"), Description("设置节点图标显示位置。")]
        public enumNodeImageAlign NodeImageAlign
        {
            get
            {
                return (enumNodeImageAlign)m_nNodeImageAlign;
            }
            set
            {
                EnumContains(typeof(enumNodeImageAlign), (int)value);                                                      //判断枚举中是否存在传入的值
                m_nNodeImageAlign = (int)value;
            }
        }

        /// <summary>
        /// 设置节点图标显示坐标
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Rectangle GetImageAlign(DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.Width == 0 && e.Bounds.Height == 0 || this.ImageList == null)    //去除打开节点时节点DrawTreeNodeEventArgs参数都为0时导致绘图出现残影
            {
                return new Rectangle(-10000, -10000, 0, 0);
            }
            Size l_size = this.ImageList.ImageSize;
            int l_nX = 1;
            int l_nY = e.Bounds.Top + (e.Bounds.Height - l_size.Height) / 2;
            if (m_nNodeImageAlign == 0)
            {
                l_nX = 1;
            }
            else
            {
                l_nX = e.Bounds.Right - 5 - l_size.Width;
            }

            return new Rectangle(l_nX, l_nY, l_size.Width, l_size.Height);
        }
        #endregion

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            try
            {
                e.Graphics.SetDrawhigh();

                /**************************************节点背景、文本绘制*********************************************************/
                if (e.Node.IsSelected)                                        //选中节点
                {
                    e.Graphics.FillRectangle(new SolidBrush(m_ColorNodeSelect), e.Bounds);
                    e.Graphics.DrawString(e.Node.Text, m_FontNodeSelect, new SolidBrush(m_ColorSelectText), GetTextPoint(e, e.Node.Text, m_FontNodeSelect));
                }
                else if (e.State == TreeNodeStates.Hot)                //鼠标进入节点
                {
                    e.Graphics.FillRectangle(new SolidBrush(m_ColorNodeHot), e.Bounds);
                    e.Graphics.DrawString(e.Node.Text, m_FontNodeHot, new SolidBrush(m_ColorTextHot), GetTextPoint(e, e.Node.Text, m_FontNodeHot));
                }
                else                                                        //其它状态
                {
                    e.Graphics.FillRectangle(new SolidBrush(m_ColorNodDefault), e.Bounds);
                    e.Graphics.DrawString(e.Node.Text, m_FontNodeDefault, new SolidBrush(m_ColorTextDefault), GetTextPoint(e, e.Node.Text, m_FontNodeDefault));
                }

                /**************************************绘制节点分割线*********************************************************/
                if (m_bNodeDividingLine)
                {
                    e.Graphics.DrawLine(new Pen(m_ColorDividingLind, m_fNodeDividingLineWidth), new Point(0, e.Bounds.Bottom - 1), new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
                }

                /**************************************绘制节点图标*********************************************************/
                if (m_nNodeImageMode == 1)
                {
                    //节点图标绘制(必须放在最后，否则显示不出来)
                    if (base.ImageList != null && e.Node.ImageIndex >= 0 && e.Node.ImageIndex <= base.ImageList.Images.Count)
                    {
                        int l_nIndex = e.Node.ImageIndex;
                        try
                        {
                            Image l_image = this.ImageList.Images[l_nIndex];
                            e.Graphics.DrawImage(l_image, GetImageAlign(e));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (m_nNodeImageMode == 2)
                {
                    if (e.Node.GetNodeCount(false) > 0)
                    {
                        if (m_imageNodeOpen != null && e.Node.IsExpanded)
                        {
                            e.Graphics.DrawImage(this.m_imageNodeOpen, GetImageAlign(e));
                        }
                        if (m_imageNodeClose != null && !e.Node.IsExpanded)
                        {
                            e.Graphics.DrawImage(this.m_imageNodeClose, GetImageAlign(e));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 单击打开/关闭节点
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            try
            {
                if (e.Node != null)
                {
                    if (e.Node.GetNodeCount(false) > 0)
                    {
                        if (e.Node.IsExpanded)
                        {
                            e.Node.Collapse();
                        }
                        else
                        {
                            e.Node.Expand();
                        }
                    }
                    /*if (base.SelectedNode != null)
                    {
                        if (base.SelectedNode == e.Node && e.Node.IsExpanded)
                        {
                            if (!true)
                            {
                                if (e.Node.Nodes.Count > 0)
                                {
                                    base.SelectedNode = e.Node.Nodes[0];
                                }
                            }
                        }
                    }*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
