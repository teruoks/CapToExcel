namespace CapToExcel
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAction = new System.Windows.Forms.Button();
            this.chkMinimum = new System.Windows.Forms.CheckBox();
            this.btnComment = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSetting = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(9, 10);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(85, 49);
            this.btnAction.TabIndex = 0;
            this.btnAction.Text = "開始";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // chkMinimum
            // 
            this.chkMinimum.AutoSize = true;
            this.chkMinimum.Location = new System.Drawing.Point(107, 43);
            this.chkMinimum.Name = "chkMinimum";
            this.chkMinimum.Size = new System.Drawing.Size(105, 16);
            this.chkMinimum.TabIndex = 3;
            this.chkMinimum.Text = "開始時に最小化";
            this.chkMinimum.UseVisualStyleBackColor = true;
            // 
            // btnComment
            // 
            this.btnComment.Location = new System.Drawing.Point(106, 10);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(105, 23);
            this.btnComment.TabIndex = 4;
            this.btnComment.Text = "コメント";
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(141, 22);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.btnSetting,
            this.toolStripStatusLabel3,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 62);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(223, 27);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // btnSetting
            // 
            this.btnSetting.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(36, 22);
            this.btnSetting.Text = "設定";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 89);
            this.Controls.Add(this.btnComment);
            this.Controls.Add(this.chkMinimum);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ScreenCapture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.CheckBox chkMinimum;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel btnSetting;
    }
}

