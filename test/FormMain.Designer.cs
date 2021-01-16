
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.mTreeView1 = new MControl.Controls.MTreeView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(524, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(524, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Location = new System.Drawing.Point(504, 177);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // mTreeView1
            // 
            this.mTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.mTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.mTreeView1.FullRowSelect = true;
            this.mTreeView1.HideSelection = false;
            this.mTreeView1.HotTracking = true;
            this.mTreeView1.ItemHeight = 50;
            this.mTreeView1.Location = new System.Drawing.Point(0, 35);
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
            this.mTreeView1.Size = new System.Drawing.Size(334, 533);
            this.mTreeView1.TabIndex = 4;
            this.mTreeView1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(914, 568);
            this.Controls.Add(this.mTreeView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FormMain";
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.mTreeView1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MControl.Controls.MTreeView mTreeView1;
    }
}