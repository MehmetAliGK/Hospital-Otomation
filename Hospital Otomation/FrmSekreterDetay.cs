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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
       
        public string Tcno;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            // TC ve Ad Soyad Çekme
            lbltc.Text = Tcno;
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter1 where SekreterTC=@a1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@a1", lbltc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               lbladsoyad.Text = dr[0].ToString();

            }
            bgl.baglanti();

            //Branşları datagrid'e çekme

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from Tbl_Brans ",bgl.baglanti());
            da.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //Doktorları datagrid'e çekme
            
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+DoktorSoyad),DoktorBrans from Tbl_Doktor",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;
             
            //Branşları combobox'a Çekme

            SqlCommand cmd3 = new SqlCommand("Select BransAd from Tbl_Brans", bgl.baglanti());
            SqlDataReader dr2 = cmd3.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("insert into Tbl_Randevular (randevutarih,randevusaat,randevubrans,randevudoktor) values (@a1,@a2,@a3,@a4)",bgl.baglanti());
            cmd2.Parameters.AddWithValue("@a1", msktarih.Text);
            cmd2.Parameters.AddWithValue("@a2", msksaat.Text);
            cmd2.Parameters.AddWithValue("@a3", cmbbrans.Text);
            cmd2.Parameters.AddWithValue("@a4", cmbdoktor.Text);
            cmd2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Başarılı");
         }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            
            SqlCommand cmd5 = new SqlCommand("select (DoktorAd+DoktorSoyad) from Tbl_Doktor Where DoktorBrans=@b1", bgl.baglanti());
            cmd5.Parameters.AddWithValue("@b1", cmbbrans.Text);
            SqlDataReader dr4 = cmd5.ExecuteReader();
            while (dr4.Read())
            {
                cmbdoktor.Items.Add(dr4[0]);
            }
            bgl.baglanti().Close();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnduyuruolustur_Click(object sender, EventArgs e)
        {
            SqlCommand cmd7 = new SqlCommand("insert into Tbl_Duyurular (duyuru) values(@d1)",bgl.baglanti());
            cmd7.Parameters.AddWithValue("@d1", rchduyuru.Text);
            cmd7.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyurunuz Oluşturuldu");

        }

        private void btndoktorpanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frm = new FrmDoktorPaneli();
            frm.Show();
            
        }

        private void btnbranspanel_Click(object sender, EventArgs e)
        {
            Frmbrans frm = new Frmbrans();
            frm.Show();
        }

        private void btnliste_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frm = new FrmRandevuListesi();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();

        }
    }
}
