using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FK_NewPenal
{
    public class blok: UserControl
    {
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
        private ToolStripMenuItem hFToolStripMenuItem;
    
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
            this.кВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шарикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подьемникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.газлифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hKXSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 92);
            this.contextMenuStrip1.Text = "Фасад";
            // 
            // фальшToolStripMenuItem
            // 
            this.фальшToolStripMenuItem.Name = "фальшToolStripMenuItem";
            this.фальшToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.фальшToolStripMenuItem.Text = "Фальш";
            // 
            // распошнойToolStripMenuItem
            // 
            this.распошнойToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правыйToolStripMenuItem,
            this.левыйToolStripMenuItem,
            this.правыйЛевыйToolStripMenuItem});
            this.распошнойToolStripMenuItem.Name = "распошнойToolStripMenuItem";
            this.распошнойToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.распошнойToolStripMenuItem.Text = "Распошной";
            // 
            // правыйToolStripMenuItem
            // 
            this.правыйToolStripMenuItem.Name = "правыйToolStripMenuItem";
            this.правыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.правыйToolStripMenuItem.Text = "Правый";
            // 
            // левыйToolStripMenuItem
            // 
            this.левыйToolStripMenuItem.Name = "левыйToolStripMenuItem";
            this.левыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.левыйToolStripMenuItem.Text = "Левый";
            // 
            // правыйЛевыйToolStripMenuItem
            // 
            this.правыйЛевыйToolStripMenuItem.Name = "правыйЛевыйToolStripMenuItem";
            this.правыйЛевыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.правыйЛевыйToolStripMenuItem.Text = "Правый+Левый";
            // 
            // шуфлядаToolStripMenuItem
            // 
            this.шуфлядаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тБToolStripMenuItem,
            this.мБToolStripMenuItem,
            this.кВToolStripMenuItem,
            this.шарикиToolStripMenuItem});
            this.шуфлядаToolStripMenuItem.Name = "шуфлядаToolStripMenuItem";
            this.шуфлядаToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.шуфлядаToolStripMenuItem.Text = "Выдвижной";
            // 
            // тБToolStripMenuItem
            // 
            this.тБToolStripMenuItem.Name = "тБToolStripMenuItem";
            this.тБToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.тБToolStripMenuItem.Text = "ТБ";
            // 
            // мБToolStripMenuItem
            // 
            this.мБToolStripMenuItem.Name = "мБToolStripMenuItem";
            this.мБToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.мБToolStripMenuItem.Text = "МБ";
            // 
            // кВToolStripMenuItem
            // 
            this.кВToolStripMenuItem.Name = "кВToolStripMenuItem";
            this.кВToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.кВToolStripMenuItem.Text = "КВ";
            // 
            // шарикиToolStripMenuItem
            // 
            this.шарикиToolStripMenuItem.Name = "шарикиToolStripMenuItem";
            this.шарикиToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.шарикиToolStripMenuItem.Text = "Шарики";
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
            this.подьемникиToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.подьемникиToolStripMenuItem.Text = "Подьемник";
            // 
            // газлифтToolStripMenuItem
            // 
            this.газлифтToolStripMenuItem.Name = "газлифтToolStripMenuItem";
            this.газлифтToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.газлифтToolStripMenuItem.Text = "Газ-лифт";
            // 
            // клокToolStripMenuItem
            // 
            this.клокToolStripMenuItem.Name = "клокToolStripMenuItem";
            this.клокToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.клокToolStripMenuItem.Text = "Клок";
            // 
            // hKXSToolStripMenuItem
            // 
            this.hKXSToolStripMenuItem.Name = "hKXSToolStripMenuItem";
            this.hKXSToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hKXSToolStripMenuItem.Text = "HK-XS";
            // 
            // hKSToolStripMenuItem
            // 
            this.hKSToolStripMenuItem.Name = "hKSToolStripMenuItem";
            this.hKSToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hKSToolStripMenuItem.Text = "HK-S";
            // 
            // hKToolStripMenuItem
            // 
            this.hKToolStripMenuItem.Name = "hKToolStripMenuItem";
            this.hKToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hKToolStripMenuItem.Text = "HK";
            // 
            // hFToolStripMenuItem
            // 
            this.hFToolStripMenuItem.Name = "hFToolStripMenuItem";
            this.hFToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hFToolStripMenuItem.Text = "HF";
            // 
            // blok
            // 
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "blok";
            this.Size = new System.Drawing.Size(188, 166);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
