using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Proje_Hastane
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Sekreter1 where SekreterTc=@a1 and SekreterSifre=@a2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", msktc.Text);
            cmd.Parameters.AddWithValue("@a2", txtsifre.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                FrmSekreterDetay frm = new FrmSekreterDetay();
                frm.Tcno = msktc.Text;
                frm.Show();
                
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız","Bilgi",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();


        }
    }
}
