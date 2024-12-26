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
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace Personel_Kayit
{
    public partial class frmana : Form
    {
        public frmana()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EFD\\SQLDNC;Initial Catalog=Tbl_perver;Integrated Security=True");

        void temizle()
        {
            Txtid.Text = "";
            Txtad.Text = "";
            Txtsoyad.Text = "";
            Txtmeslek.Text = "";
            Cmbsehir.Text = "";
            Mskmaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Txtad.Focus();
                

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frmgrup frg = new Frmgrup();
            frg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.table_personTableAdapter.Fill(this.tbl_perverDataSet1.Table_person);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {   // İNSERT KOMUTU İLE EKLEME ÖRNEĞİ
            baglanti.Open();
            SqlCommand komut= new SqlCommand("insert into Table_Person(perad,persoyad,persehir,permaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",Cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", Mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", Txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text= "False";
            }  
        }

        private void btntemizlik_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            Cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            Mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            Txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
           
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil=new SqlCommand("Delete From Table_person Where perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",Txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
            

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Table_Person Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7",baglanti);

            komutguncelle.Parameters.AddWithValue("@a1",Txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2",Txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3",Cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4",Mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5",label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", Txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", Txtid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellendi");
            //UPDATE İLE GÜNCELLEME
            
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
