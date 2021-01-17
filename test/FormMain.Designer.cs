
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("窗体", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode3});
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
            this.mTreeView1.ColorNodDefault = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mTreeView1.ColorNodeHot = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.mTreeView1.ColorNodeSelect = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            this.mTreeView1.ColorSelectText = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mTreeView1.ColorTextDefault = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mTreeView1.ColorTextHot = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.mTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.mTreeView1.FontNodeDefault = new System.Drawing.Font("黑体", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mTreeView1.FontNodeHot = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
            this.mTreeView1.FontNodeSelect = new System.Drawing.Font("黑体", 14F, System.Drawing.FontStyle.Bold);
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
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "forms";
            treeNode2.Text = "窗体";
            treeNode3.Name = "节点7";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Text = "节点7";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "节点1";
            treeNode4.Text = "节点1";
            this.mTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            this.mTreeView1.SelectedImageIndex = 0;
            this.mTreeView1.ShowLines = false;
            this.mTreeView1.ShowPlusMinus = false;
            this.mTreeView1.ShowRootLines = false;
            this.mTreeView1.Size = new System.Drawing.Size(220, 538);
            this.mTreeView1.TabIndex = 4;
            this.mTreeView1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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