using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace araçkiralama2
{
    public partial class frmAraçKayıt : Form
    {
        Araç_Kiralama arackiralama = new Araç_Kiralama();
        public frmAraçKayıt()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                //if (Markacombo.SelectedItem.ToString()=="Opel")
                 if (Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("astra");
                    Sericombo.Items.Add("vectra");
                    Sericombo.Items.Add("corsa");



                }
                else if (Markacombo.SelectedIndex==1)
                {
                    Sericombo.Items.Add("megane");
                    Sericombo.Items.Add("clio");
                   

                }
                else if (Markacombo.SelectedIndex==2)
                {
                    Sericombo.Items.Add("linea");
                    Sericombo.Items.Add("egea");
                  

                }
                else if (Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("fiesta");
                    Sericombo.Items.Add("focus");
                   


                }

            }
            catch 
            {
                ;
               
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        { 
            string cümle = "insert into araç(plaka,marka,seri,yil,renk,km,yakit,kiraucreti,resim,tarih,durumu) values(@plaka,@marka,@seri,@yil,@renk,@km,@yakit,@kiraucreti,@resim,@tarih,@durumu)";
            var a = pictureBox1.ImageLocation;
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@yil", Yiltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renkcombo.Text);  
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit",Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraucreti",int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "BOŞ");
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            Sericombo.Items.Clear();

            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";

            pictureBox1.ImageLocation = "";




        }

     

        

        private void Sericombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
