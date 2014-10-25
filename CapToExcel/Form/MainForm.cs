using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapToExcel
{
    public partial class Main : Form
    {
        private ProcessForm process;
        private bool isMove;
        private readonly string tempDir = System.Windows.Forms.Application.StartupPath + "\\temp";
 
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
            if (!isMove)
            {
                startAction();
            }
            else
            {
                stopAction();
            }

            isMove = !isMove;
        }

        /// <summary>
        /// 開始処理
        /// </summary>
        private void startAction()
        {
            btnAction.Text = "終了";
            lblStatus.Text = "記録中...";

            if (chkMinimum.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            process = new ProcessForm(this.tempDir);
            process.start();


        }

        /// <summary>
        /// 終了処理
        /// </summary>
        private void stopAction()
        {
            lblStatus.Text = "";
            btnAction.Text = "開始";
            process.stop();

            // Excelを作成
            CreateExcelService excelService = new CreateExcelService();
            excelService.execute(tempDir);
            excelService = null;
            process.Dispose();
            process = null;
            Clipboard.Clear();

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
        }

        /// <summary>
        /// フォーをム閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isMove)
            {
                MessageBox.Show("記録中のデータは破棄されます。\nよろしいですか？", "確認", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 設定画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();

        }
    }
}
