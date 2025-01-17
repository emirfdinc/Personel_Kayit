﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EFD\\SQLDNC;Initial Catalog=Tbl_perver;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            //TOPLAM PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Table_Person", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())  //dr1 komutu okuma işlemi yaptığı müddetçe demek
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Table_Person Where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();
            //BEKAR PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Table_Person Where PerDurum=0",baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }
            
            baglanti.Close();

            //Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) From Table_Person", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lbltoplamsehir.Text = dr4[0].ToString();
            }
            baglanti.Close();
            //TOPLAM MAAŞ
            baglanti.Open ();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Table_Person", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltoplamMaas.Text = dr5[0].ToString();

            }
            baglanti.Close ();

            //ORTALAMA MAAŞ
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Table_Person", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortalamaMaas.Text = dr6[0].ToString();   
            }
            baglanti.Close () ;


        }
    }
}








