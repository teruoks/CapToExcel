using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace CapToExcel
{
    public class ClipboardEventArgs : EventArgs
    {
        private Image _image;

        public Image image
        {
            get { return this._image; }
        }

        public ClipboardEventArgs(Image image)
        {
            this._image = image;
        }
    }

    public delegate void cbEventHandler(
                            object sender, ClipboardEventArgs ev);

    [System.Security.Permissions.PermissionSet(
          System.Security.Permissions.SecurityAction.Demand,
          Name = "FullTrust")]

    internal class ClibBoradMonitorService : NativeWindow
    {
        [DllImport("user32")]
        public static extern IntPtr SetClipboardViewer(
                IntPtr hWndNewViewer);

        [DllImport("user32")]
        public static extern bool ChangeClipboardChain(
                IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32")]
        public extern static int SendMessage(
                IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;
        private IntPtr nextHandle;

        private Form parent;
        public event cbEventHandler ClipboardHandler;

        public ClibBoradMonitorService(Form f)
        {
            Clipboard.Clear();
            f.HandleCreated
                        += new EventHandler(this.OnHandleCreated);
            f.HandleDestroyed
                        += new EventHandler(this.OnHandleDestroyed);
            this.parent = f;
        }

        internal void OnHandleCreated(object sender, EventArgs e)
        {
            AssignHandle(((Form)sender).Handle);
            nextHandle = SetClipboardViewer(this.Handle);
        }

        internal void OnHandleDestroyed(object sender, EventArgs e)
        {
            bool sts = ChangeClipboardChain(this.Handle, nextHandle);
            ReleaseHandle();
        }

        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {

                case WM_DRAWCLIPBOARD:

                    if (Clipboard.ContainsImage())
                    {
                        // 画像がクリップされた
                        ClipboardHandler(this, new ClipboardEventArgs(Clipboard.GetImage()));
                    }

                    if ((int)nextHandle != 0)
                        SendMessage(
                            nextHandle, msg.Msg, msg.WParam, msg.LParam);
                    break;

                // クリップボード・ビューア・チェーンが更新された
                case WM_CHANGECBCHAIN:
                    if (msg.WParam == nextHandle)
                    {
                        nextHandle = (IntPtr)msg.LParam;
                    }
                    else if ((int)nextHandle != 0)
                        SendMessage(
                            nextHandle, msg.Msg, msg.WParam, msg.LParam);
                    break;
            }
            base.WndProc(ref msg);
        }
    }
}

