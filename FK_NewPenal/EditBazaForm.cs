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

            if(form1.fasadi != null)
            for (int i = 0; i < form1.fasadi.Count; i++)
            {
                string[] temp = form1.fasadi[i].ToString().Replace("ф", "").Split('-');

                int top = getint(float.Parse(temp[0])*0.3f);
                int height = getint(float.Parse(temp[1])*0.3f);
                panel1.Controls.Add(new blok() { Left = xnul, Top = nullpos - top - height, Width = widthPenal, Height = height, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
            }
            panel1.Controls.Add(new Panel() { Left = xnul, Top = nullpos - heightPenal, Width = 6, Height = heightPenal, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
            panel1.Controls.Add(new Panel() { Left = xnul + widthPenal - 6, Top = nullpos - heightPenal, Width = 6, Height = heightPenal, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
          
            if (form1.arrUrovni != null)
                for (int i = 0; i < form1.arrUrovni.Count; i++)
                {
                    float urr = float.Parse(form1.arrUrovni[i].ToString().Replace(",", "."));
                    urovni.Add(urr);
                    int top = getint(urr * 0.3f);
                    panel1.Controls.Add(new blok() { Left = xnul + 6, Top = nullpos - top - 3, Width = widthPenal - 12, Height = 6, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });
                }


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
                            panel1.Controls.Add(new blok() { Left = xnul + 7, Top = nullpos - top - 6, Width = widthPenal - 14, Height = 6, BackColor = System.Drawing.SystemColors.GradientInactiveCaption, BorderStyle = BorderStyle.FixedSingle });  
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

       
    }
}
