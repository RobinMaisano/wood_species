using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace EssencesPierre
{
    public partial class Form1 : Form
    {

        string pathDirectoryImg = @".\img\";
        string imageName;
        List<string> list;
        List<string> storageList;
        Random random = new Random();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

        public Form1()
        {
            InitializeComponent();
            this.Text = "Essences de bois";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("wood-icon.ico")));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                list = Directory.GetFiles(pathDirectoryImg).ToList<string>();
                storageList = new List<String>(list);

                ChangeImage();
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de récupérer les images");
                Close();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == imageName)
            {
                textBox1.BackColor = SystemColors.Window;
                textBox1.Clear();
                ChangeImage();
            }
            else
            {
                textBox1.BackColor = Color.Red;
            }
        }

        private void ChangeImage()
        {
            if (list.Count == 0)
            {
                list = new List<string>(storageList);
                MessageBox.Show("On recommence !");
            }

            int i = random.Next(list.Count);
            string img = list[i];

            list.RemoveAt(i);
            AfficherImage(img);

            imageName = img.Replace(pathDirectoryImg, "").Split('.')[0].ToLower();
            //Console.WriteLine(imageName);
        }

        private void AfficherImage(string pathImg)
        {
            pictureBox1.Image = new Bitmap(pathImg);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = SystemColors.Window;
        }
    }
}
