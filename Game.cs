using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace 酷炫踩地雷
{
    public partial class Game : Form
    {
        public static SoundPlayer su;
        public static SoundPlayer sustart;
        public static ArrayList bboom;
        public static Button[,] b ;
        public static Label l;
        public static ArrayList win;
        public static Random rd = new Random();
        public static bool bob = false;
        public int bom = 0;
        public bool bb = true;
        public bool start = false;
        public bool error = false;
        public static int  hide = 0;
        public static PictureBox p;
        public static PictureBox pp;
        public static int ss,sm;
        public static Label ll;
        public static int bum;
        public Game()
        {
            InitializeComponent();
            start = false;
            bob = false;
            bom = 0;
            bb = true;
            ss = 1;
            sm = 0;
            bum = Form1.bum;
            win = new ArrayList();
            bboom = new ArrayList();
            l = new Label();
            ll = new Label();
            b = new Button[Form1.ah, Form1.aw];
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 15;
            if (win != null)
            {
                win.Clear();
            }  
            if(hide == 3)
            {
                this.Text = "酷炫踩大便";
                this.BackColor = Color.LightPink;
                int a = rd.Next(1,3);
                if(a == 1)
                {
                    axWindowsMediaPlayer1.URL = Path.GetFullPath("../../Pictures/hide01.wav");
                    axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 40;
                }
                else
                {
                    axWindowsMediaPlayer1.URL = Path.GetFullPath("../../Pictures/hide02.mp3");
                    axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 40;
                }
                //axWindowsMediaPlayer1.star
            }
             if(bboom.Count != 0) bboom.Clear();
            //this.ControlBox = false;   // 设置不出现关闭按钮
            for (int i = 0; i < Form1.ah; i++)
            {
                for (int j = 0; j < Form1.aw; j++)
                {
                   b[i, j] = new Button();
                   b[i, j].Size = new Size(40, 40);
                   b[i, j].Location = new Point( j * 39,i * 39);
                    if (Set_Color.OK == true)
                    {
                        b[i, j].BackColor = Color.FromArgb(255, Set_Color.buttoncolor[0], Set_Color.buttoncolor[1], Set_Color.buttoncolor[2]);
                    }
                    else b[i, j].BackColor = Color.LightBlue;
                    b[i, j].Text = "";
                   b[i, j].ForeColor = Color.FromArgb(0,b[i, j].BackColor);
                   b[i, j].Name = i + "," + j;
                   b[i, j].Font = new Font("新細明體", 12.2F);
                   bboom.Add("");
                   win.Add(i + "," + j);
                }
            }
            p = new PictureBox();
            p.Location = new Point(0, 0);
            p.Size = new Size(65, 65);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            //     this.WindowState = FormWindowState.Maximized;
            if ((Double)(Form1.bum) / ((Double)Form1.ah * (Double)Form1.aw) <= 0.20)
            {
                if (hide != 3)
                {
                    int a = rd.Next(1, 5);
                    if(a == 4)
                    {
                        axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\green04.wav");
                        axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 50;
                    }
                    else
                    {
                        axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\green0"+a+".mp3");
                    }
                    axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 50;
                }
                Bitmap pbitmap = new Bitmap(Properties.Resources.lv1);
                pbitmap.MakeTransparent(Color.White);
                p.Image = pbitmap;
              //  p.ImageLocation = "../../Pictures/lv1.png";
            }
            else if((Double)(Form1.bum) / ((Double)Form1.ah * (Double)Form1.aw) <= 0.42)
            {
                int a = rd.Next(1, 4);
                if (hide != 3) axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\yellow0"+a+".mp3");
                Bitmap pbitmap = new Bitmap(Properties.Resources.lv2);
                pbitmap.MakeTransparent(Color.White);
                p.Image = pbitmap;
               // p.ImageLocation = "../../Pictures/lv2.png";
            }
            else if ((Double)(Form1.bum) / ((Double)Form1.ah * (Double)Form1.aw) <= 0.65)
            {
                if (hide != 3) axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\BGM魔王.mp3");
                Image image = Properties.Resources.lv3;
                Bitmap pbitmap = new Bitmap(image);
                pbitmap.MakeTransparent(Color.White);
                p.Image = pbitmap;
               // p.ImageLocation = "../../Pictures/lv3.png";
            }
            else
            {
                Image image = Properties.Resources._87;
                Bitmap pbitmap = new Bitmap(image);
                pbitmap.MakeTransparent(Color.White);
                p.Image = pbitmap;
            }
            this.Controls.Add(p);
          
            //   this.Contains.
            for (int i = 0; i < Form1.ah; i++)//**************            按紐新增事件
            {
                for (int j = 0; j < Form1.aw; j++)
                {
                    this.Controls.Add(b[i,j]);
                    b[i, j].Click += new EventHandler(this.bucl);
                    b[i, j].MouseDown += new MouseEventHandler(this.buright);
                }
            }
            for (int i = 0; i < Form1.ah; i++)
            {
                for (int j = 0; j < Form1.aw; j++)
                {
                    b[i, j].Anchor = AnchorStyles.None;
                }
            }
            this.Width = this.Width+150 ;
            this.Height = this.Height +80;         
            int hh =0;
         //   if (Form1.ah >= 19) hh = 100;
            for (int i = 0; i < Form1.ah; i++)
            {
                hh += b[i, 0].Height;
            }
            int ww = 90;
            for (int i = 0; i < Form1.aw; i++)
            {
                ww += b[0, i].Width;
            }
            this.AutoScrollMinSize = new Size(ww, hh + Form1.ah*2+30);

            l.Font = new Font("新細明體",16);
            l.Location = new Point((this.Width / 2)-100, b[0, 0].Location.Y -30);
            l.ForeColor = Color.Red;
            l.Anchor = AnchorStyles.None;
            this.Controls.Add(l);

            pp = new PictureBox();
            pp.Location = new Point(l.Right, b[0, 0].Location.Y - 30);
            pp.Size = new Size(30, 30);
            pp.Anchor = AnchorStyles.None;
            this.Controls.Add(pp);

            ll.Font = new Font("新細明體", 16);
            ll.Location = new Point(pp.Right, b[0, 0].Location.Y - 30);
            ll.ForeColor = Color.Black;
            ll.Anchor = AnchorStyles.None;
            ll.Text = bum.ToString();
            this.Controls.Add(ll);

            if (hide == 3)
            {
                Bitmap pbitmap = new Bitmap(Properties.Resources.shitt);
                pbitmap.MakeTransparent(Color.White);
                pp.Image = pbitmap;
            }
            else
            {
                Bitmap pbitmap = new Bitmap(Properties.Resources._123);
                pbitmap.MakeTransparent(Color.White);
                pp.Image = pbitmap;
            }
            pp.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void bucl(object sender, EventArgs e)//**************            按鈕Click
        {
            int music = rd.Next(1, 10);
            if (start == false)
            {
                l.Text = sm.ToString("00") + "：" +"00";
                Startgame.Enabled = true;
                start = true;
                int rdd;
                int ahd;
                int awd;
                for (int i = 0; i < Form1.bum; i++)
                {
                    bool z = false;
                    rdd = rd.Next(Form1.ah * Form1.aw);
                    ahd = rdd / Form1.aw;
                    awd = rdd - ahd * Form1.aw;
                    string[] aaa = new string[1];
                    aaa = ((Button)(sender)).Name.Split(',');
                    if (bboom[rdd].ToString() != "b")
                    {
                        for(int ii = Convert.ToInt16(aaa[0])-1; ii < Convert.ToInt16(aaa[0]) +2;ii++)
                        {
                            for(int jj = Convert.ToInt16(aaa[1]) - 1; jj < Convert.ToInt16(aaa[1]) +2; jj++)
                            {
                                if(ahd == ii && awd == jj)
                                {
                                    z = true;
                                    break;
                                }
                            }
                            if (z == true) break;
                        }
                        if(z == true)
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            bboom[rdd] = "b";
                        }
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                    for (int ii = ahd - 1; ii < ahd + 2; ii++)
                    {
                        for (int jj = awd - 1; jj < awd + 2; jj++)
                        {
                            if (ii >= 0 && jj >= 0 && ii < Form1.ah && jj < Form1.aw)
                            {
                                if (bboom[ii * Form1.aw + jj].ToString() == "" && bboom[ii * Form1.aw + jj].ToString() != "b") bboom[ii * Form1.aw + jj] = "1";
                                else if (bboom[ii * Form1.aw + jj].ToString() != "b") bboom[ii * Form1.aw + jj] = (Convert.ToInt16(bboom[ii * Form1.aw + jj].ToString()) + 1).ToString();
                            }
                        }
                    }
                    //b[awd, ahd].Text = (awd - 1 >= 0)?b[awd, ahd].Text == "" ?  "1" : Convert.ToInt16((b[awd, ahd].Text) +1).ToString() : "";
                }
            }
       
            if (bob != true && ((Button)(sender)).Image == null)
            {
                string[] aaa = new string[1];
                aaa = ((Button)(sender)).Name.Split(',');
                if (bboom[Convert.ToInt32(aaa[0])*Form1.aw + Convert.ToInt32(aaa[1])].ToString() == "b")
                {
                    if(hide == 3)
                    {
                        axWindowsMediaPlayer1.close();
                        su = new SoundPlayer("../../Pictures/淒涼.wav");
                        su.Play();
                    }
                    else
                    {
                        axWindowsMediaPlayer1.close();
                        su = new SoundPlayer("../../Pictures/爆炸.wav");
                        su.Play();
                    }
                    Startgame.Enabled = false;
                    for (int i = 0; i < Form1.ah; i++)
                    {
                        for (int j = 0; j < Form1.aw; j++)
                        {
                            if (bboom[Convert.ToInt32(i) * Form1.aw + Convert.ToInt32(j)].ToString() == "b")
                            {
                                b[i, j].BackColor = Color.White;
                                b[i, j].FlatStyle = FlatStyle.Flat;
                                // b[i, j].Image = Image.FromFile("../../Pictures/Draziw.Button.Mines_2.png");
                                if (hide == 3)
                                {
                                    b[i, j].Image = Properties.Resources.shit1;
                                }
                                else
                                {
                                    b[i, j].Image = Properties.Resources._123;
                                }                      
                            }
                        }
                        if(hide == 3)
                        {
                            ((Button)(sender)).Image = Properties.Resources.shitclick;
                        }
                        else
                        {
                            ((Button)(sender)).Image = Properties.Resources.clickBoom;
                        }
                    }
                    Boom.Enabled = true;
                    bob = true;
                    return;
                }
                else
                {
                    su = new SoundPlayer("../../Pictures/踩0" + music + ".wav");
                    su.Play();
                    Recursive(Int16.Parse(aaa[0]), Int16.Parse(aaa[1]));
                    if (win.Count == Form1.bum)
                    {
                        bob = true;
                        Startgame.Enabled = false;
                        for (int i = 0; i < Form1.ah; i++)
                        {
                            for (int j = 0; j < Form1.aw; j++)
                            {
                                if (bboom[i*Form1.aw +j].ToString()== "b")
                                {
                                    b[i, j].BackColor = Color.White;
                                    b[i, j].FlatStyle = FlatStyle.Flat;
                                    b[i, j].Text = "";
                                    // b[i, j].Image = Image.FromFile("../../Pictures/Draziw.Button.Mines_2.png");
                                    if (hide == 3)
                                    {
                                        b[i, j].Image = Properties.Resources.winshit;
                                    }
                                    else
                                    {
                                        b[i, j].Image = Properties.Resources._123;
                                    }
                                }
                            }
                        }
                        if (hide == 3)
                        {
                            axWindowsMediaPlayer1.close();
                            su = new SoundPlayer("../../Pictures/進入.wav");
                            su.Play();
                            Wingame.Enabled = true;
                        }
                        else
                        {
                            axWindowsMediaPlayer1.close();
                            su = new SoundPlayer("../../Pictures/進入.wav");
                            su.Play();
                            Wingame.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                if(bob != true)
                {
                su = new SoundPlayer("..\\..\\Pictures\\錯誤紐.wav");
                su.Play();
                }
            }
        }

        public void buright(object sender , MouseEventArgs e) //**************            右鍵Click
        {
            if(bob != true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int music = rd.Next(1, 10);
                    su = new SoundPlayer("../../Pictures/踩0"+ music +".wav");
                    su.Play();
                    if (((Button)(sender)).Image == null)
                    {
                        ((Button)(sender)).Image =  Properties.Resources.宇;
                        bum--;
                        ll.Text = (bum).ToString();
                    }   
                    else
                    {
                        bum++;
                        ll.Text = (bum).ToString();
                        ((Button)(sender)).Image = null;
                    }
                }
                  
            }
          
        }
        private void Game_Load(object sender, EventArgs e)
        { 
        }
        private static void Recursive(int h, int w)//**************            遞迴
        {
            if(bob == false)
            {
                if (bboom[h*Form1.aw+w].ToString() == "" && b[h, w].Enabled == true)
                {
                    win.Remove(h + "," + w);
                    b[h, w].Enabled = false;
                    b[h, w].Image = null;
                    b[h, w].BackColor = Color.White;
                    b[h, w].FlatStyle = FlatStyle.Flat;
                    if (h - 1 >= 0 && b[h-1,w].Image == null) Recursive(h - 1, w);
                    if (h + 1 < Form1.ah && b[h + 1, w].Image == null) Recursive(h + 1, w);
                    if (w - 1 >= 0 && b[h, w-1].Image == null) Recursive(h, w - 1);
                    if (w + 1 < Form1.aw && b[h, w+1].Image == null) Recursive(h, w + 1);
                    if (h - 1 >= 0 && w - 1 >= 0 && b[h - 1, w - 1].Image == null) Recursive(h - 1, w-1);
                    if (w + 1 < Form1.aw && h + 1 < Form1.ah && b[h+1, w + 1].Image == null) Recursive(h+1, w + 1);
                    if (h + 1 < Form1.ah && w - 1 >= 0 && b[h + 1, w - 1].Image == null) Recursive(h + 1, w - 1);
                    if (w + 1 < Form1.aw && h - 1 >= 0 && b[h - 1, w + 1].Image == null) Recursive(h -1 , w + 1);
                }
                else
                {
                    win.Remove(h + "," + w);
                    b[h, w].Enabled = false;
                    b[h, w].BackColor = Color.White;
                    b[h, w].FlatStyle = FlatStyle.Flat;
                    b[h, w].Text = bboom[h * Form1.aw + w].ToString();
                    b[h, w].Image = null;
                    if (b[h, w].Text != "")
                    {
                        if (b[h, w].Text == "1") b[h, w].BackColor = Color.FromArgb(12, Color.Aqua);
                        else if (b[h, w].Text == "2") b[h, w].BackColor = Color.FromArgb(50, Color.LawnGreen);
                        else if (b[h, w].Text == "3") b[h, w].BackColor = Color.FromArgb(40, Color.Orange);
                        else if (Convert.ToInt16(b[h, w].Text) >= 4) b[h, w].BackColor = Color.FromArgb(40, Color.Red);
                    }
                }
            }
          
        }
        private void Boom_Tick(object sender, EventArgs e)//**************            閃爍效果
        { 
            bom += 1;
            if (bom == 6)
            {
                if (hide == 3)
                {
                    Boom.Enabled = false; (new Boom()).ShowDialog(); this.BackColor = Color.Snow; MessageBox.Show("你踩到大便了\r\n\r\n呵呵\r\n\r\n大便人");
                }
                else
                {
                    Boom.Enabled = false; (new Boom()).ShowDialog(); this.BackColor = Color.Snow; MessageBox.Show("你踩到炸彈了");
                }
            }
            else if (bb == true)
            {
                if(hide == 3)
                {
                    this.BackColor = Color.FromArgb(255, 210, 105, 30);
                }
              else this.BackColor = Color.Tomato;
            }
            else
            {
                 this.BackColor = Color.Snow;  
            }
            bb = bb ? false : true;      
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)//**************            關閉事件
        {
            if(error == false)
            {
                DialogResult d = new DialogResult();
                d = MessageBox.Show("確定要離開遊戲?", "離開確認", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    axWindowsMediaPlayer1.close();
                    if(su!= null)
                    su.Stop();
                    this.Dispose();
                }
                else
                {
                    if (hide == 2)
                    {
                        hide++;
                        this.Dispose();
                    }
                    else
                    {
                        if (hide != 3)
                        {
                            hide++;
                        }
                    e.Cancel = true;
                    }
                }
            }
            else
            {
                error = false;
                if (su != null)
                    su.Stop();
                this.Dispose();
            }
        }

        private void Wingame_Tick(object sender, EventArgs e)
        {
            bom += 1;
            if (bom == 8)
            {
                if (hide == 3)
                {
                    Wingame.Enabled = false;(new Boom()).ShowDialog(); this.BackColor = Color.Snow; MessageBox.Show("你贏了!!\r\n\r\n你是大便王!!");
                }
                else
                {
                    Wingame.Enabled = false; this.BackColor = Color.Snow; MessageBox.Show("你贏了!!!\r\n\r\n你是炸彈王嗎，真厲害");
                }
            }
            else if (bb == true)
            {
                if (hide == 3)
                {
                    this.BackColor = Color.FromArgb(255, 0, 255, 0);
                }
                else this.BackColor = Color.Green;
            }
            else
            {
                this.BackColor = Color.Snow;
            }
            bb = bb ? false : true;
        }

        private void hidemusic_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.GetFullPath("../../Pictures/bgm_maoudamashii_piano17.wav");
            //   su = new SoundPlayer("../../Pictures/bgm_maoudamashii_piano17.wav");
            //   su.Play();
        }

        private void bossmusic_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\BGM魔王.mp3");
        }

        private void greenmusic_Tick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\green.wav");
        }

        private void Startgame_Tick(object sender, EventArgs e)
        {
            l.Text = sm.ToString("00") + "：" + ss.ToString("00");
            ss+= 1;
            if(ss == 60)
            {
                ss = 0;
                sm += 1;
            }
        }
    }
}
