using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace araçkiralama2
{
    class Araç_Kiralama
    {
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KILAGJ7M;Initial Catalog=Araç_Kiralama;Integrated Security=True ");
        DataTable tablo;
        public void ekle_sil_güncelle(SqlCommand komut,string  sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
            

           
        }
        public DataTable listele(SqlDataAdapter adtr, string sorgu)
        {
            tablo = new DataTable();
            adtr = new SqlDataAdapter(sorgu, baglanti);
            adtr.Fill(tablo);
            baglanti.Close();

            return tablo;
        }
    }
}
