using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.IO;

namespace FK_NewPenal
{
    public partial class наборы_присадки : Form
    {
        ArrayList шаблоны;
        ArrayList профили;

        Form1 form;
        public наборы_присадки(Form1 form)
        {
            InitializeComponent();
            шаблоны = new ArrayList();
            профили = new ArrayList();
            loadData();
            LoadDataProfils();
            this.form = form;
        }

        void loadListProfils()
        {
            listBox2.Items.Clear();
            for (int i = 0; i < профили.Count; i++)
                listBox2.Items.Add(((Profil)профили[i]).имя);        
        }
        void addProfil()
        {
            try
            {
                prisadka дно = new prisadka() { name = "" };
                prisadka щит = new prisadka() { name = "" };
                prisadka полка = new prisadka() { name = "" };

                for (int i = 0; i < form.Лприсадка.Count; i++)
                {
                    if (((деталь)form.Лприсадка[i]).name == "дно") дно = ((деталь)form.Лприсадка[i]).сверление;
                    if (((деталь)form.Лприсадка[i]).name == "полка") полка = ((деталь)form.Лприсадка[i]).сверление;
                    if (((деталь)form.Лприсадка[i]).name == "щит") щит = ((деталь)form.Лприсадка[i]).сверление;
                }

                if (дно.name == "" || полка.name == "" || щит.name == "")
                    for (int i = 0; i < form.Пприсадка.Count; i++)
                    {
                        if (((деталь)form.Пприсадка[i]).name == "дно") дно = ((деталь)form.Пприсадка[i]).сверление;
                        if (((деталь)form.Пприсадка[i]).name == "щит") щит = ((деталь)form.Пприсадка[i]).сверление;
                        if (((деталь)form.Пприсадка[i]).name == "полка") полка = ((деталь)form.Пприсадка[i]).сверление;
                    }
                профили.Add(new Profil() { имя = "новый", дно = дно, полка = полка, щит = щит });

                SaveDataProfils();
                loadListProfils();
            }
            catch { }
        }

        void deleteProfil()
        {
            if (listBox2.Text != "")
            {
                профили.RemoveAt(listBox2.SelectedIndex);
                SaveDataProfils();
                loadListProfils();
            }
        }
        void saveProfil()
        {
            if (listBox2.Text != "")
            {
                ((Profil)профили[listBox2.SelectedIndex]).имя = textBox2.Text;
                SaveDataProfils();
                loadListProfils();
            }
        }
        void loadProfil()
        {
            try
            {
                if (textBox2.Text == "") return;
                Profil tek = (Profil)профили[listBox2.SelectedIndex];

                for (int i = 0; i < form.Лприсадка.Count; i++)
                {
                    if (((деталь)form.Лприсадка[i]).name == "дно") ((деталь)form.Лприсадка[i]).сверление = tek.дно;
                    if (((деталь)form.Лприсадка[i]).name == "щит") ((деталь)form.Лприсадка[i]).сверление = tek.щит;
                    if (((деталь)form.Лприсадка[i]).name == "полка") ((деталь)form.Лприсадка[i]).сверление = tek.полка;
                }
                for (int i = 0; i < form.Пприсадка.Count; i++)
                {
                    if (((деталь)form.Пприсадка[i]).name == "дно") ((деталь)form.Пприсадка[i]).сверление = tek.дно;
                    if (((деталь)form.Пприсадка[i]).name == "щит") ((деталь)form.Пприсадка[i]).сверление = tek.щит;
                    if (((деталь)form.Пприсадка[i]).name == "полка") ((деталь)form.Пприсадка[i]).сверление = tek.полка;
                }

                form.loadListDetali();
                this.Close();
            }
            catch { }
        }
        void LoadDataProfils()
        {
            string patch = Application.StartupPath + "\\профили.xml";
            if (!File.Exists(patch)) return;
            try
            {
                профили = new ArrayList();
                XmlSerializer formatter = new XmlSerializer(typeof(Profil[]));
                using (FileStream fs = new FileStream(patch, FileMode.OpenOrCreate))
                {
                    Profil[] loadingProfil = (Profil[])formatter.Deserialize(fs);
                    for (int i = 0; i < loadingProfil.Length; i++)
                        профили.Add(loadingProfil[i]);
                }
                loadListProfils();
            }
            catch { }
        }
        void SaveDataProfils()
        {
            string patch = Application.StartupPath + "\\профили.xml";
            File.Delete(patch);
            Profil[] temp = (Profil[])профили.ToArray(typeof(Profil));
            XmlSerializer formatter = new XmlSerializer(typeof(Profil[]));
            using (FileStream fs = new FileStream(patch, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, temp);
            }
        }

        void loadTek()
        {
            dataGridView1.Rows.Clear();
            
            if (listBox1.Text != "")
                if (шаблоны[listBox1.SelectedIndex] != null)
                {
                    prisadka temp = (prisadka)шаблоны[listBox1.SelectedIndex];
                    textBox1.Text = temp.name;

                    if (temp.сверление.Count > 0)
                        for (int i = 0; i < temp.сверление.Count; i++)
                            if (temp.сверление[i] != null)
                            {
                                dataGridView1.Rows.Add();
                                sverlenie temp2 = (sverlenie)temp.сверление[i];
                                dataGridView1.Rows[i].Cells[0].Value = temp2.y;
                                dataGridView1.Rows[i].Cells[1].Value = temp2.глубина;
                                dataGridView1.Rows[i].Cells[2].Value = temp2.диаметр;
                                dataGridView1.Rows[i].Cells[3].Value = temp2.количество_отверстий;
                                dataGridView1.Rows[i].Cells[4].Value = temp2.шагX;
                                dataGridView1.Rows[i].Cells[5].Value = temp2.шагY;
                                dataGridView1.Rows[i].Cells[6].Value = temp2.тип_сверла.ToString();
                                dataGridView1.Rows[i].Cells[7].Value = temp2.зона_сверления;
                            }
                }
        
        
        
        }
        void saveTek()
        {
            if (textBox1.Text == "") return;

            prisadka temp = new prisadka();
            temp.name = textBox1.Text;
            temp.сверление = new ArrayList();

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                            if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
                                if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "")
                                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() != "")
                                        if (dataGridView1.Rows[i].Cells[5].Value.ToString() != "")
                                            if (dataGridView1.Rows[i].Cells[6].Value.ToString() != "")
                                                if (dataGridView1.Rows[i].Cells[7].Value.ToString() != "")
                                            {
                                                _тип_сверла temp2 = _тип_сверла.глухое;
                                                string temp_tip = dataGridView1.Rows[i].Cells[6].Value.ToString();
                                                switch (temp_tip)
                                                {
                                                    case "глухое": temp2 = _тип_сверла.глухое; break;
                                                    case "сквозное": temp2 = _тип_сверла.сквозное; break;
                                                }


                                                temp.сверление.Add(new sverlenie()
                                                {
                                                    y = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                                                    шагX = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                                                    шагY = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                                                    диаметр = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                                                    глубина = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                                                    количество_отверстий = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                                                    тип_сверла = temp2,
                                                    зона_сверления = dataGridView1.Rows[i].Cells[7].Value.ToString()
                                                });



                                            }

                шаблоны[listBox1.SelectedIndex] = temp;


                loadListBox();
            }
            catch { }
        }
        void loadListBox()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < шаблоны.Count; i++)
            {
                if (шаблоны[i] != null)
                    listBox1.Items.Add(((prisadka)шаблоны[i]).name);            
            }
        }
        void add()
        {
            шаблоны.Add(new prisadka() {сверление = new ArrayList(),name = "Пусто" });
            loadListBox();
        }

        void saveData()
        {
            string patch = Application.StartupPath + "\\шаблоны.xml";
            File.Delete(patch);
            prisadka[] temp = (prisadka[])шаблоны.ToArray(typeof(prisadka));
            XmlSerializer formatter = new XmlSerializer(typeof(prisadka[]));
            using (FileStream fs = new FileStream(patch, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, temp);
            }
        }
        void loadData()
        {
            string patch = Application.StartupPath + "\\шаблоны.xml";
           if(!File.Exists(patch)) return;
           try
           {
               шаблоны = new ArrayList();
               XmlSerializer formatter = new XmlSerializer(typeof(prisadka[]));
               using (FileStream fs = new FileStream(patch, FileMode.OpenOrCreate))
               {
                   prisadka[] newPrisadka = (prisadka[])formatter.Deserialize(fs);
                   for (int i = 0; i < newPrisadka.Length; i++)
                       шаблоны.Add(newPrisadka[i]);
               }
               loadListBox();
           }
           catch { }
        }

        void setPrisadka()
        {
            if (listBox1.Text == "") return;

            for(int i=0; i < form.dataGridView1.Rows.Count; i++)
                if (form.dataGridView1.Rows[i].Selected)
                {
                    ((деталь)form.Лприсадка[i]).addSverlenie((prisadka)шаблоны[listBox1.SelectedIndex]);
                }
            for (int i = 0; i < form.dataGridView2.Rows.Count; i++)
                if (form.dataGridView2.Rows[i].Selected)
                {
                    ((деталь)form.Пприсадка[i]).addSverlenie((prisadka)шаблоны[listBox1.SelectedIndex]);
                }
        
        
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            add();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            loadTek();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveTek();
            saveData();
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            setPrisadka();
            form.loadListDetali();
            this.Close();
        }

        private void button4_Paint(object sender, PaintEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                шаблоны.RemoveAt(listBox1.SelectedIndex);
                loadListBox();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadProfil();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addProfil();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveProfil();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            deleteProfil();
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.Text != "")
                textBox2.Text = listBox2.Text;
        }



    
    }
}
