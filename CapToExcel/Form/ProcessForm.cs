using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapToExcel
{
    /// <summary>
    /// 実際のプロセス
    /// </summary>
    public partial class ProcessForm : Form
    {
        private static ClibBoradMonitorService clipboard;
        private int imageNo;
        private string tempDir;


        public ProcessForm(string tempDir)
        {
            this.imageNo = 0;
            this.tempDir = tempDir;
            this.InitializeComponent();

            if (System.IO.Directory.Exists(this.tempDir))
            {
                foreach (string file in System.IO.Directory.GetFiles(this.tempDir))
                {
                    System.IO.File.Delete(file);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(this.tempDir);
            }

            clipboard = new ClibBoradMonitorService(this);

        }

        /// <summary>
        /// プロセス開始
        /// </summary>
        /// <returns></returns>
        public void start()
        {
            this.Show();
            this.Hide();

            clipboard.ClipboardHandler += this.onClipBoardChanged;
        }

        /// <summary>
        /// プロセス終了
        /// </summary>
        /// <returns></returns>
        public void stop()
        {
            clipboard.ClipboardHandler -= this.onClipBoardChanged;
        }

        /// <summary>
        /// 画像がクリップボードに入ったらビットマップで保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arss"></param>
        private void onClipBoardChanged(object sender, ClipboardEventArgs arss)
        {
            Image img = Clipboard.GetImage();
            if (img != null)
            {
                if (!System.IO.Directory.Exists(this.tempDir))
                {
                    System.IO.Directory.CreateDirectory(this.tempDir);
                }
                Bitmap bmpImage = convertBitmap(img);
                bmpImage.Save(this.tempDir + "\\" + (++imageNo).ToString("000") + ".bmp");
                bmpImage.Dispose();
            }
        }

        private Size getImageSize(int width, int height)
        {
            Size size = new Size(width, height);
            if (SettingDto.imageResize && SettingDto.imageWidth < height)
            {
                size.Width = SettingDto.imageWidth;
                size.Height = (int)(height * ((double)size.Width / (double)width));
            }
            return size;
        }


        private Bitmap convertBitmap(Image img)
        {
            // ビットマップで画像保存
            Size resizeSize = getImageSize(img.Width, img.Height);
            Bitmap resizeBmp = new Bitmap(resizeSize.Width, resizeSize.Height);
            using (Graphics g = Graphics.FromImage(resizeBmp))
            {
                g.DrawImage(img, 0, 0, resizeSize.Width, resizeSize.Height);
                img.Dispose();
                g.Dispose();
            }

            return resizeBmp;
        }

    }
}
