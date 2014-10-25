using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapToExcel
{
    public partial class CommentForm : Form
    {
        public CommentForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
