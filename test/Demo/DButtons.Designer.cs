
namespace test.Demo
{
    partial class DButtons
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mRoundButton2 = new MControl.Controls.Buttons.MRoundButton();
            this.mRoundButton3 = new MControl.Controls.Buttons.MRoundButton();
            this.mRoundButton1 = new MControl.Controls.Buttons.MRoundButton();
            this.SuspendLayout();
            // 
            // mRoundButton2
            // 
            this.mRoundButton2.BackColor = System.Drawing.Color.Transparent;
            this.mRoundButton2.Location = new System.Drawing.Point(256, 23);
            this.mRoundButton2.MBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(255)))), ((int)(((byte)(51)))));
            this.mRoundButton2.MText = "绿色Button";
            this.mRoundButton2.Name = "mRoundButton2";
            this.mRoundButton2.Size = new System.Drawing.Size(110, 110);
            this.mRoundButton2.TabIndex = 1;
            // 
            // mRoundButton3
            // 
            this.mRoundButton3.BackColor = System.Drawing.Color.Transparent;
            this.mRoundButton3.Location = new System.Drawing.Point(146, 23);
            this.mRoundButton3.MBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.mRoundButton3.MText = "红色Button";
            this.mRoundButton3.Name = "mRoundButton3";
            this.mRoundButton3.Size = new System.Drawing.Size(110, 110);
            this.mRoundButton3.TabIndex = 2;
            // 
            // mRoundButton1
            // 
            this.mRoundButton1.BackColor = System.Drawing.Color.Transparent;
            this.mRoundButton1.Location = new System.Drawing.Point(30, 23);
            this.mRoundButton1.MBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(230)))));
            this.mRoundButton1.MText = "蓝色Button";
            this.mRoundButton1.Name = "mRoundButton1";
            this.mRoundButton1.Size = new System.Drawing.Size(110, 110);
            this.mRoundButton1.TabIndex = 3;
            // 
            // DButtons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mRoundButton1);
            this.Controls.Add(this.mRoundButton3);
            this.Controls.Add(this.mRoundButton2);
            this.Name = "DButtons";
            this.Size = new System.Drawing.Size(575, 437);
            this.ResumeLayout(false);

        }

        #endregion
        private MControl.Controls.Buttons.MRoundButton mRoundButton2;
        private MControl.Controls.Buttons.MRoundButton mRoundButton3;
        private MControl.Controls.Buttons.MRoundButton mRoundButton1;
    }
}
