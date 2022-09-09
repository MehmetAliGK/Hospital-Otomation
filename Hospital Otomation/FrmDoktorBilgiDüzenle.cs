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
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCNO;
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = TCNO;
            SqlCommand cmd = new SqlCommand("select * from Tbl_Doktor Where DoktorTc=@a1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", msktc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
         
            }
            bgl.baglanti().Close();
            }

        private void btnbilgigüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("update Tbl_Doktor set DoktorAd=@a1,DoktorSoyad=@a2,DoktorBrans=@a3,DoktorSifre=@a4 where DoktorTC=@a5",bgl.baglanti());
            cmd2.Parameters.AddWithValue("@a1", txtad.Text);
            cmd2.Parameters.AddWithValue("@a2", txtsoyad.Text);
            cmd2.Parameters.AddWithValue("@a3", cmbbrans.Text);
            cmd2.Parameters.AddWithValue("@a4", txtsifre.Text);
            cmd2.Parameters.AddWithValue("@a5", msktc.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
