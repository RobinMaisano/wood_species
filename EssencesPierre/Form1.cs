﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EssencesPierre
{
    public partial class Form1 : Form
    {

        string pathDirectoryImg = @".\img\";
        string imageName;
        string[] list;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                list = Directory.GetFiles(pathDirectoryImg);

                changeImage();
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de récupérer les images");
                Close();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            changeImage();
        }

        private void changeImage()
        {
            int i = random.Next(list.Length);
            string img = list[i];

            afficherImage(img);
        }

        private void afficherImage(string pathImg)
        {
            pictureBox1.Image = new Bitmap(pathImg);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}