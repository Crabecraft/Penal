using System;
using System.Windows.Forms;
using SuperSrting;
using System.Drawing;
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

                panel1.Controls.Add(new blok(высота,y) { Left = xnul+1, Top = nullpos - top - height, Width = widthPenal-2, Height = height, BackColor = System.Drawing.Color.Linen, BorderStyle = BorderStyle.FixedSingle });
            }
            #endregion

            panel1.Controls.Add(new Panel() { Left = xnul, Top = nullpos - heightPenal, Width = 6, Height = heightPenal, BackColor = System.Drawing.Color.Linen, BorderStyle = BorderStyle.FixedSingle });
            panel1.Controls.Add(new Panel() { Left = xnul + widthPenal - 6, Top = nullpos - heightPenal, Width = 6, Height = heightPenal, BackColor = System.Drawing.Color.Linen, BorderStyle = BorderStyle.FixedSingle });


            #region Уровни
            if (form1.arrUrovni != null)
                for (int i = 0; i < form1.arrUrovni.Count; i++)
                {
                    float urr = float.Parse(form1.arrUrovni[i].ToString().Replace(",", "."));
                    urovni.Add(urr);
                    int top = getint(urr * 0.3f);
                    panel1.Controls.Add(new Panel() { Left = xnul + 6, Top = nullpos - top - 3, Width = widthPenal - 12, Height = 6, BackColor = System.Drawing.Color.Linen, BorderStyle = BorderStyle.FixedSingle });
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
                            panel1.Controls.Add(new Panel() { Left = xnul + 7, Top = nullpos - top - 6, Width = widthPenal - 14, Height = 6, BackColor = System.Drawing.Color.Linen, BorderStyle = BorderStyle.FixedSingle, AccessibleName = "полки" });  
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

            if (!проверка_фасадов()) return;

            string[] left = getLeftPanel();
            string[] right = getRightPanel();
            string[] tempFasadi = getFasadi();

            left[0] += tempFasadi[0];
            right[0] += tempFasadi[1];
            

            FindExcel findexcel = new FindExcel(left, right);
            findexcel.ShowDialog();
        }

        string[] getLeftPanel()
        {
            string progstr = "Контур;";

            if (polki.Count > 0)
            {
                progstr += "Полка$FX=";

                for (int i = 0; i < polki.Count; i++)
                {
                    string ur = polki[i].ToString();
                    progstr += "lpx-" + ur;
                    if (i != polki.Count - 1) progstr += "_";
                    else progstr += ";";
                }
            }

            if (urovni.Count > 0)
            {

                if (radioButton3.Checked)
                {
                    if (form1.getGlubina() < 450)
                       progstr += "щит2$FX=";
                    else
                       progstr += "щит3$FX=";
                }
                else if (radioButton4.Checked)
                {
                    if (form1.getGlubina() < 450)
                        progstr += "щит2паз$FX=";
                    else
                        progstr += "щит3паз$FX=";
                }
                

                for (int i = 0; i < urovni.Count; i++)
                {
                    string ur = urovni[i].ToString();
                    progstr += "lpx-" + ur;
                    if (i != urovni.Count - 1) progstr += "_";
                    else progstr += ";";
                }
            }





                if (checkBox1.Checked && float.Parse(textBox1.Text) > 0)
                {
                    if(checkBox2.Checked)
                    progstr += "Паз;";
                    else
                    if (!checkBox2.Checked)
                    {
                        float паз1 = float.Parse(textBox2.Text);
                        float паз2 = float.Parse(textBox3.Text);

                        if (паз1 > 0)
                        {
                            progstr += "Паз1$FX=" + textBox2.Text.Replace(",",".") +";";
                        }
                        if (паз2 > 0)
                        {
                            progstr += "Паз2$FX=" + textBox3.Text.Replace(",", ".") + ";";
                        }
                    }
                }

            string paz = textBox1.Text;
            if (!checkBox1.Checked) paz = "0";
            string paramstr = "$storona=2;$paz=" + paz + ";$Xpaz1=0;$Xpaz2=" + form1.getHpenal().ToString() + ";";

            return new string[] { progstr, paramstr };
        }

        string[] getRightPanel()
        {
            string progstr = "Контур;";

            if (polki.Count > 0)
            {   
                progstr += "Полка$FX=";

                for (int i = 0; i < polki.Count; i++)
                {
                    string ur = polki[i].ToString();
                    progstr += "lpx-" + ur;
                    if (i != polki.Count - 1) progstr += "_";
                    else progstr += ";";
                }
            }

            if (urovni.Count > 0)
            {

                if (radioButton3.Checked)
                {
                    if (form1.getGlubina() < 450)
                        progstr += "щит2$FX=";
                    else
                        progstr += "щит3$FX=";
                }
                else if (radioButton4.Checked)
                {
                    if (form1.getGlubina() < 450)
                        progstr += "щит2паз$FX=";
                    else
                        progstr += "щит3паз$FX=";
                }


                for (int i = 0; i < urovni.Count; i++)
                {
                    string ur = urovni[i].ToString();
                    progstr += "lpx-" + ur;
                    if (i != urovni.Count - 1) progstr += "_";
                    else progstr += ";";
                }
            }

            if (checkBox1.Checked && float.Parse(textBox1.Text) > 0)
            {
                if (checkBox2.Checked)
                    progstr += "Паз;";
                else
                    if (!checkBox2.Checked)
                    {
                        float паз1 = float.Parse(textBox3.Text);
                        float паз2 = float.Parse(textBox2.Text);

                        if (паз1 > 0)
                        {
                            progstr += "Паз1$FX=" + textBox3.Text.Replace(",", ".") + ";";
                        }
                        if (паз2 > 0)
                        {
                            progstr += "Паз2$FX=" + textBox2.Text.Replace(",", ".") + ";";
                        }
                    }
            }

            string paz = textBox1.Text;
            if (!checkBox1.Checked) paz = "0";
            string paramstr = "$storona=3;$paz=" + paz + ";$Xpaz1=0;$Xpaz2=" + form1.getHpenal().ToString() + ";";

            return new string[] { progstr, paramstr };
        }

        string[] getFasadi()
        {
            string[] returmMass = new string[2];
            returmMass[0] = "";
            returmMass[1] = "";

            for (int i = 0; i < this.panel1.Controls.Count; i++)
                if (this.panel1.Controls[i] is blok)
                {
                    blok tekFasad = (blok)this.panel1.Controls[i];
                    string name = tekFasad.label1.Text;
                    if (name == "Без крепления") continue;

                    


                    string ret = "";
                    if (name.Contains("Левый") || name.Contains("Правый"))
                    {
                           float петляЦентр = 0;
                           float петляВерх = float.Parse(tekFasad.textBox1.Text);
                           try
                           {
                               петляЦентр = float.Parse(tekFasad.textBox3.Text);
                           }
                           catch { }
                           float петляНиз = float.Parse(tekFasad.textBox2.Text);


                            if (петляВерх > 0)
                                ret += "Петля_ТИП_ПЕТЛИ$FX=" + (tekFasad.уровень + (tekFasad.высота - петляВерх)) + ";";

                            if(петляНиз > 0)
                                ret += "Петля_ТИП_ПЕТЛИ$FX=" + (tekFasad.уровень + петляНиз) + ";";

                            if(tekFasad.высота > 1000 && петляЦентр > 0)
                                ret += "Петля_ТИП_ПЕТЛИ$FX=" + (tekFasad.уровень + петляЦентр) + ";";
                    }

                    switch (name)
                    {
                        case "Левый":
                            returmMass[0] += ret;      
                        break;

                        case "Правый":
                            returmMass[1] += ret;
                        break;

                        case "Правый+Левый":
                            returmMass[0] += ret;
                            returmMass[1] += ret;
                        break;

                        case "ТБ":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        break;

                        case "Hettich":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        break;

                        case "ТБ С1":
                        if (tekFasad.высота - 40 < 115)
                        {
                            returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 35.5f).ToString() + ";";
                            returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 35.5f).ToString() + ";";
                        }
                        else
                        {
                            returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                            returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        }
                        break;

                        case "КВ":
                          returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                          returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        break;

                        case "Шарики":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 53).ToString() + ";";
                        break;

                        case "МБ 54":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 70).ToString() + "_" + (tekFasad.уровень + 38).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 70).ToString() + "_" + (tekFasad.уровень + 38).ToString() + ";";
                        break;

                        case "МБ 86":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 102).ToString() + "_" + (tekFasad.уровень + 38).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 102).ToString() + "_" + (tekFasad.уровень + 38).ToString() + ";";
                        break;

                        case "МБ 118":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 134).ToString() + "_" + (tekFasad.уровень + 38).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 134).ToString() + "_" + (tekFasad.уровень + 38).ToString() + ";";
                        break;

                        case "МБ 150":
                        returmMass[0] += "nakolki$FX=" + (tekFasad.уровень + 176).ToString() + "_" + (tekFasad.уровень + 48).ToString() + ";";
                        returmMass[1] += "nakolki$FX=" + (tekFasad.уровень + 176).ToString() + "_" + (tekFasad.уровень + 48).ToString() + ";";
                        break;

                        case "Газ-лифт":
                        returmMass[0] += "газлифты$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() +";";
                        returmMass[1] += "газлифты$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        break;

                        case "Клок":
                        returmMass[0] += "клок$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        returmMass[1] += "клок$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        break;

                        case "HK-XS":
                        returmMass[0] += "hk-xs$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        returmMass[1] += "hk-xs$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        break;

                        case "HK-S":
                        returmMass[0] += "hk-s$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        returmMass[1] += "hk-s$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        break;

                        case "HK":
                        returmMass[0] += "hk$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        returmMass[1] += "hk$FX=lpx-" + (tekFasad.уровень + tekFasad.высота + 2).ToString() + ";";
                        break;
                            //(lpx * 0.3) - 57
                        case "HF":
                            float hf = tekFasad.высота - ((tekFasad.высота+4)*2 * 0.3f-59);
                            returmMass[0] += "HFFX$FX=lpx-" + (tekFasad.уровень + hf).ToString() + ";";
                            returmMass[1] += "HFFX$FX=lpx-" + (tekFasad.уровень + hf).ToString() + ";";
                        break;
                    }

                    if (radioButton1.Checked)
                    {
                        returmMass[0] = returmMass[0].Replace("ТИП_ПЕТЛИ", "ЕВРОВИНТ");
                        returmMass[1] = returmMass[1].Replace("ТИП_ПЕТЛИ", "ЕВРОВИНТ");
                    }else
                    if (radioButton2.Checked)
                    {
                        returmMass[0] = returmMass[0].Replace("ТИП_ПЕТЛИ", "САМОРЕЗ");
                        returmMass[1] = returmMass[1].Replace("ТИП_ПЕТЛИ", "САМОРЕЗ");
                    }
                }
                return returmMass;
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

        bool проверка_фасадов()
        {
            for (int i = 0; i < this.panel1.Controls.Count; i++)
                if (this.panel1.Controls[i] is blok)
                {
                    blok tempBlok = (blok)this.panel1.Controls[i];
                    if (tempBlok.label1.Text == "")
                    {
                        MessageBox.Show("Фасад: " + tempBlok.высота + "х" + (form1.getWpenal() - 4).ToString() + "- не настроен!");
                        return false;
                    }


                    if (tempBlok.label1.Text == "Правый" || tempBlok.label1.Text == "Левый" || tempBlok.label1.Text == "Правый+Левый")
                    {
                        if (tempBlok.textBox1.Text == "" || tempBlok.textBox2.Text == "")
                        {
                            MessageBox.Show("Фасад: " + tempBlok.высота + "х" + (form1.getWpenal() - 4).ToString() + "- укажите расстояние до петли!");
                            return false;
                        }

                        if (tempBlok.высота > 1000 && tempBlok.textBox3.Text == "")
                        {
                            MessageBox.Show("Фасад: " + tempBlok.высота + "х" + (form1.getWpenal() - 4).ToString() + "- укажите расстояние до средней петли!");
                            return false;
                        }
                    }
                }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            //gr.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Pen pen = new Pen(Brushes.Red, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                if (this.panel1.Controls[i] is blok)
                {
                    blok TEMPfAS = (blok)this.panel1.Controls[i];   
                    for (int j = 0; j < this.panel1.Controls.Count; j++)
                    {
                        if(this.panel1.Controls[j] is Panel)
                            if(((Panel)this.panel1.Controls[j]).AccessibleName == "полки")
                            {
                                Panel tempPanel = (Panel)this.panel1.Controls[j];
                                if(tempPanel.Top > TEMPfAS.Top)
                                    if (tempPanel.Top < TEMPfAS.Top + TEMPfAS.Height)
                                    {
                                        Graphics gr = TEMPfAS.CreateGraphics();
                                        gr.DrawRectangle(pen, new Rectangle(new Point(this.Left-this.Width/2 + tempPanel.Left,this.Top+ tempPanel.Top), new Size(tempPanel.Width, tempPanel.Height)));


                                    }
                            }
                    }
                }
            }
        }



       
    }
}
