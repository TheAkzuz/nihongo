using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace nihongo
{
    public partial class Form1 : Form
    {

        

        string line;

        int zop = 0;
        int lon = 0;
        int lim = 0;
        int r;
        string[,] glag = new string[256,3];
        Random random = new Random();
        int mode = 0;
        int hp = 3;
        int xp = 0;

        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Value = 2;
            numericUpDown1.Minimum = 2;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            
            label1.Visible = false;
      

           // numericUpDown1.Maximum = zop;
           
            while (r == lim )
            {
                r = random.Next(0, zop);
            }
            lim = r;
            string vie = glag[r,0];
            listView1.Items.Add(vie);
            listView2.Items.Clear();
            label8.Text = "правильный ответ:\n" + glag[r, 1];
        }

        string lol;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            lol = comboBox1.Text;

            if(lol == glag[r,1])
            {
                listView2.Items.Add("Верно");

                if (mode == 1)
                {
                    xp++;
                }
            }
            else
            {
                if (mode == 1)
                {
                    hp--;

                }
                listView2.Items.Add("Неверно");
            }
            label8.Text = "правильный ответ:\n"+ glag[r, 1];

            //listView2.Items.Add(lol);
            label6.Text = "Ваша жизнь = " + hp;
            label7.Text = "Правльных угаданых иероглифоф =" + xp;

            if (hp==0)
            {
                label8.Visible = true;
                mode = 0;
                label8.Text = "Жизнь кончилась.\nВаш счёт = " + xp + "\nперезапустите режим\n челенджа для повтора";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(comboBox2.Text + ".txt");
                listView1.Items.Clear();
                label1.Visible = true;
                label1.Text = "библиотека загружена";
                lon = 0;
            line = sr.ReadLine();
            int i = 0;
            while (line != null)
            {
                    lon++;
                string u = "";
                string y = "";
                    
                    int k = 0;
                    for (int a = 0; a < line.Length; a++)
                {
                   
                   
                    if (line[a] != '-' && line[a] != 'ー' && k ==0)
                    {
                        y = y + line[a];
                        // listView2.Items.Add(y);
                    }
                        if (line[a] == '-' || line[a] == 'ー')
                        {
                            k = 1;
                        }
                    if (line[a] != '-' && line[a] != 'ー' && k == 1)
                    {
                        u = u + line[a];
                            //listView2.Items.Add(Convert.ToString(line[a]));
                    }
                }
                    //listView2.Items.Add(u);
                    zop = lon;
                    glag[i, 0] = y;
                glag[i, 1] = u;
                i++;

                line = sr.ReadLine();
            }

        }
                        catch (System.IO.FileNotFoundException)
            {
                label1.Text = "файл не обнаружен";

            }
            while (glag[zop, 0] != null)
            {
                zop++;
            }
            numericUpDown1.Maximum = zop;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                listView3.Visible=true;
            }
            else
            {
                listView3.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label6.Visible = true;
                label7.Visible = true;
                mode = 1;
                xp = 0;
                hp = 3;
                label6.Text = "Ваша жизнь = " + hp;
                label7.Text = "Правльных угаданых иероглифоф =" + xp;
            }
            else
            {
                label8.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            string kan = "";
            if (checkBox3.Checked==true)
            {
                
                for(int i = 0; i<lon; i++)
                {
                    kan = glag[i, 0];
                    glag[i, 0] = glag[i, 1];
                    glag[i, 1] = kan;

                }

            }
            else
            {
                for (int i = 0; i < lon; i++)
                {
                    kan = glag[i, 1];
                    glag[i, 1] = glag[i, 0];
                    glag[i, 0] = kan;
                }
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            zop = Convert.ToInt32( numericUpDown1.Value);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked==true)
            {
                numericUpDown1.Visible = true;
                zop = Convert.ToInt32( numericUpDown1.Value);

            }
            if(checkBox4.Checked==false)
            {
                numericUpDown1.Visible = false;
                zop = lon-1;
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            if(checkBox5.Checked==true)
            {
                label8.Visible = true;
            }
            if(checkBox5.Checked == false)
            {
                label8.Visible = false;

            }

        }
    }
}
