using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatchFrYgopro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ygopro_vs_links.exe |ygopro_vs_links.exe";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string files = openFileDialog1.FileName;
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri("http://ygomanager.diypiandco.com/ygomanager/upload/Percy/cards.cdb"), files.Replace("ygopro_vs_links.exe", "")+ @"cards.cdb");
                    client.DownloadFile(new Uri("http://ygomanager.diypiandco.com/ygomanager/upload/Percy/config"), files.Replace("ygopro_vs_links.exe", "")+ @"expansions\live2017links\.git\config");
                }
            }
            MessageBox.Show("Patch fini :) !");
        }
    }
}
