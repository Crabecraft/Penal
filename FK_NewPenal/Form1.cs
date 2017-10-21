using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using SuperSrting;
using System.Threading;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
namespace FK_NewPenal
{
    public partial class Form1 : Form
    {

 [ DllImport( "kernel32.dll" ) ]
  public static extern bool SetProcessWorkingSetSize( IntPtr handle,
int minimumWorkingSetSize, int maximumWorkingSetSize );

        public ArrayList arrUrovni;
        public ArrayList fasadi;
        public ArrayList nishi;
        public ArrayList polki;
        xilog Xilog;
        Bitmap img;
        Thread thread;

        string stroka1, stroka2, stroka3, stroka4;

        /// <summary>
        public ArrayList Лприсадка;
        public ArrayList Пприсадка;
        /// </summary>
        
        public Form1()
        {
            InitializeComponent();
            Xilog = new xilog();

            //string[] temp;
            //string fileName = "2-ф356-з3-ф356-2-н600-2-ф-2#н682(0); н600(0); н1044(2); #н1044(1673;1500)#2400#555#True#False#152";
            //temp = fileName.Split('#');
            //stroka1 = temp[0];
            //stroka3 = temp[1];
            //stroka4 = temp[2];
            //textBox1.Text = temp[3];
            //textBox2.Text = temp[4];
            //checkBox1.Checked = bool.Parse(temp[5]);
            //checkBox2.Checked = bool.Parse(temp[6]);
            //textBox4.Text = temp[7];
        }

        public Form1(string fileName)
        {
            InitializeComponent();
            Xilog = new xilog();

            string[] temp = fileName.Split('.');
            if (temp[temp.Length - 1] == "FKP")
            {
                temp = File.ReadAllText(fileName).Split('#');
                stroka1 = temp[0].Replace(",",".");
                stroka2 = temp[1].Replace(",", ".");
                stroka3 = temp[2].Replace(",", ".");
                stroka4 = temp[3].Replace(",", ".");
                textBox1.Text = temp[4];
                textBox2.Text = temp[5];
                checkBox1.Checked = bool.Parse(temp[6]);
                checkBox2.Checked = bool.Parse(temp[7]);
                textBox4.Text = temp[8];
            }
            else { Application.Exit(); }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {           
           if(img != null) saveFromFile();
           

        }  

        void saveFromFile()
        {
            saveFileDialog1.DefaultExt = "bmp";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = textBox4.Text;
            saveFileDialog1.Filter = "Графический файл (*.bmp)|*.bmp|Все файлы (*.*)|*.*";
            
            if (saveFileDialog1.FileName.Trim() == "")
            {
                saveFileDialog1.FileName = "NewPenal " + DateTime.Now.ToString().Replace(".", "_").Replace(":", "-").Replace(" ", "(") + ")";
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
        }

        void Draw()
        {
            img = null;
            checkBox3.Checked = false;
            if (thread != null) thread.Abort();
            thread = new Thread(new ParameterizedThreadStart(DrawPotok));
            thread.Start(this);

        }

        void DrawPotok(Object formObj)
        {
            SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);

            Form1 form = (Form1)formObj;
            Bitmap img = new Bitmap(1260, 1782);
            Graphics g = Graphics.FromImage(img);
            form.Лприсадка = new ArrayList();
            form.Пприсадка = new ArrayList();
            g.Clear(Color.White);

            try
            {
                float getWpenal = form.getWpenal();
                float getHpenal = form.getHpenal();

                string strPenal = form.textBox3.Text;
                string strPolki = form.textBox5.Text;
                string strHpenal = form.textBox1.Text;

                bool chekRight = form.checkBox1.Checked;
                bool chekLeft = form.checkBox2.Checked;

                if (strPenal == "" || strPolki == "") return;
                if (form.arrUrovni == null && form.fasadi == null && form.nishi == null) return;
                int drawTip = 0;
                string[] separator = new string[1] { "-" };
                if (chekRight && !chekLeft) drawTip = 1;
                if (!chekRight && chekLeft) drawTip = 2;
                if (chekRight && chekLeft) drawTip = 3;



                if (getHpenal > 0 && strHpenal != "")
                    if (getHpenal != float.Parse(strHpenal))
                    {
                        g.Clear(Color.White);
                        g.DrawString("Построение невозможно, не хватает высоты!", new Font("Arial", 25, FontStyle.Bold), Brushes.Red, 280, 10);
                        form.pictureBox1.Image = new Bitmap(img, 489, 692);
                        g.Clear(Color.White);
                        return;
                    }
                    else form.label5.Text = "";
                if (strHpenal == "") 
                    form.label5.Text = "";


                
                Font font1 = new System.Drawing.Font("Arial", 20, FontStyle.Regular);

                string info = "";
                string[] tempInfo = strPenal.Split(separator, StringSplitOptions.None);
                float hPenalStr = 0;
                string[] values = strPenal.Replace('.', ',').Replace("з", "").Replace("н", "").Replace("ф", "").Split(separator, StringSplitOptions.None);

                foreach (string v in values)
                    try
                    {
                        hPenalStr += float.Parse(v);
                    }
                    catch { }



                if (!chekRight)
                    form.Пприсадка.Add(new деталь("9", "дно"));
                if (!chekLeft)
                    form.Лприсадка.Add(new деталь("9", "дно"));




                for (int i = 0; i < tempInfo.Length; i++)
                {
                    
                        if (tempInfo[i].Replace("ф", "").Replace("н", "").Replace("з", "").Trim() == "")
                        {
                            try
                            {
                                float zazor = getHpenal - hPenalStr;
                                if (zazor < 0)
                                {
                                    g.Clear(Color.White);
                                    g.DrawString("Построение невозможно, не хватает высоты!", new Font("Arial", 25, FontStyle.Bold), Brushes.Red, 280, 10);
                                    form.pictureBox1.Image = new Bitmap(img, 489, 692);
                                    g.Clear(Color.White);
                                    return;
                                }
                                tempInfo[i] += zazor.ToString();
                            }
                            catch { }
                        }
                    
                    info += tempInfo[i];
                    if (i != tempInfo.Length - 1) info += "-";

                }

                info = info.Replace("з", "").ToUpper();


                info += " (" + getHpenal.ToString() + ")";
                if (form.textBox4.Text != "") info += "      " + form.textBox4.Text;

                g.DrawString(info, font1, Brushes.Black, 10,10);

                double pixel = img.Height * 0.9 / getHpenal;

                for (; ; )
                    if (img.Width * 0.6 < getWpenal * pixel) pixel = pixel * 0.9;
                    else break;

                int nuulPointY = img.Height - (img.Height - (int)Math.Round(getHpenal * pixel)) / 2;
                int nuulPointX = (img.Width - ((int)Math.Round(getWpenal * pixel))) / 2;

                int minusH1 = 19;
                int minusH2 = 19;

                if (chekLeft) minusH1 = 2;
                if (chekRight) minusH2 = 2;


                g.DrawRectangle(new Pen(Brushes.Black, 3),
                    nuulPointX,
                    nuulPointY - (int)Math.Round((getHpenal - 0.5f) * pixel),
                    (int)Math.Round(pixel * 18),
                    (int)Math.Round((getHpenal - minusH1) * pixel));

                g.DrawRectangle(new Pen(Brushes.Black,3),
                    nuulPointX + (int)Math.Round((getWpenal - 18) * pixel),
                    nuulPointY - (int)Math.Round((getHpenal - 0.5f) * pixel),
                    (int)Math.Round(pixel * 18),
                    (int)Math.Round((getHpenal - minusH2) * pixel));


                


                #region Щиты
                if (form.arrUrovni != null)
                    for (int i = 0; i < form.arrUrovni.Count; i++)
                    {

                        int tols = 18;
                        float wPolik = getWpenal - 36;

                        if (i == 0)
                            switch (drawTip)
                            {
                                case 0: tols = 0; wPolik += 36; break;
                                case 1: tols = 0; wPolik += 18; break;
                                case 2: tols = 18; wPolik += 18; break;
                            }

                        g.DrawRectangle(new Pen(Brushes.Black, 3),
                         nuulPointX + (int)Math.Round(tols * pixel),
                         nuulPointY - (int)Math.Round((float.Parse(form.arrUrovni[i].ToString()) + 9) * pixel),
                         (int)Math.Round((wPolik) * pixel),
                         (int)Math.Round(18 * pixel));

                        Point point1 = new Point(nuulPointX + (int)Math.Round((getWpenal - 18) * pixel),
                            nuulPointY - (int)Math.Round(float.Parse(form.arrUrovni[i].ToString()) * pixel));
                        Point point2 = new Point((int)Math.Round(img.Width * 0.85),
                            nuulPointY - (int)Math.Round(float.Parse(form.arrUrovni[i].ToString()) * pixel));

                        Point point3 = new Point((int)Math.Round(img.Width * 0.15),
                            nuulPointY - (int)Math.Round(float.Parse(form.arrUrovni[i].ToString()) * pixel));
                        Point point4 = new Point(nuulPointX + (int)Math.Round(18 * pixel),
                            nuulPointY - (int)Math.Round(float.Parse(form.arrUrovni[i].ToString()) * pixel));

 
                        float urovenR = float.Parse(form.arrUrovni[i].ToString());
                        if (!chekRight)
                        {
                            g.DrawLine(Pens.Black, new Point(point1.X, nuulPointY - (int)Math.Round(18 * pixel)), new Point(point2.X, nuulPointY - (int)Math.Round(18 * pixel)));
                            urovenR -= 18;
                            
                        }
                        else g.DrawLine(Pens.Black, new Point(point1.X, nuulPointY), new Point(point2.X, nuulPointY));
                        if (i != 0 || chekRight)
                        {
                            g.DrawString(urovenR.ToString(), font1, Brushes.Black, new Point((int)Math.Round(img.Width * 0.85), (int)point1.Y));
                            g.DrawLine(Pens.Black, point1, point2);
                        }

                        if (urovenR > 0)
                            form.Пприсадка.Add(new деталь(urovenR.ToString(),"щит"));                       
                        

                        float urovenL = float.Parse(form.arrUrovni[i].ToString());
                        if (!chekLeft)
                        { 
                            urovenL -= 18;
                        }

                        if (chekRight != chekLeft)
                        {
                            
                            if (!chekLeft)
                            {
                                g.DrawLine(Pens.Black, new Point(point3.X, nuulPointY - (int)Math.Round(18 * pixel)), new Point(point4.X, nuulPointY - (int)Math.Round(18 * pixel)));
                            }
                            else g.DrawLine(Pens.Black, new Point(point3.X, nuulPointY), new Point(point4.X, nuulPointY));
                            if (i != 0 || chekLeft)
                            {
                                g.DrawString(urovenL.ToString(), font1, Brushes.Black, new Point((int)Math.Round(img.Width * 0.07), (int)point1.Y));
                                g.DrawLine(Pens.Black, point3, point4);
                            }             
                        }

                        if (urovenL > 0)
                            form.Лприсадка.Add(new деталь(urovenL.ToString(), "щит"));            


                    }
                #endregion

                #region Полки
                try
                {
                    string[] newStrokaPolki = SuperStr.SubStrings(form.textBox6.Text, "(", ")", SubStringsOptions.RemoveEmptyEntries);
                    foreach (string i in newStrokaPolki)
                    {
                        string[] temp = i.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string v in temp)
                        {
                            try
                            {
                                float urovenR = float.Parse(v);
                                float urovenL = urovenR;

                                g.DrawRectangle(new Pen(Brushes.Black, 3),
                                         nuulPointX + (int)Math.Round(18 * pixel),
                                         nuulPointY - (int)Math.Round((urovenR + 18) * pixel),
                                         (int)Math.Round((getWpenal - 36) * pixel),
                                         (int)Math.Round(18 * pixel));

                                Point point1 = new Point(nuulPointX + (int)Math.Round((getWpenal - 18) * pixel),
                                            nuulPointY - (int)Math.Round(urovenR * pixel));
                                Point point2 = new Point((int)Math.Round(img.Width * 0.85),
                                    nuulPointY - (int)Math.Round(urovenR * pixel));

                                Point point3 = new Point((int)Math.Round(img.Width * 0.15),
                                    nuulPointY - (int)Math.Round(urovenL * pixel));
                                Point point4 = new Point(nuulPointX + (int)Math.Round(18 * pixel),
                                    nuulPointY - (int)Math.Round(urovenL * pixel));


                                if (!chekRight) urovenR -= 18;

                                g.DrawString(urovenR.ToString() + "(полка)", font1, Brushes.Black, new Point((int)Math.Round(img.Width * 0.83), (int)point1.Y));
                                g.DrawLine(Pens.Black, point1, point2);

                                if (!chekLeft) urovenL -= 18;
                                if (chekRight != chekLeft)
                                {
                                    
                                    g.DrawString(urovenL.ToString() + "(полка)", font1, Brushes.Black, new Point((int)Math.Round(img.Width * 0.05), (int)point1.Y));
                                    g.DrawLine(Pens.Black, point3, point4);

                                }

                                form.Лприсадка.Add(new деталь(urovenL.ToString(), "полка"));
                                form.Пприсадка.Add(new деталь(urovenR.ToString(), "полка"));  

                            }
                            catch { }

                        }
                    }
                }
                catch { }
                #endregion
                                
                #region Фасады
                if (form.fasadi != null)
                    for (int i = 0; i < form.fasadi.Count; i++)
                    {
                        try
                        {
                            string tekValue = form.fasadi[i].ToString().Replace("ф", "");
                            float H = float.Parse(tekValue.Split(separator, StringSplitOptions.None)[1]);
                            float pointH = float.Parse(tekValue.Split(separator, StringSplitOptions.None)[0]);

                            g.DrawRectangle(new Pen(Brushes.Black,1),
                                     nuulPointX + (int)Math.Round(4 * pixel),
                                     nuulPointY - (int)Math.Round((pointH + H-2) * pixel),
                                     (int)Math.Round((getWpenal - 8) * pixel),
                                     (int)Math.Round((H-4) * pixel));

                            g.DrawString("ф" + H.ToString(), new Font("Arial", 35, FontStyle.Italic), Brushes.Black, new Point((img.Width / 2 - 50), (int)(img.Height / 2 + (getHpenal / 2 - pointH - H / 2) * pixel)));
                        }
                        catch { }
                    }
                #endregion

                #region Ниши
                if (form.nishi != null)
                    for (int i = 0; i < form.nishi.Count; i++)
                    {
                        try
                        {
                            string tekValue = form.nishi[i].ToString().Replace("н", "");
                            float H = float.Parse(tekValue.Split(separator, StringSplitOptions.None)[1]);
                            float pointH = float.Parse(tekValue.Split(separator, StringSplitOptions.None)[0]);
                            g.DrawString("ниша" + H.ToString(), new Font("Arial", 35, FontStyle.Italic), Brushes.Black, new Point((img.Width / 2 - 80), (int)(img.Height / 2 + (getHpenal / 2 - pointH) * pixel)));
                        }
                        catch { }
                    }
                #endregion

                
            }
            catch { }

            try
            {
                form.pictureBox1.Image = new Bitmap(img, 489, 692);
                form.img = new Bitmap(img);
            }
            catch { }


            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dekoder();
        }

        string getNameSverlenie(ArrayList _сверление)
        {

            return "есть";
        }

        public void loadListDetali()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                деталь[] присадка_левая = new деталь[Лприсадка.Count];
                деталь[] присадка_правая = new деталь[Пприсадка.Count]; ;

                for (int i = 0; i < присадка_левая.Length; i++)
                {
                    присадка_левая[i] = (деталь)Лприсадка[i];
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = присадка_левая[i].x;
                    dataGridView1.Rows[i].Cells[1].Value = присадка_левая[i].name;
                    if (присадка_левая[i].сверление.name != "")
                    dataGridView1.Rows[i].Cells[2].Value = присадка_левая[i].сверление.name;
                }
                for (int i = 0; i < присадка_правая.Length; i++)
                {
                    присадка_правая[i] = (деталь)Пприсадка[i];
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = присадка_правая[i].x;
                    dataGridView2.Rows[i].Cells[1].Value = присадка_правая[i].name;
                    if (присадка_правая[i].сверление.name != "")
                        dataGridView2.Rows[i].Cells[2].Value = присадка_правая[i].сверление.name;
                }

            }
            catch { }
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        void dekoder()
        {

            string value = textBox3.Text.ToLower().Replace('.',','); ;
                if (value == "") return;
                string[] separator = new string[1] { "-" };
                string[] values = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);



                arrUrovni = new ArrayList();                
                fasadi = new ArrayList();
                nishi = new ArrayList();

                for (int i = 0; i < values.Length; i++)
                {
                    try
                    {
                        if (values[i].Contains("н"))
                        {
                            try
                            {

                                if (i + 1 == values.Length - 1 && float.Parse(values[i + 1]) < 18)
                                {
                                    textBox8.Text = " ";
                                    label5.Text = "Щит не может быть " + values[i + 1];
                                    pictureBox1.Image = null;
                                    return;
                                }

                                if (values[i + 2].Contains("н") && float.Parse(values[i + 1]) < 18)
                                {
                                    textBox8.Text = " ";
                                    label5.Text = "Щит не может быть " + values[i + 1];
                                    pictureBox1.Image = null;
                                    return;
                                }
                            }
                            catch { }

                            try
                            {

                                if (i - 1 == 0 && float.Parse(values[0]) < 18)
                                {
                                    textBox8.Text = " ";
                                    label5.Text = "Щит не может быть " + values[0];
                                    pictureBox1.Image = null;
                                    return;
                                }

                                if (values[i - 2].Contains("н") && float.Parse(values[i - 1]) < 18)
                                {
                                    textBox8.Text = " ";
                                    label5.Text = "Щит не может быть " + values[i - 1];
                                    pictureBox1.Image = null;
                                    return;
                                }
                            }
                            catch { }

                            string hValue = values[i].Replace("н", "");
                            if (hValue == "")
                                hValue = (getUrov(values, i + 1) - getUrov(values, i)).ToString();
                            nishi.Add("н" + (getUrov(values, i) + float.Parse(hValue)/2) + "-" + float.Parse(hValue));

                        }
                        else
                            if (values[i].Contains("ф"))
                            {
                                string fValue = values[i].Replace("ф", "");
                                if (fValue == "")
                                    fValue = (getUrov(values, i + 1) - getUrov(values, i)).ToString();
                                fasadi.Add("ф" + getUrov(values, i) + "-" + float.Parse(fValue));
                            }
                            else
                                if (values[i].Contains("з"))
                                {

                                }
                                else
                            {
                                if (i == 0)
                                    arrUrovni.Add("9.5");
                                else if (i == values.Length - 1)
                                    arrUrovni.Add((getUrov(values, i) + float.Parse(values[i]) - 9.5f).ToString());
                                else if (values[i - 1].Contains("ф") && values[i + 1].Contains("ф"))
                                    arrUrovni.Add((getUrov(values, i) + float.Parse(values[i]) / 2).ToString());
                                else if (values[i - 1].Contains("н") && values[i + 1].Contains("ф"))
                                    arrUrovni.Add((getUrov(values, i) + 9).ToString());
                                else if (values[i - 1].Contains("ф") && values[i + 1].Contains("н"))
                                    arrUrovni.Add((getUrov(values, i) + float.Parse(values[i]) - 9).ToString());
                                else if (values[i - 1].Contains("н") && values[i + 1].Contains("н"))
                                    arrUrovni.Add((getUrov(values, i) + 9).ToString());
                            }
                    }
                    catch { }
                }

                string строкаУровней="";

                for (int i = 0; i < arrUrovni.Count; i++)
                    строкаУровней += arrUrovni[i].ToString() + ";";

                if (stroka2 != null)
                {
                    строкаУровней = stroka2;
                    stroka2 = null;
                }
                textBox8.Text = строкаУровней.Replace(",",".");
              
        }

        float getUrov(string[] values, int item)
        {
            //string[] separator = new string[1]{"-"};
            //string[] values = value.Replace("н", "").Replace("ф", "").Split(separator,StringSplitOptions.None);
            
            float returnValue = 0;


            for (int i = 0; i < item; i++)
            {
                if (values[i].Replace("н", "").Replace("ф", "").Replace("з", "") == "")
                {
                    returnValue = 0;
                    for (int j = values.Length - 1; j > item - 1; j--)
                        returnValue += float.Parse(values[j].Replace("н", "").Replace("ф", "").Replace("з", ""));
                    return float.Parse(textBox1.Text) - returnValue;
                }
                returnValue += float.Parse(values[i].Replace("н", "").Replace("ф", "").Replace("з", "")); 
            }

            return returnValue;
        }

        public float getHpenal()
        {
            string[] separator = new string[1] { "-" };
            string[] values = textBox3.Text.ToLower().Replace('.', ',').Replace("з", "").Replace("н", "").Replace("ф", "").Split(separator, StringSplitOptions.None);

            float returnValue = 0;
            float textHpenal = 0;

            try
            {
                if (textBox1.Text != "") textHpenal = float.Parse(textBox1.Text.ToLower().Replace('.', ','));

                for (int i = 0; i < values.Length; i++)
                    if (values[i] == "")
                    {
                        if (textHpenal > returnValue)
                            returnValue = textHpenal; break;
                    }
                    else
                        returnValue += float.Parse(values[i]);
            }
            catch { }
            if (returnValue == 0) label5.Text = "Укажите высоту"; else label5.Text = "";
            return returnValue;
        }
 
        public float getWpenal()
        {
            try{
                return float.Parse(textBox2.Text.Replace('.', ','));
            }catch{}

            return 600;
        }

        float getNisha(int id)
        {
            string[] values = textBox3.Text.ToLower().Replace('.', ',').Split(new char[1] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            float niz = -1;
            float verh = -1;

            string fValue = values[id].Replace("ф", "");
            if (fValue == "")
                fValue = (getUrov(values, id + 1) - getUrov(values, id)).ToString();
            float H = float.Parse(fValue);

            if (id > 0)
                niz = getUrov(values, id - 1) + 18;
            if (id > 1 && values[id - 2].Contains("ф"))niz = getUrov(values, id - 1)+float.Parse(values[id-1])/2 + 9;

            if (id < values.Length - 1)
                verh = getUrov(values, id) + H + float.Parse(values[id + 1]) - 18;
            if (id < values.Length - 2 && values[id + 2].Contains("ф"))
                verh = getUrov(values, id) + H + float.Parse(values[id + 1]) / 2 - 9;

            if (niz != -1 && verh != -1) return verh - niz;


            return H;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == 'з'
                 || e.KeyChar == 'З' || e.KeyChar == 'Ф' || e.KeyChar == 'Н' || e.KeyChar == 'ф' || e.KeyChar == 'н'
                 || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
                return;
            else
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dekoder();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));

            if (stroka1 != null)
            {
                textBox3.Text = stroka1;
                stroka1 = null;
            }
            //dekoder();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
                return;
            else
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
                return;
            else
                e.Handled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CreatePolki(textBox5.Text);
        }

        void createNishiPolok()
        {
            polki = new ArrayList();
            ArrayList fullUrovni = new ArrayList();

            if (textBox8.Text == "") return;

            string[] уровниМасс = textBox8.Text.ToLower().Replace('.',',').Split(new string[]{";"}, StringSplitOptions.RemoveEmptyEntries);

            fullUrovni.Add(-9);
            foreach (string v in уровниМасс) fullUrovni.Add(v);

            fullUrovni.Add((getHpenal()+9).ToString());

            ArrayList nishiPolok = new ArrayList();
            string outString = "";
            for (int i = 0; i < fullUrovni.Count - 1; i ++)
            {
                try
                {
                    float max = float.Parse(fullUrovni[i + 1].ToString().Replace(",", "."));
                    float min = float.Parse(fullUrovni[i].ToString().Replace(",", "."));

                    float H = (float)Math.Round(max - min - 18);
                    if (H < 50) continue;

                    int col = 0;

                    if (H > 500) col++;
                    if (H > 800) col++;
                    if (H > 1150) col++;

                    for (int j = 0; j < nishi.Count; j++)
                    {
                        float getUroven = float.Parse(SuperStr.SubString(nishi[j].ToString(), "н", "-"));
                        if (getUroven < float.Parse(fullUrovni[i + 1].ToString().Replace(",", ".")) && getUroven > float.Parse(fullUrovni[i].ToString().Replace(",", "."))) { col = 0; break; }
                    }
                    polki.Add(Math.Floor(float.Parse(fullUrovni[i].ToString().Replace(",", "."))) + 9);
                    outString += "н" + H.ToString() + "(" + col.ToString() + "); ";
                }
                catch { }
            }

            if (stroka3 != null)
            {
                outString = stroka3;
                stroka3 = null;
            }

            if (textBox5.Text == outString)
                CreatePolki(outString);
            textBox5.Text = outString;
            //CreatePolki(outString);
            
        }

        void CreatePolki(string value)
        {
            string outStr = "";

            try
            {
                //if (textBox5.Text != value)
                //{
                //    if (stroka3 != "")
                //    {
                //        value = stroka3;
                //        stroka3 = "";
                //    }

                //    textBox5.Text = value;

                //}

                string[] temp1 = textBox5.Text.Trim().Split(new Char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                

                for (int i = 0; i < temp1.Length; i++)
                {
                    string H = temp1[i].Replace("н", "").Split(new Char[1] { '(' })[0];
                    int col = 0;
                    try { col = int.Parse(SuperStr.SubString(temp1[i], "(", ")")); }
                    catch { }
                    if (col == 0) continue;

                    outStr += "н" + H.ToString().Trim() + "(";
                    float nisha = (float)Decimal.Round((decimal)((float.Parse(H) - (col * 18)) / (col + 1)), 1);

                    for (int j = 1; j < col + 1; j++)
                    {
                        outStr += (float.Parse(polki[i].ToString().Replace(",", ".")) - 18 + (nisha + 18) * j).ToString();
                        if (col != j) outStr += ";";
                    }
                    outStr += ")";

                    if (i != temp1.Length - 1) outStr += "; ";
                }
                
            }
            catch { }
            fullDraw(outStr);

       
        }

        public static void AssociateExtension(string applicationExecutablePath, string extension)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Classes", true);
            key.CreateSubKey("." + extension).SetValue(string.Empty, extension + "_auto_file");

            key = key.CreateSubKey(extension + "_auto_file");
            key.CreateSubKey("DefaultIcon").SetValue(string.Empty, applicationExecutablePath + ",0");

            key = key.CreateSubKey("Shell");
            key.SetValue(string.Empty, "Open");

            key = key.CreateSubKey("Open");

            key.CreateSubKey("Command").SetValue(string.Empty, "\"" + applicationExecutablePath + "\" \"%1\"");

            key.CreateSubKey("ddeexec\\Topic").SetValue(string.Empty, "System");
        }

        void fullDraw(string value)
        {
            if (textBox6.Text != value)
            {
                if (stroka4 != null)
                {
                    value = stroka4;
                    stroka4 = null;
                }
                textBox6.Text = value;
            }
            Draw();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "2-ф356-з3-ф356-2-н600-2-ф916-2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(img!=null) print();  
        }

        public void print()
        {
          
            // показываем окно настройки печати
            PrintDocument printDoc = new PrintDocument();
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDoc;
            if (dlg.ShowDialog() != DialogResult.Cancel)
            {
                printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
                try
                {
                    printDoc.Print();
                }
                catch { }
            }
        }
 
        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(img, 20,20, 786, 1130);
           // e.Graphics.DrawImage(img, 0, 0, 826, 1170); //по размеру A4
           // e.Graphics.TranslateTransform(0,0);
            //e.Graphics.RotateTransform(90);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                img.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                img.Dispose();
                string[] temp = saveFileDialog1.FileName.Split('.');
                temp[temp.Length - 1] = "FKP";
                string projectFilePatch = string.Join(".", temp);
                string textProject = textBox3.Text + "#" + textBox8.Text + "#" + textBox5.Text + "#" + textBox6.Text + "#" + textBox1.Text + "#" + textBox2.Text + "#" + checkBox1.Checked.ToString() + "#" + checkBox2.Checked.ToString() + "#" + textBox4.Text;


                File.WriteAllText(projectFilePatch,textProject);
            }
            catch { }
        }    

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, textBox3.SelectionStart, textBox3.SelectionLength);
            form2.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = checkBox3.Checked;
            loadListDetali();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            наборы_присадки набор = new наборы_присадки(this);
            набор.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
               
                    float H = getHpenal();
                    if (!checkBox2.Checked) H -= 18;
                   Xilog.load(Лприсадка, сторона.B, H, float.Parse(textBox7.Text));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                try
                {
                    float H = getHpenal();
                    if (!checkBox1.Checked) H -= 18;
                    Xilog.load(Пприсадка, сторона.J, H, float.Parse(textBox7.Text));
                }
                catch { }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Лприсадка.Count; i++)
                if (dataGridView1.Rows[i].Cells[0].Selected)
                {
                    ((деталь)Лприсадка[i]).сверление.name = "";
                
                }
            for (int i = 0; i < Пприсадка.Count; i++)
                if (dataGridView2.Rows[i].Cells[0].Selected)
                {
                    ((деталь)Пприсадка[i]).сверление.name = "";

                }
            loadListDetali();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Лприсадка.Count; i++)
                ((деталь)Лприсадка[i]).сверление.name = "";
            for (int i = 0; i < Пприсадка.Count; i++)
                ((деталь)Пприсадка[i]).сверление.name = "";
            loadListDetali();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            loadListDetali();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AssociateExtension(Application.ExecutablePath, "FKP");

            string text = "При добавлении уровней,\n разделяйте числа знаком \";\"";
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.textBox8, text);

            text = "Строка показывает текущие ниши,\n в скобках можно указать количество вкладных полок.";
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.textBox5, text);

            text = "в скобках можно изменить уровни вкладных полок,\n разделяйте числа знаком \";\"";
            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.SetToolTip(this.textBox6, text);


            text = "*Фасад обозначается буквой \"ф\", например: ф716, ф956, ф356\n";
            text += "*Ниша обозначается буквой \"н\", например: н599, н300\n";
            text += "*Зазор с видимым жестким щитом указываются без специального знака.\n";
            text += "*Зазор без щита обозначается буквой \"з\", например: з2, з7, з11.\n";
            text += "Образец: 2-ф356-з4-ф356-2-н600-18-н300-2-ф716-2";
            System.Windows.Forms.ToolTip ToolTip4 = new System.Windows.Forms.ToolTip();
            ToolTip4.SetToolTip(this.textBox3, text);

            ToolTip1.AutoPopDelay = ToolTip2.AutoPopDelay = ToolTip3.AutoPopDelay = ToolTip4.AutoPopDelay = 15000;

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                arrUrovni = new ArrayList();
                string[] уровниМасс = textBox8.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string v in уровниМасс) arrUrovni.Add(v);
            }
            createNishiPolok();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == ';')
                return;
            else
                e.Handled = true;
        }

        public void Form_KeyDown(object o, KeyEventArgs e)
        {
            // Ctrl + X     
            
            if (e.Control && e.KeyCode == Keys.R)
            {
                if (textBox8.Text != "" && checkBox1.Checked && checkBox2.Checked && textBox9.Text != "")
                {
                    EditBazaForm editbaza = new EditBazaForm(this);
                    editbaza.ShowDialog();
                    e.SuppressKeyPress = true;
                }
            }
        }

        public float getGlubina()
        {
            if (textBox9.Text != "")
                return float.Parse(textBox9.Text);
            return 560;
        }

    }
}
