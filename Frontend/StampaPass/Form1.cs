using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StampaPass
{

    public partial class StampaPass : Form
    {
        private string nominativo;
        private string prtBadge;
        private string dataCheckin;

        public StampaPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string badge = txtBadge.Text;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("http://localhost:8090/guests/checkin/" + badge).Result;
            if(response.IsSuccessStatusCode)
            {
                var jSonString = response.Content.ReadAsStringAsync().Result;
                dynamic guest = JsonConvert.DeserializeObject<object>(jSonString);
                dynamic data = guest.data;
                string cognome = data.cognome;
                string nome = data.nome;
                this.nominativo = data.nome + " " + data.cognome;
                this.prtBadge = data.badge;
                this.dataCheckin = data.dataarrivo;
                txtBadge.Text = "";
                printDocument1.PrintPage += PrintPage;
                printDocument1.Print();
                MessageBox.Show("Checkin effettuato per " + this.nominativo, "Badge inserito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = MessageBox.Show("Non è stato trovato alcun ospite con il badge " + txtBadge.Text, "Badge inserito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            client.Dispose();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            PointF nameLocation = new PointF(100F, 200F);
            PointF badgeLocation = new PointF(100F, 500F);
            PointF dateLocation = new PointF(100F, 550F);
            using (Font arialFont = new Font("Arial", 24))
            {
                e.Graphics.DrawString(this.nominativo, arialFont, Brushes.Black, nameLocation);
            }
            using (Font arialFont = new Font("Arial", 16))
            {
                e.Graphics.DrawString(this.prtBadge, arialFont, Brushes.Black, badgeLocation);
                e.Graphics.DrawString(this.dataCheckin, arialFont, Brushes.Black, dateLocation);
            }
            e.HasMorePages = false;
        }

        private void ReadConfig()
        {
            string path = @"config.txt";
            using (FileStream fs=File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
            }
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            this.bitmap = (Bitmap) Image.FromFile("D:\\projects\\stampapass\\Frontend\\StampaPass\\Resources\\A5-01.jpg");
            PointF nameLocation = new PointF(100F, 1100F);
            PointF badgeLocation = new PointF(100F, 2000F);
            PointF dateLocation = new PointF(100F, 2100F);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 24))
                {
                    graphics.DrawString("Roberto Ercolano,", arialFont, Brushes.Black, nameLocation);
                }
                using (Font arialFont = new Font("Arial", 16))
                {
                    graphics.DrawString("1A3344299EF3388288", arialFont, Brushes.Black, badgeLocation);
                    graphics.DrawString("02/10/2021", arialFont, Brushes.Black, dateLocation);
                }
            }
            pictureBox1.Image = bitmap;

            printDocument1.PrintPage += PrintPage;
            printDocument1.Print();
            //bitmap.Save("D:\\projects\\stampapass\\Frontend\\StampaPass\\Resources\\A5-02.jpg");
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(this.bitmap, loc);
        }
        */
    }
}
