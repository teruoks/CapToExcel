using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowCapture
{
    public partial class ProcessForm : Form
    {
        private static ClipBordWatcher clipboard;
        private static int imageNo;
        private readonly string tempPath = System.Windows.Forms.Application.StartupPath;


        public ProcessForm()
        {
            imageNo = 0;
            clipboard = new ClipBordWatcher(this);
        }

        public bool start()
        {
            clipboard.ClipboardHandler += this.onClipBoardChanged;
            return true;
        }

        public bool stop()
        {
            clipboard.ClipboardHandler -= this.onClipBoardChanged;
            return true;
        }

        /// <summary>
        /// クリップボードに画像が入ると呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arss"></param>
        private void onClipBoardChanged(object sender, ClipboardEventArgs arss)
        {
            Image img = Clipboard.GetImage();
            if (img != null)
            {
                if (!System.IO.Directory.Exists(tempPath + "\\image"))
                {
                    System.IO.Directory.CreateDirectory(tempPath + "\\image");
                }

                //画像を作成する
                Bitmap bmp = new Bitmap(img);
                bmp.Save(tempPath + "\\image\\" + (++imageNo).ToString("000") + ".bmp");
                //後片付け
                bmp.Dispose();
            }
        }
    }
}
