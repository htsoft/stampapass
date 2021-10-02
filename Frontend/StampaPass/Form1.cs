using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StampaPass
{

    public partial class Form1 : Form
    {
        private Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }

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
    }
}
