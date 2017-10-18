using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FK_NewPenal
{
    public partial class Form2 : Form
    {
        Form1 homeForm;
        int SelectStart, SelectLenght;
        public Form2(Form1 homeForm,int selectStart,int selectLenght)
        {
            InitializeComponent();
            this.homeForm = homeForm;
            this.SelectStart = selectStart;
            this.SelectLenght = selectLenght;
            loadData();
        }

        void loadData()
        {
            if (!File.Exists(Application.StartupPath + "\\мои_ниши.txt")) return;
            string[] fullData = (File.ReadAllText(Application.StartupPath + "\\мои_ниши.txt")).Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < fullData.Length; i++)
            {
                string[] tekObj = fullData[i].Split(new char[1]{'='});
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = tekObj[0].Trim();
                dataGridView1.Rows[i].Cells[1].Value = tekObj[1].Trim();
            }
        
        }

     
        void Save()
        {
            string saveStroka = "";
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                if (!dataGridView1.Rows[i].Cells[0].ToString().Trim().Equals(""))
                    saveStroka += dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() + " = " + dataGridView1.Rows[i].Cells[1].Value.ToString().Trim() + ";";                   
           if(!saveStroka.Equals(""))
           {
               File.WriteAllText(Application.StartupPath + "\\мои_ниши.txt", saveStroka,ASCIIEncoding.UTF8);
           }
        
        }


        private void button1_Click(object sender, EventArgs e)
        {
              Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string outStr = homeForm.textBox3.Text;
                outStr = outStr.Remove(SelectStart, SelectLenght);               

                int id = dataGridView1.CurrentRow.Index;
                if (!dataGridView1.Rows[id].Cells[1].Value.ToString().Trim().Equals(""))
                {
                    var insertText = "н" + dataGridView1.Rows[id].Cells[1].Value.ToString().Trim();
                    homeForm.textBox3.Text = outStr.Insert(SelectStart, insertText);                    
                    this.Close();
                }
            }
            catch { }
        }

  
   
 

        
    }
}
