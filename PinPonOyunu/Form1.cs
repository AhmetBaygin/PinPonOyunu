using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinPonOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer3.Enabled = true;
            timer5.Enabled = true;
            

        }
        Random r = new Random();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //1.oyuncu
            int x = label5.Location.X;
            int y = label5.Location.Y;
            if (e.KeyCode == Keys.W)
            {
                y = y - 20;
                label5.Location=new Point(x, y);
            }
            if (e.KeyCode == Keys.S)
            {
                y = y + 20;
                label5.Location = new Point(x, y);
            }
            
            //2.oyuncu
            int x2 = label6.Location.X;
            int y2= label6.Location.Y;
            if(e.KeyCode == Keys.Up)
            {
                y2=y2 - 20;
                label6.Location=new Point(x2, y2);
            }
            if(e.KeyCode == Keys.Down)
            {
                y2= y2 + 20;
                label6.Location= new Point(x2, y2);
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int top1 = r.Next(30, 35);
            pictureBox1.Left += top1;
            if(label6.Bottom>= pictureBox1.Top && label6.Top <=pictureBox1.Bottom && label6.Right >= pictureBox1.Left && label6.Left<= pictureBox1.Right)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int top1 = r.Next(30, 35);
            pictureBox1.Left -= top1;
            if (label5.Bottom >= pictureBox1.Top && label5.Top <= pictureBox1.Bottom && label5.Right >= pictureBox1.Left && label5.Left <= pictureBox1.Right)
            {
                timer2.Enabled=false;
                timer1.Enabled=true;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int top1 = r.Next(30, 35);
            pictureBox1.Top -= top1;
            if (pictureBox1.Top<label3.Bottom)
            {
                timer3.Enabled = false;
                timer4.Enabled = true;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int top1 = r.Next(30,35);
            pictureBox1.Top += top1;
            if (pictureBox1.Bottom>label4.Top)
            {
                timer4.Enabled = false;
                timer3.Enabled=true;
                }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            //yanması kaybetmeler
            if (pictureBox1.Left <= label1.Right)
            {
                timer5.Enabled = false;
                pictureBox1.Visible=false;
                MessageBox.Show("2. oyuncu kazandı");
                this.Close();
            }
            if (pictureBox1.Right >= label2.Left)
            {
                timer5.Enabled=false;
                pictureBox1.Visible = false;
                MessageBox.Show("1. oyuncu kazandı");
                this.Close();
            }
            {

            }
        }
    }
}
