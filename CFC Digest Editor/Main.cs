using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFC_Digest_Editor
{
    public partial class Main : Form
    {
        public Main() 
            => InitializeComponent();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) 
            => Application.Exit();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            => new AboutBox1(this).ShowDialog();


    }
}
