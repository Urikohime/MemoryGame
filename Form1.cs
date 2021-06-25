using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Projekt
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        bool selected = false;
        int count = 0;
        int left = 8;
        int firstC;
        int Firstc;
        Point xy = new Point(12, 12);
        Bitmap[] panels = new Bitmap[] {
            Properties.Resources.one, Properties.Resources.two,
            Properties.Resources.three, Properties.Resources.four,
            Properties.Resources.five, Properties.Resources.six,
            Properties.Resources.seven, Properties.Resources.eight,};

        List<PictureBox> Panels = new List<PictureBox>();
        int[] set = new int[16] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };

        Image backpanel = Properties.Resources.backpanel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.MouseClick += new MouseEventHandler(start);
            label1.Text = "START?";
        }

        private async void OnPicClick(object sender, EventArgs e)
        {
            PictureBox PB = (PictureBox)sender;
            if (!selected && Panels.IndexOf(PB) != Firstc)
            {
                for (int an = 0; an < 10; an++)
                {
                    PB.Size = new Size(PB.Size.Width - 10, PB.Size.Height);
                    PB.Location = new Point(PB.Location.X + 5, PB.Location.Y);
                    await Task.Delay(1);
                }
                PB.Image = SetImg(PB.Name);
                for (int an = 0; an < 10; an++)
                {
                    PB.Size = new Size(PB.Size.Width + 10, PB.Size.Height);
                    PB.Location = new Point(PB.Location.X - 5, PB.Location.Y);
                    await Task.Delay(1);
                }
                count += 1;
                if (count == 1)
                {
                    firstC = int.Parse(PB.Name);
                    Firstc = Panels.IndexOf(PB);
                }
                if (firstC == int.Parse(PB.Name) && count == 2)
                {
                    selected = true;
                    await Task.Delay(1000);
                    for (int an = 0; an < 10; an++)
                    {
                        PB.Size = new Size(PB.Size.Width - 10, PB.Size.Height - 10);
                        PB.Location = new Point(PB.Location.X + 5, PB.Location.Y + 5);
                        Panels[Firstc].Size = new Size(Panels[Firstc].Size.Width - 10, Panels[Firstc].Size.Height - 10);
                        Panels[Firstc].Location = new Point(Panels[Firstc].Location.X + 5, Panels[Firstc].Location.Y + 5);
                        await Task.Delay(1);
                    }
                    Panels[Panels.IndexOf(PB)].Visible = false;
                    Panels[Firstc].Visible = false;
                    PB.Size = new Size(0, 100);
                    PB.Location = new Point(PB.Location.X - 50, PB.Location.Y - 50);
                    Panels[Firstc].Size = new Size(0, 100);
                    Panels[Firstc].Location = new Point(Panels[Firstc].Location.X - 50, Panels[Firstc].Location.Y - 50);

                    count = 0;
                    left -= 1;
                    selected = false;
                    Firstc = -1;
                }
                else if (count == 2)
                {
                    selected = true;
                    await Task.Delay(1000);
                    count = 0;
                    for (int an = 0; an < 10; an++)
                    {
                        PB.Size = new Size(PB.Size.Width - 10, PB.Size.Height);
                        PB.Location = new Point(PB.Location.X + 5, PB.Location.Y);
                        Panels[Firstc].Size = new Size(Panels[Firstc].Size.Width - 10, Panels[Firstc].Size.Height);
                        Panels[Firstc].Location = new Point(Panels[Firstc].Location.X + 5, Panels[Firstc].Location.Y);
                        await Task.Delay(1);
                    }
                    PB.Image = backpanel;
                    Panels[Firstc].Image = backpanel;
                    for (int an = 0; an < 10; an++)
                    {
                        PB.Size = new Size(PB.Size.Width + 10, PB.Size.Height);
                        PB.Location = new Point(PB.Location.X - 5, PB.Location.Y);
                        Panels[Firstc].Size = new Size(Panels[Firstc].Size.Width + 10, Panels[Firstc].Size.Height);
                        Panels[Firstc].Location = new Point(Panels[Firstc].Location.X - 5, Panels[Firstc].Location.Y);
                        await Task.Delay(1);
                    }
                    Firstc = -1;
                    selected = false;
                }
                if (left == 0)
                {
                    PictureBox sho = new PictureBox();
                    sho.ClientSize = new Size(100, 100);
                    sho.SizeMode = PictureBoxSizeMode.StretchImage;
                    sho.Location = new Point((this.Size.Width  / 2) - 50, (this.Size.Height / 2) - 50);
                    PB.Image = backpanel;
                    this.Controls.Add(sho);
                    sho.Visible = true;
                    foreach (Bitmap Imm in panels)
                    {
                        for (int an = 0; an < 10; an++)
                        {
                            sho.Size = new Size(sho.Size.Width - 10, sho.Size.Height);
                            sho.Location = new Point(sho.Location.X + 5, sho.Location.Y);
                            await Task.Delay(1);
                        }
                        sho.Image = Imm;
                        for (int an = 0; an < 10; an++)
                        {
                            sho.Size = new Size(sho.Size.Width + 10, sho.Size.Height);
                            sho.Location = new Point(sho.Location.X - 5, sho.Location.Y);
                            await Task.Delay(1);
                        }
                        await Task.Delay(150);
                        for (int an = 0; an < 10; an++)
                        {
                            sho.Size = new Size(sho.Size.Width - 10, sho.Size.Height);
                            sho.Location = new Point(sho.Location.X + 5, sho.Location.Y);
                            await Task.Delay(1);
                        }
                        sho.Image = backpanel;
                        for (int an = 0; an < 10; an++)
                        {
                            sho.Size = new Size(sho.Size.Width + 10, sho.Size.Height);
                            sho.Location = new Point(sho.Location.X - 5, sho.Location.Y);
                            await Task.Delay(1);
                        }
                        await Task.Delay(150);
                    }
                    for (int an = 0; an < 10; an++)
                    {
                        sho.Size = new Size(sho.Size.Width - 10, sho.Size.Height);
                        sho.Location = new Point(sho.Location.X + 5, sho.Location.Y);
                        await Task.Delay(1);
                    }
                    sho.Visible = false;
                    label1.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                }
            }
        }

        private async void start(object sender, EventArgs e)
        {
            button1.MouseClick += new MouseEventHandler(button1_Click);
            count = 0;
            left = 8;
            firstC = 20;
            Firstc = 20;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            for (int i = 0; i < 16; i++)
            {
                Panels.Add(new PictureBox());
                Panels[i].Name = SetInd().ToString();
                Panels[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Panels[i].Image = backpanel;
                Panels[i].ClientSize = new Size(0, 100);
                Panels[i].Location = xy;
                xy.X += 103;
                if (xy.X >= 330)
                {
                    xy.X = 12;
                    xy.Y += 103;
                }
                Panels[i].Visible = true;
                Panels[i].MouseClick += new MouseEventHandler(OnPicClick);
            }
            foreach (PictureBox PB in Panels)
            {
                this.Controls.Add(PB);
                for (int an = 0; an < 10; an++)
                {
                    PB.Size = new Size(PB.Size.Width + 10, PB.Size.Height);
                    PB.Location = new Point(PB.Location.X, PB.Location.Y);
                    PB.BackColor = Color.Transparent;
                    await Task.Delay(1);
                }
            }
        }

        private int SetInd()
        {
            int get = r.Next(0, set.Length);
            int returner = set[get];
            do
            {
                get = r.Next(0, set.Length);
                returner = set[get];
            } while (returner == 0);
            set[get] = 0;
            return returner;
        }

        private Bitmap SetImg(String name)
        {
            Bitmap ret = null;
            switch(name)
            {
                case "1":
                    ret = panels[0];
                    break;
                case "2":
                    ret = panels[5];
                    break;
                case "3":
                    ret = panels[4];
                    break;
                case "4":
                    ret = panels[2];
                    break;
                case "5":
                    ret = panels[7];
                    break;
                case "6":
                    ret = panels[1];
                    break;
                case "7":
                    ret = panels[3];
                    break;
                case "8":
                    ret = panels[6];
                    break;
            }
            return ret;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            left = 8;
            firstC = 20;
            Firstc = 20;
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            set = new int[16] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
            foreach (PictureBox PB in Panels)
            {
                PB.Image = backpanel;
                PB.Name = SetInd().ToString();
                PB.Visible = true;
                for (int an = 0; an < 10; an++)
                {
                    PB.Size = new Size(PB.Size.Width + 10, PB.Size.Height);
                    PB.Location = new Point(PB.Location.X, PB.Location.Y);
                    PB.BackColor = Color.Transparent;
                    await Task.Delay(1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
