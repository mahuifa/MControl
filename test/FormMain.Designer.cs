
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点00123456", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点3");
            this.mTreeView1 = new MControl.Controls.MTreeView();
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
            this.mTreeView1.ItemHeight = 50;
            this.mTreeView1.Location = new System.Drawing.Point(4, 52);
            this.mTreeView1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.mTreeView1.Name = "mTreeView1";
            treeNode1.Name = "节点4";
            treeNode1.Text = "节点4";
            treeNode2.Name = "节点5";
            treeNode2.Text = "节点5";
            treeNode3.Name = "节点6";
            treeNode3.Text = "节点6";
            treeNode4.Name = "节点";
            treeNode4.Text = "节点00123456";
            treeNode5.Name = "节点7";
            treeNode5.Text = "节点7";
            treeNode6.Name = "节点8";
            treeNode6.Text = "节点8";
            treeNode7.Name = "节点1";
            treeNode7.Text = "节点1";
            treeNode8.Name = "节点2";
            treeNode8.Text = "节点2";
            treeNode9.Name = "节点3";
            treeNode9.Text = "节点3";
            this.mTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode8,
            treeNode9});
            this.mTreeView1.ShowLines = false;
            this.mTreeView1.ShowPlusMinus = false;
            this.mTreeView1.ShowRootLines = false;
            this.mTreeView1.Size = new System.Drawing.Size(216, 523);
            this.mTreeView1.TabIndex = 4;
            this.mTreeView1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
    }
}