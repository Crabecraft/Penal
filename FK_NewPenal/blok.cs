using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FK_NewPenal
{
    public class blok: UserControl
    {
        #region переменные
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem фальшToolStripMenuItem;
        private ToolStripMenuItem распошнойToolStripMenuItem;
        private ToolStripMenuItem правыйToolStripMenuItem;
        private ToolStripMenuItem левыйToolStripMenuItem;
        private ToolStripMenuItem правыйЛевыйToolStripMenuItem;
        private ToolStripMenuItem шуфлядаToolStripMenuItem;
        private ToolStripMenuItem тБToolStripMenuItem;
        private ToolStripMenuItem мБToolStripMenuItem;
        private ToolStripMenuItem кВToolStripMenuItem;
        private ToolStripMenuItem шарикиToolStripMenuItem;
        private ToolStripMenuItem подьемникиToolStripMenuItem;
        private ToolStripMenuItem газлифтToolStripMenuItem;
        private ToolStripMenuItem клокToolStripMenuItem;
        private ToolStripMenuItem hKXSToolStripMenuItem;
        private ToolStripMenuItem hKSToolStripMenuItem;
        private ToolStripMenuItem hKToolStripMenuItem;
        private ToolStripMenuItem ммToolStripMenuItem;
        private ToolStripMenuItem ммToolStripMenuItem1;
        private ToolStripMenuItem ммToolStripMenuItem2;
        private ToolStripMenuItem ммToolStripMenuItem3;
        private ToolStripMenuItem hFToolStripMenuItem;
        public TextBox textBox1;
        public TextBox textBox2;
        public TextBox textBox3;
        private ToolStripMenuItem тБС1ToolStripMenuItem;
        public Label label1;
        #endregion

        public float высота,уровень;
        private ToolStripMenuItem hettichToolStripMenuItem;
        private Timer timer1;       
    
        public blok(float высота, float уровень)
        {
            InitializeComponent();
            this.высота = высота;
            this.уровень = уровень;
        }

        public void drawPolki()
        {
            Pen pen = new Pen(Brushes.Red, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Graphics gr = this.CreateGraphics();

            for(int i=0; i < this.Parent.Controls.Count;i++)
            {
                if(this.Parent.Controls[i] is Panel)
                    if(((Panel)this.Parent.Controls[i]).AccessibleName == "полки")
                    {
                        Panel tempPolka = (Panel)this.Parent.Controls[i];
                        //if (tempPolka.Top > this.Top && tempPolka.Top < this.Top + this.Height || tempPolka.Top+tempPolka.Height > this.Top && tempPolka.Top+tempPolka.Height < this.Top + this.Height)
                        //{
                           gr.DrawRectangle(pen, new Rectangle(new Point(tempPolka.Left-this.Left-2,tempPolka.Top-this.Top-2), new Size(tempPolka.Width, tempPolka.Height)));
                        //}
                    }
            }
        }

        public void drawPetli()
        {
            Pen pen = new Pen(Brushes.Red, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Graphics gr = this.CreateGraphics();

            if (textBox1.Visible)
                if (textBox1.Text != "0" && textBox1.Text != "")
                {
                    int x = (int)Math.Round((float.Parse(textBox1.Text) - 16) * 0.3f);

                    if (label1.Text.Contains("Правый"))
                        gr.DrawEllipse(pen, new Rectangle(new Point(this.Width - 15, x), new Size(11, 11)));
                    if (label1.Text.Contains("Левый"))
                        gr.DrawEllipse(pen, new Rectangle(new Point(2, x), new Size(11, 11)));
                }
                else { gr.Clear(System.Drawing.Color.Linen); }

            if (textBox2.Visible)
                if (textBox2.Text != "0" && textBox2.Text != "")
                {
                    int x = (int)Math.Round(высота*0.3f-(float.Parse(textBox2.Text) + 32) * 0.3f);

                    if (label1.Text.Contains("Правый"))
                        gr.DrawEllipse(pen, new Rectangle(new Point(this.Width - 15, x), new Size(11, 11)));
                    if (label1.Text.Contains("Левый"))
                        gr.DrawEllipse(pen, new Rectangle(new Point(2, x), new Size(11, 11)));
                }
                else { gr.Clear(System.Drawing.Color.Linen); }

            if (textBox3.Visible)
                if (textBox3.Text != "0" && textBox3.Text != "")
                {
                    int x = (int)Math.Round(высота * 0.3f - (float.Parse(textBox3.Text) + 32) * 0.3f);

                    if (label1.Text.Contains("Правый"))
                        gr.DrawEllipse(pen, new Rectangle(new Point(this.Width - 15, x), new Size(11, 11)));
                    if (label1.Text.Contains("Левый"))
                        gr.DrawEllipse(pen, new Rectangle(new Point(2, x), new Size(11, 11)));
                }
                else { gr.Clear(System.Drawing.Color.Linen); }
        
        
        }
    
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.фальшToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.распошнойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.левыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правыйЛевыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шуфлядаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тБToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мБToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ммToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ммToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ммToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ммToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.кВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шарикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тБС1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подьемникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.газлифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hKXSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hettichToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фальшToolStripMenuItem,
            this.распошнойToolStripMenuItem,
            this.шуфлядаToolStripMenuItem,
            this.подьемникиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 114);
            this.contextMenuStrip1.Text = "Фасад";
            // 
            // фальшToolStripMenuItem
            // 
            this.фальшToolStripMenuItem.Name = "фальшToolStripMenuItem";
            this.фальшToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.фальшToolStripMenuItem.Text = "Без крепления";
            this.фальшToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // распошнойToolStripMenuItem
            // 
            this.распошнойToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правыйToolStripMenuItem,
            this.левыйToolStripMenuItem,
            this.правыйЛевыйToolStripMenuItem});
            this.распошнойToolStripMenuItem.Name = "распошнойToolStripMenuItem";
            this.распошнойToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.распошнойToolStripMenuItem.Text = "Распашной";
            // 
            // правыйToolStripMenuItem
            // 
            this.правыйToolStripMenuItem.AccessibleName = "PETLI";
            this.правыйToolStripMenuItem.Name = "правыйToolStripMenuItem";
            this.правыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.правыйToolStripMenuItem.Text = "Правый";
            this.правыйToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // левыйToolStripMenuItem
            // 
            this.левыйToolStripMenuItem.AccessibleName = "PETLI";
            this.левыйToolStripMenuItem.Name = "левыйToolStripMenuItem";
            this.левыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.левыйToolStripMenuItem.Text = "Левый";
            this.левыйToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // правыйЛевыйToolStripMenuItem
            // 
            this.правыйЛевыйToolStripMenuItem.AccessibleName = "PETLI";
            this.правыйЛевыйToolStripMenuItem.Name = "правыйЛевыйToolStripMenuItem";
            this.правыйЛевыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.правыйЛевыйToolStripMenuItem.Text = "Правый+Левый";
            this.правыйЛевыйToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // шуфлядаToolStripMenuItem
            // 
            this.шуфлядаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тБToolStripMenuItem,
            this.мБToolStripMenuItem,
            this.кВToolStripMenuItem,
            this.шарикиToolStripMenuItem,
            this.тБС1ToolStripMenuItem,
            this.hettichToolStripMenuItem});
            this.шуфлядаToolStripMenuItem.Name = "шуфлядаToolStripMenuItem";
            this.шуфлядаToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.шуфлядаToolStripMenuItem.Text = "Выдвижной";
            // 
            // тБToolStripMenuItem
            // 
            this.тБToolStripMenuItem.Name = "тБToolStripMenuItem";
            this.тБToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.тБToolStripMenuItem.Text = "ТБ";
            this.тБToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // мБToolStripMenuItem
            // 
            this.мБToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ммToolStripMenuItem,
            this.ммToolStripMenuItem1,
            this.ммToolStripMenuItem2,
            this.ммToolStripMenuItem3});
            this.мБToolStripMenuItem.Name = "мБToolStripMenuItem";
            this.мБToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.мБToolStripMenuItem.Text = "МБ";
            // 
            // ммToolStripMenuItem
            // 
            this.ммToolStripMenuItem.Name = "ммToolStripMenuItem";
            this.ммToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ммToolStripMenuItem.Text = "МБ 54";
            this.ммToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem1
            // 
            this.ммToolStripMenuItem1.Name = "ммToolStripMenuItem1";
            this.ммToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.ммToolStripMenuItem1.Text = "МБ 86";
            this.ммToolStripMenuItem1.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem2
            // 
            this.ммToolStripMenuItem2.Name = "ммToolStripMenuItem2";
            this.ммToolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.ммToolStripMenuItem2.Text = "МБ 118";
            this.ммToolStripMenuItem2.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem3
            // 
            this.ммToolStripMenuItem3.Name = "ммToolStripMenuItem3";
            this.ммToolStripMenuItem3.Size = new System.Drawing.Size(113, 22);
            this.ммToolStripMenuItem3.Text = "МБ 150";
            this.ммToolStripMenuItem3.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // кВToolStripMenuItem
            // 
            this.кВToolStripMenuItem.Name = "кВToolStripMenuItem";
            this.кВToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.кВToolStripMenuItem.Text = "КВ";
            this.кВToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // шарикиToolStripMenuItem
            // 
            this.шарикиToolStripMenuItem.Name = "шарикиToolStripMenuItem";
            this.шарикиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.шарикиToolStripMenuItem.Text = "Шарики";
            this.шарикиToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // тБС1ToolStripMenuItem
            // 
            this.тБС1ToolStripMenuItem.Name = "тБС1ToolStripMenuItem";
            this.тБС1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.тБС1ToolStripMenuItem.Text = "ТБ С1";
            this.тБС1ToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // подьемникиToolStripMenuItem
            // 
            this.подьемникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.газлифтToolStripMenuItem,
            this.клокToolStripMenuItem,
            this.hKXSToolStripMenuItem,
            this.hKSToolStripMenuItem,
            this.hKToolStripMenuItem,
            this.hFToolStripMenuItem});
            this.подьемникиToolStripMenuItem.Name = "подьемникиToolStripMenuItem";
            this.подьемникиToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.подьемникиToolStripMenuItem.Text = "Подьемник";
            // 
            // газлифтToolStripMenuItem
            // 
            this.газлифтToolStripMenuItem.Name = "газлифтToolStripMenuItem";
            this.газлифтToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.газлифтToolStripMenuItem.Text = "Газ-лифт";
            this.газлифтToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // клокToolStripMenuItem
            // 
            this.клокToolStripMenuItem.Name = "клокToolStripMenuItem";
            this.клокToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.клокToolStripMenuItem.Text = "Клок";
            this.клокToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // hKXSToolStripMenuItem
            // 
            this.hKXSToolStripMenuItem.Name = "hKXSToolStripMenuItem";
            this.hKXSToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hKXSToolStripMenuItem.Text = "HK-XS";
            this.hKXSToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // hKSToolStripMenuItem
            // 
            this.hKSToolStripMenuItem.Name = "hKSToolStripMenuItem";
            this.hKSToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hKSToolStripMenuItem.Text = "HK-S";
            this.hKSToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // hKToolStripMenuItem
            // 
            this.hKToolStripMenuItem.Name = "hKToolStripMenuItem";
            this.hKToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hKToolStripMenuItem.Text = "HK";
            this.hKToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // hFToolStripMenuItem
            // 
            this.hFToolStripMenuItem.Name = "hFToolStripMenuItem";
            this.hFToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hFToolStripMenuItem.Text = "HF";
            this.hFToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(55, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(55, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(55, 91);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 23);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hettichToolStripMenuItem
            // 
            this.hettichToolStripMenuItem.Name = "hettichToolStripMenuItem";
            this.hettichToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hettichToolStripMenuItem.Text = "Hettich";
            // 
            // blok
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Bisque;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "blok";
            this.Size = new System.Drawing.Size(188, 166);
            this.MouseLeave += new System.EventHandler(this.blok_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.blok_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string[] getPrisadka()
        {




            return null;
        }

        private void правыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = (ToolStripMenuItem)sender;

            if (temp.Text == label1.Text) return;
            label1.Text = temp.Text;
            label1.Left = this.Width / 2 - label1.Width / 2;
            label1.Top = this.Height / 2 - label1.Height / 2;
            if (temp.AccessibleName == "PETLI")
            {
                textBox1.Visible = textBox2.Visible = true;

                if (высота > 1000)
                {
                    textBox3.Visible = true;
                    textBox3.Text = (высота / 2).ToString();
                }
            }
            else
            {
                textBox1.Visible = textBox2.Visible = textBox3.Visible = false;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
                return;
            else
                e.Handled = true;
        }

        private void blok_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = System.Drawing.Color.Bisque;
        }

        private void blok_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Linen;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPolki();
            drawPetli();
        }


        
     




 
    }
}
