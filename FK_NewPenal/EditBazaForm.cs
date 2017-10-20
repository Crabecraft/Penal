using System;
using System.Windows.Forms;
using SuperSrting;
using System.Collections;

namespace FK_NewPenal
{
    public partial class EditBazaForm : Form
    {
        Form1 form1;
        ArrayList polki;
        ArrayList urovni;


        public EditBazaForm(Form1 form)
        {
            InitializeComponent();
            this.form1 = form;
            load();
        }

        void load(){
        
            polki = new ArrayList();
            urovni = new ArrayList();
            int heightPenal = getint(form1.getHpenal() * 0.3f);
            int nullpos = heightPenal + 20;
            int widthPenal = getint(form1.getWpenal()*0.3f);

            int xnul = getint(panel1.Width / 2 - widthPenal / 2);

            #region Фасады
            if (form1.fasadi != null)
            for (int i = 0; i < form1.fasadi.Count; i++)
            {
                string[] temp = form1.fasadi[i].ToString().Replace("ф", "").Split('-');

                float y = float.Parse(temp[0]);
                float высота = float.Parse(temp[1]);

                int top = getint(y * 0.3f);
                int height = getint(высота * 0.3f);

                panel1.Controls.Add(new blok(высота,y) { Left = xnul, Top = nullpos - top - height, Width = widthPenal, Height = height, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
            }
            #endregion

            panel1.Controls.Add(new Panel() { Left = xnul, Top = nullpos - heightPenal, Width = 6, Height = heightPenal, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
            panel1.Controls.Add(new Panel() { Left = xnul + widthPenal - 6, Top = nullpos - heightPenal, Width = 6, Height = heightPenal, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });


            #region Уровни
            if (form1.arrUrovni != null)
                for (int i = 0; i < form1.arrUrovni.Count; i++)
                {
                    float urr = float.Parse(form1.arrUrovni[i].ToString().Replace(",", "."));
                    urovni.Add(urr);
                    int top = getint(urr * 0.3f);
                    panel1.Controls.Add(new Panel() { Left = xnul + 6, Top = nullpos - top - 3, Width = widthPenal - 12, Height = 6, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
                }
            #endregion

            #region Полки
            try
            {
                string[] newStrokaPolki = SuperStr.SubStrings(form1.textBox6.Text, "(", ")", SubStringsOptions.RemoveEmptyEntries);
                foreach (string i in newStrokaPolki)
                {
                    string[] temp = i.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string v in temp)
                    {
                        try
                        {
                            float urovenR = float.Parse(v);
                            float urovenL = urovenR;
                            polki.Add(urovenR);
                            int top = getint(urovenR * 0.3f);
                            panel1.Controls.Add(new Panel() { Left = xnul + 7, Top = nullpos - top - 6, Width = widthPenal - 14, Height = 6, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });  
                        }
                        catch { }

                    }
                }
            }
            catch { }
            #endregion


        }

        int getint(float value)
        {
            return System.Convert.ToInt32(Math.Round(value));
        }

        int getint(string value)
        {
            return System.Convert.ToInt32(Math.Round(float.Parse(value)));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = !checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                if (!testTochka(textBox1))
                {
                    MessageBox.Show("Некорректное расстояние до паза!"); return;
                }
                if (checkBox2.Checked == false)
                {
                    if (!testTochka(textBox2))
                    {
                        MessageBox.Show("Некорректная длина паза сверху!"); return;
                    }

                    if (!testTochka(textBox3))
                    {
                        MessageBox.Show("Некорректная длина паза снизу!"); return;
                    }

                }
            }


            FindExcel findexcel = new FindExcel();
            findexcel.ShowDialog();
        }

        bool testTochka(TextBox textbox)
        {
            try{
                float temp = float.Parse(textbox.Text.Replace(",","."));
                return true;
            }catch{}
            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
                return;
            else
                e.Handled = true;
        }

        

       
    }
}
