using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace 酷炫踩地雷
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            (new 酷炫()).ShowDialog();
            InitializeComponent();

        }
        SoundPlayer sp ;
        public Game g;
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("想進入酷炫的隱藏模式嗎?\r\n在進入踩地雷遊戲後，點擊關閉視窗會跳出   \"確定要離開遊戲? \"     請連續點選三次\"否\"");
         }
        public static int aw, ah, bum;
        public static bool hide = false;

        private void button2_Click(object sender, EventArgs e)
        {
            (new Set_Color()).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bum = Int16.Parse(textBox3.Text);
                if (textBox3.Text == "" || bum == 0)
                {
                    if (Game.hide == 3)
                    {
                        MessageBox.Show("踩大便，不是踩空白");
                    }
                    else
                    {
                        MessageBox.Show("踩炸彈，不是踩空白");
                    } 
                    return;
                }
                aw = Int16.Parse(textBox1.Text);
                ah = Int16.Parse(textBox2.Text);
                if(aw < 10 || ah < 10)
                {
                    MessageBox.Show("下限為10x10");
                    return;
                }
                if ((Convert.ToDouble(bum)/Convert.ToDouble(aw * ah)) >0.85)
                {
                    if (Game.hide == 3)
                    {
                        MessageBox.Show("大便太多了\r\n你會被大便淹死歐");
                        MessageBox.Show("大便數最多為：" +((int)(Convert.ToDouble(aw * ah) * 0.85)).ToString()+"坨");
                    }
                    else
                    {
                        MessageBox.Show("你的炸彈太多了");
                        MessageBox.Show("炸彈數最多為：" + ((int)(Convert.ToDouble(aw * ah) * 0.85)).ToString().ToString()+"顆");
                    }
                    return;
                }
                g = null;
                g = new Game();
                this.Hide();
                g.ShowDialog();
                if (Game.hide == 3 && hide != true)
                {
                    hide = true;
                    this.Text = "酷炫踩大便";
                    label2.Text = "大便數";
                }
                else if (hide == true)
                {
                    Game.hide++;
                    this.Text = "酷炫踩炸彈";
                    label2.Text = "炸彈數";
                }
                this.Show();
          }
         catch
         {
           MessageBox.Show("輸入錯誤");
          }          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
 }
