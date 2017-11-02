using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FK_NewPenal
{
    public partial class PolikTipView : UserControl
    {
        public PolikTipView()
        {
            InitializeComponent();
        }

        public bool getPazChek()
        {
            if (radioButton1.Checked)return true;
           return false;
        }
    }
}
