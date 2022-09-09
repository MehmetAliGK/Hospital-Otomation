using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnhastagiris_Click(object sender, EventArgs e)
        {
         FrmHastaGiris fr = new FrmHastaGiris(); 
         fr.Show();
         this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btndoktorgiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris fr1 = new FrmDoktorGiris();
            fr1.Show();
            this.Hide();
        }

        private void btnsekretergiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris fr2 = new FrmSekreterGiris();
            fr2.Show();
            this.Hide();
        }
    }
}
