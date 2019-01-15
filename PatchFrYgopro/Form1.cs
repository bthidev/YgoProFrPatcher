using PatchFrYgopro.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                File.Copy("./Resources/cards.cdb", files.Replace("ygopro_vs_links.exe", "") + @"cards.cdb",true);
                File.Copy("./Resources/config", files.Replace("ygopro_vs_links.exe", "") + @"expansions\live2017links\.git\config",true);

                var frFile = File.ReadAllLines("./Resources/strings.conf");
                var frList = new List<string>(frFile).Where(w => w.StartsWith("!")).ToList();
                var enFile = File.ReadAllLines(files.Replace("ygopro_vs_links.exe", "") + @"strings.conf");
                var enList = new List<string>(enFile).Where(w => w.StartsWith("!")).ToList();
                var listFinal = new List<string>();
                listFinal.Add("#The first line is used for comment");
                Console.WriteLine(@"Trans strings.conf");
                foreach (var text in enList)
                {
                    var temp = text.Split(' ')[1];
                    var textAdd = "";
                    var index = frList.FindIndex(w => w.Split(' ')[1] == text.Split(' ')[1]);
                    if (index>=0)
                    {
                        textAdd = frList[index];
                    }
                    else
                    {
                        textAdd =text ;
                    }
                    listFinal.Add(textAdd);
                }
                File.WriteAllLines(files.Replace("ygopro_vs_links.exe", "") + @"strings.conf", listFinal.Distinct().ToArray());
            }
            MessageBox.Show("Patch fini :) !");
        }
    }
}
