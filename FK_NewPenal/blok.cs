using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        #endregion

        float высота, уровень;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
    
        public blok(float высота, float уровень)
        {
            InitializeComponent();
            this.высота = высота;
            this.уровень = уровень;
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 92);
            this.contextMenuStrip1.Text = "Фасад";
            // 
            // фальшToolStripMenuItem
            // 
            this.фальшToolStripMenuItem.Name = "фальшToolStripMenuItem";
            this.фальшToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.фальшToolStripMenuItem.Text = "Фальш";
            this.фальшToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // распошнойToolStripMenuItem
            // 
            this.распошнойToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правыйToolStripMenuItem,
            this.левыйToolStripMenuItem,
            this.правыйЛевыйToolStripMenuItem});
            this.распошнойToolStripMenuItem.Name = "распошнойToolStripMenuItem";
            this.распошнойToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
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
            this.шарикиToolStripMenuItem});
            this.шуфлядаToolStripMenuItem.Name = "шуфлядаToolStripMenuItem";
            this.шуфлядаToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
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
            this.ммToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ммToolStripMenuItem.Text = "МБ 54";
            this.ммToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem1
            // 
            this.ммToolStripMenuItem1.Name = "ммToolStripMenuItem1";
            this.ммToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.ммToolStripMenuItem1.Text = "МБ 86";
            this.ммToolStripMenuItem1.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem2
            // 
            this.ммToolStripMenuItem2.Name = "ммToolStripMenuItem2";
            this.ммToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.ммToolStripMenuItem2.Text = "МБ 118";
            this.ммToolStripMenuItem2.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem3
            // 
            this.ммToolStripMenuItem3.Name = "ммToolStripMenuItem3";
            this.ммToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
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
            this.подьемникиToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
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
            // blok
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "blok";
            this.Size = new System.Drawing.Size(188, 166);
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
            }
            else
            {
                textBox1.Visible = textBox2.Visible = false;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
                return;
            else
                e.Handled = true;
        }

        
     




 
    }
}
