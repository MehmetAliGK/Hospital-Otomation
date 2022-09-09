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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void lnküyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayit frm = new HastaKayit();
            frm.Show();
            
        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Hasta Where HastaTC=@a1 and HastaSifre=@a2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", msktc.Text);
            cmd.Parameters.AddWithValue("@a2", txtsifre.Text);
            SqlDataReader dr= cmd.ExecuteReader();
           
            if (dr.Read())
            {
                FrmHastaDetay frm = new FrmHastaDetay();
                frm.tc = msktc.Text;           
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız","Hata",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
            }
    }
} 
