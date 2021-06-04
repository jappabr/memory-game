using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Parent = pictureBox1;
        }
        PictureBox[] card = new PictureBox[12];
        int[] vetorNum = new int[12];
        Random rnd = new Random();

        void GerarVetor()
        {
            int numCandidato = 0;
            int cont = 0;
            for (int i = 0; i < vetorNum.Length; i++)            
                vetorNum[i] = 0;
            for(int i=0; i<12; i++)
            {
                do
                {
                    numCandidato = rnd.Next(1, 7);
                    cont = 0;
                    foreach (int numero in vetorNum)
                    {
                        if (numCandidato == numero)
                            cont++;
                    }
                } while (cont == 2);
                vetorNum[i] = numCandidato;
                listBox1.Items.Add(vetorNum[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GerarVetor();
            int x = 0, y = 0;
            for(int i=0; i<12; i++)
            {
                if (x == 400)
                {
                    x = 0;
                    y +=100;
                }

                card[i] = new PictureBox();
                card[i].Parent = pictureBox1;
                card[i].Left += 200 + x;
                card[i].Top += 50 + y;
                card[i].Width = 80;
                card[i].Height = 80;
                card[i].Load("imagem" + vetorNum[i] + ".png");
                card[i].SizeMode = PictureBoxSizeMode.StretchImage;
                x += 100;
            }
        }
    }
}
