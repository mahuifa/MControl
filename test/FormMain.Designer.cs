
namespace test
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点5", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("窗体", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mTreeView1 = new MControl.Controls.MTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Sidebar = new System.Windows.Forms.Panel();
            this.butSidebar = new System.Windows.Forms.PictureBox();
            this.Sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butSidebar)).BeginInit();
            this.SuspendLayout();
            // 
            // mTreeView1
            // 
            this.mTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.mTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.mTreeView1.FullRowSelect = true;
            this.mTreeView1.HideSelection = false;
            this.mTreeView1.HotTracking = true;
            this.mTreeView1.ImageIndex = 0;
            this.mTreeView1.ImageList = this.imageList1;
            this.mTreeView1.ImageNodeClose = global::test.Properties.Resources.关闭白;
            this.mTreeView1.ImageNodeOpen = global::test.Properties.Resources.展开白;
            this.mTreeView1.ItemHeight = 50;
            this.mTreeView1.Location = new System.Drawing.Point(0, 40);
            this.mTreeView1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.mTreeView1.Name = "mTreeView1";
            this.mTreeView1.NodeDividingLindColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.mTreeView1.NodeDividingLindWidth = 1F;
            this.mTreeView1.NodeDividingLine = false;
            this.mTreeView1.NodeImageAlign = MControl.Controls.MTreeView.enumNodeImageAlign.Left;
            this.mTreeView1.NodeImageMode = MControl.Controls.MTreeView.enumNodeImageMode.OpenAndClose;
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "节点4";
            treeNode1.Text = "节点4";
            treeNode2.Name = "节点1";
            treeNode2.Text = "节点1";
            treeNode3.Name = "节点0";
            treeNode3.Text = "节点0";
            treeNode4.Name = "节点5";
            treeNode4.Text = "节点5";
            treeNode5.Name = "节点6";
            treeNode5.Text = "节点6";
            treeNode6.ImageIndex = 0;
            treeNode6.Name = "forms";
            treeNode6.Text = "窗体";
            treeNode7.Name = "节点7";
            treeNode7.SelectedImageIndex = 3;
            treeNode7.Text = "节点7";
            treeNode8.Name = "节点8";
            treeNode8.Text = "节点8";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "节点1";
            treeNode9.Text = "节点1";
            treeNode10.ImageIndex = 2;
            treeNode10.Name = "节点2";
            treeNode10.Text = "节点2";
            treeNode11.ImageIndex = 2;
            treeNode11.Name = "节点3";
            treeNode11.Text = "节点3";
            treeNode12.Name = "节点8";
            treeNode12.Text = "节点8";
            treeNode13.Name = "节点9";
            treeNode13.Text = "节点9";
            treeNode14.Name = "节点10";
            treeNode14.Text = "节点10";
            treeNode15.ImageIndex = 6;
            treeNode15.Name = "节点0";
            treeNode15.Text = "节点0";
            treeNode16.Name = "节点1";
            treeNode16.Text = "节点1";
            treeNode17.Name = "节点11";
            treeNode17.Text = "节点11";
            treeNode18.Name = "节点12";
            treeNode18.Text = "节点12";
            treeNode19.Name = "节点13";
            treeNode19.Text = "节点13";
            treeNode20.Name = "节点2";
            treeNode20.Text = "节点2";
            treeNode21.Name = "节点3";
            treeNode21.Text = "节点3";
            treeNode22.Name = "节点5";
            treeNode22.Text = "节点5";
            treeNode23.Name = "节点6";
            treeNode23.Text = "节点6";
            treeNode24.Name = "节点7";
            treeNode24.Text = "节点7";
            treeNode25.Name = "节点4";
            treeNode25.Text = "节点4";
            this.mTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode15,
            treeNode16,
            treeNode20,
            treeNode21,
            treeNode25});
            this.mTreeView1.SelectedImageIndex = 0;
            this.mTreeView1.ShowLines = false;
            this.mTreeView1.ShowPlusMinus = false;
            this.mTreeView1.ShowRootLines = false;
            this.mTreeView1.Size = new System.Drawing.Size(220, 494);
            this.mTreeView1.TabIndex = 4;
            this.mTreeView1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "窗口2.png");
            this.imageList1.Images.SetKeyName(1, "控件组.png");
            this.imageList1.Images.SetKeyName(2, "关闭白.png");
            this.imageList1.Images.SetKeyName(3, "关闭黑.png");
            this.imageList1.Images.SetKeyName(4, "展开白.png");
            this.imageList1.Images.SetKeyName(5, "展开黑.png");
            // 
            // Sidebar
            // 
            this.Sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Sidebar.Controls.Add(this.butSidebar);
            this.Sidebar.Controls.Add(this.mTreeView1);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.Location = new System.Drawing.Point(0, 35);
            this.Sidebar.MaximumSize = new System.Drawing.Size(220, 0);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Size = new System.Drawing.Size(220, 578);
            this.Sidebar.TabIndex = 5;
            // 
            // butSidebar
            // 
            this.butSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.butSidebar.Image = global::test.Properties.Resources.侧栏1;
            this.butSidebar.Location = new System.Drawing.Point(0, 0);
            this.butSidebar.Name = "butSidebar";
            this.butSidebar.Size = new System.Drawing.Size(40, 40);
            this.butSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.butSidebar.TabIndex = 7;
            this.butSidebar.TabStop = false;
            this.butSidebar.Click += new System.EventHandler(this.butSidebar_Click);
            this.butSidebar.MouseEnter += new System.EventHandler(this.butSidebar_MouseEnter);
            this.butSidebar.MouseLeave += new System.EventHandler(this.butSidebar_MouseLeave);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1066, 613);
            this.Controls.Add(this.Sidebar);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormMain";
            this.Controls.SetChildIndex(this.Sidebar, 0);
            this.Sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butSidebar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MControl.Controls.MTreeView mTreeView1;
        private System.Windows.Forms.Panel Sidebar;
        private System.Windows.Forms.PictureBox butSidebar;
        private System.Windows.Forms.ImageList imageList1;
    }
}