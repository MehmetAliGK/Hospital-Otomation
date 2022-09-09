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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Doktor where DoktorTC=@a1 and DoktorSifre=@a2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", msktc.Text);
            cmd.Parameters.AddWithValue("@a2",txtsifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frm = new FrmDoktorDetay();
                frm.doktortc = msktc.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız","Uyarı",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }
    }
}
