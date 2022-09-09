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
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string Tcno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = Tcno;
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Hasta where HastaTC=@a1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", msktc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                msktel.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Update Tbl_Hasta set HastaAd=@b1,HastaSoyad=@b2,HastaTelefon=@b3,HastaSifre=@b4,HastaCinsiyet=@b5  where HastaTC=@b6", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@b1", txtad.Text);
            cmd2.Parameters.AddWithValue("@b2", txtsoyad.Text);
            cmd2.Parameters.AddWithValue("@b3", msktel.Text);
            cmd2.Parameters.AddWithValue("@b4", txtsifre.Text);
            cmd2.Parameters.AddWithValue("@b5", cmbcinsiyet.Text);
            cmd2.Parameters.AddWithValue("@b6", msktc.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
