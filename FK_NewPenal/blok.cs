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
            this.фальшToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
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
            this.распошнойToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.распошнойToolStripMenuItem.Text = "Распашной";
            // 
            // правыйToolStripMenuItem
            // 
            this.правыйToolStripMenuItem.Name = "правыйToolStripMenuItem";
            this.правыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.правыйToolStripMenuItem.Text = "Правый";
            this.правыйToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // левыйToolStripMenuItem
            // 
            this.левыйToolStripMenuItem.Name = "левыйToolStripMenuItem";
            this.левыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.левыйToolStripMenuItem.Text = "Левый";
            this.левыйToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // правыйЛевыйToolStripMenuItem
            // 
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
            this.мБToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.мБToolStripMenuItem.Text = "МБ";
            // 
            // ммToolStripMenuItem
            // 
            this.ммToolStripMenuItem.Name = "ммToolStripMenuItem";
            this.ммToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.ммToolStripMenuItem.Text = "54 мм.";
            this.ммToolStripMenuItem.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem1
            // 
            this.ммToolStripMenuItem1.Name = "ммToolStripMenuItem1";
            this.ммToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.ммToolStripMenuItem1.Text = "86 мм.";
            this.ммToolStripMenuItem1.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem2
            // 
            this.ммToolStripMenuItem2.Name = "ммToolStripMenuItem2";
            this.ммToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.ммToolStripMenuItem2.Text = "118 мм.";
            this.ммToolStripMenuItem2.Click += new System.EventHandler(this.правыйToolStripMenuItem_Click);
            // 
            // ммToolStripMenuItem3
            // 
            this.ммToolStripMenuItem3.Name = "ммToolStripMenuItem3";
            this.ммToolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.ммToolStripMenuItem3.Text = "150 мм.";
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
            this.подьемникиToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
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
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // blok
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip1;
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
            label1.Text = ((ToolStripMenuItem)sender).Text;
        }

        private void правыйЛевыйToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void тБToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void кВToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void шарикиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


     




 
    }
}
