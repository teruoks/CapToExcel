using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowCapture
{
    public partial class Main : Form
    {
        private static ProcessForm process;
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 開始 / 終了ボタン押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAction_Click(object sender, EventArgs e)
        {
            if ("開始".Equals(btnAction.Text))
            {
                btnAction.Text = "終了";
                lblStatus.Text = "記録中...";
                if (chkMinimum.Checked)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                process = new ProcessForm();
                process.Visible = false;
                process.start();
                process.Show();

            }
            else
            {
                lblStatus.Text = "";
                btnAction.Text = "開始";
                process.stop();
            }
        }

        /// <summary>
        /// コメント画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComment_Click(object sender, EventArgs e)
        {
            CommentForm commentForm = new CommentForm();
            commentForm.Show();

            ExcelAction a = new ExcelAction();
            a.createExcel();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("閉じますか?", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
