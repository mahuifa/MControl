
namespace MControl.Forms
{
    partial class MFormWithTitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormWithTitle));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.panelBut = new System.Windows.Forms.Panel();
            this.ButClose = new System.Windows.Forms.PictureBox();
            this.ButMaxmum = new System.Windows.Forms.PictureBox();
            this.ButMinmum = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.Micon = new System.Windows.Forms.PictureBox();
            this.TitleBar.SuspendLayout();
            this.panelBut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButMaxmum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButMinmum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Micon)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.TitleBar.Controls.Add(this.panelBut);
            this.TitleBar.Controls.Add(this.Title);
            this.TitleBar.Controls.Add(this.Micon);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.MaximumSize = new System.Drawing.Size(0, 45);
            this.TitleBar.MinimumSize = new System.Drawing.Size(0, 45);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(523, 45);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.DoubleClick += new System.EventHandler(this.TitleBar_DoubleClick);
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // panelBut
            // 
            this.panelBut.Controls.Add(this.ButClose);
            this.panelBut.Controls.Add(this.ButMaxmum);
            this.panelBut.Controls.Add(this.ButMinmum);
            this.panelBut.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBut.Location = new System.Drawing.Point(411, 0);
            this.panelBut.MaximumSize = new System.Drawing.Size(112, 45);
            this.panelBut.MinimumSize = new System.Drawing.Size(112, 35);
            this.panelBut.Name = "panelBut";
            this.panelBut.Size = new System.Drawing.Size(112, 45);
            this.panelBut.TabIndex = 2;
            // 
            // ButClose
            // 
            this.ButClose.Image = global::MControl.Resource1.CloseBlack;
            this.ButClose.Location = new System.Drawing.Point(80, 7);
            this.ButClose.Name = "ButClose";
            this.ButClose.Size = new System.Drawing.Size(25, 25);
            this.ButClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButClose.TabIndex = 3;
            this.ButClose.TabStop = false;
            this.ButClose.Click += new System.EventHandler(this.ButClose_Click);
            this.ButClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButClose_MouseDown);
            this.ButClose.MouseEnter += new System.EventHandler(this.ButClose_MouseEnter);
            this.ButClose.MouseLeave += new System.EventHandler(this.ButClose_MouseLeave);
            this.ButClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButClose_MouseUp);
            // 
            // ButMaxmum
            // 
            this.ButMaxmum.Image = global::MControl.Resource1.MaximizeBlack;
            this.ButMaxmum.Location = new System.Drawing.Point(41, 7);
            this.ButMaxmum.Name = "ButMaxmum";
            this.ButMaxmum.Size = new System.Drawing.Size(25, 25);
            this.ButMaxmum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButMaxmum.TabIndex = 2;
            this.ButMaxmum.TabStop = false;
            this.ButMaxmum.Click += new System.EventHandler(this.ButMaxmum_Click);
            this.ButMaxmum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButMaxmum_MouseDown);
            this.ButMaxmum.MouseEnter += new System.EventHandler(this.ButMaxmum_MouseEnter);
            this.ButMaxmum.MouseLeave += new System.EventHandler(this.ButMaxmum_MouseLeave);
            this.ButMaxmum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButMaxmum_MouseUp);
            // 
            // ButMinmum
            // 
            this.ButMinmum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButMinmum.Image = ((System.Drawing.Image)(resources.GetObject("ButMinmum.Image")));
            this.ButMinmum.Location = new System.Drawing.Point(3, 7);
            this.ButMinmum.Name = "ButMinmum";
            this.ButMinmum.Size = new System.Drawing.Size(25, 25);
            this.ButMinmum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ButMinmum.TabIndex = 1;
            this.ButMinmum.TabStop = false;
            this.ButMinmum.Click += new System.EventHandler(this.ButMinmum_Click);
            this.ButMinmum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButMinmum_MouseDown);
            this.ButMinmum.MouseEnter += new System.EventHandler(this.ButMinmum_MouseEnter);
            this.ButMinmum.MouseLeave += new System.EventHandler(this.ButMinmum_MouseLeave);
            this.ButMinmum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButMinmum_MouseUp);
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("宋体", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.Location = new System.Drawing.Point(50, 15);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(85, 19);
            this.Title.TabIndex = 1;
            this.Title.Text = "标题窗体";
            // 
            // Micon
            // 
            this.Micon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Micon.Location = new System.Drawing.Point(2, 2);
            this.Micon.MaximumSize = new System.Drawing.Size(40, 40);
            this.Micon.MinimumSize = new System.Drawing.Size(40, 40);
            this.Micon.Name = "Micon";
            this.Micon.Size = new System.Drawing.Size(40, 40);
            this.Micon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Micon.TabIndex = 0;
            this.Micon.TabStop = false;
            // 
            // MFormWithTitle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(523, 361);
            this.Controls.Add(this.TitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(112, 0);
            this.Name = "MFormWithTitle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "有标题的窗口";
            this.SizeChanged += new System.EventHandler(this.FormWithTitle_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MFormWithTitle_Paint);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.panelBut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ButClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButMaxmum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButMinmum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Micon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.PictureBox Micon;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panelBut;
        private System.Windows.Forms.PictureBox ButMinmum;
        private System.Windows.Forms.PictureBox ButClose;
        private System.Windows.Forms.PictureBox ButMaxmum;
    }
}