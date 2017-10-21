using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace FK_NewPenal
{
    public partial class FindExcel : Form
    {
        ArrayList arrbooks = new ArrayList();
        Excel.Workbooks books;
        Excel.Worksheet teksheet;
        bool nashel;
        string[] левая, правая;


        public FindExcel(string[] левая, string[] правая)
        {
            InitializeComponent();
            this.левая = левая;
            this.правая = правая;

            load();
        }

        void load()
        {
            var instance = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            books = instance.Workbooks;
            arrbooks = new ArrayList();
            listBox1.Items.Clear();

            for (int i = 1; i < books.Count + 1; i++)
            {
                
                Excel.Workbook book = books[i];
                Excel.Worksheet sheet = null;
                try
                {
                    sheet = (Excel.Worksheet)book.Sheets[10];
                    if (sheet.Name == "Черновик")
                    {
                        listBox1.Items.Add(((Excel.Range)sheet.Cells[1, 2]).Value);
                        arrbooks.Add(sheet);
                    }
                }
                catch { }
            }
        }

        private void listBox1_Click(object sender, System.EventArgs e)
        {
            if (listBox1.Text != "")
                loadList2();
        }

        void loadList2()
        {
            listBox2.Items.Clear();

            for (int i = 1; i < books.Count + 1; i++)
            {

                Excel.Workbook book = books[i];
                Excel.Worksheet sheet = null;
                try
                {
                    sheet = (Excel.Worksheet)book.Sheets[10];
                    teksheet = sheet;
                    if (sheet.Name == "Черновик")
                    {
                        string temp = ((Excel.Range)sheet.Cells[1, 2]).Value.ToString();
                        if (temp == listBox1.Text)
                        {
                            
                            for (int j = 2; j < 1000; j++)
                            {
                                string val1 = ((Excel.Range)sheet.Cells[j - 1, 1]).Text.ToString();
                                string val2 = ((Excel.Range)sheet.Cells[j, 1]).Text.ToString();


                                if(val2 != "")
                                    if (val1 == "")
                                    {
                                        listBox2.Items.Add(((Excel.Range)sheet.Cells[j, 6]).Value.ToString());
                                    }

                                if (val1 == "" && val2 == "")
                                    return;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void listBox2_DoubleClick(object sender, System.EventArgs e)
        {
            if (listBox2.Text == "") return;

            for (int i = 1; i < books.Count + 1; i++)
            {

                Excel.Workbook book = books[i];
                Excel.Worksheet sheet = null;
                try
                {
                    sheet = (Excel.Worksheet)book.Sheets[10];
                    teksheet = sheet;
                    if (sheet.Name == "Черновик")
                    {
                        string temp = ((Excel.Range)sheet.Cells[1, 2]).Value.ToString();
                        if (temp == listBox1.Text)
                        {
                            int tekstroka = -1;
                            for (int j = 2; j < 1000; j++)
                            {
                                string val1 = ((Excel.Range)sheet.Cells[j - 1, 1]).Text.ToString();
                                string val2 = ((Excel.Range)sheet.Cells[j, 1]).Text.ToString();


                                if (val2 != "")
                                    if (val1 == "")
                                    {
                                         tekstroka++;
                                    }

                                if (val1 == "" && val2 == "")
                                    return;

                                if (tekstroka == listBox2.SelectedIndex)
                                {
                                    ((Excel.Range)sheet.Cells[j + 1, 13]).Value = левая[0];
                                    ((Excel.Range)sheet.Cells[j + 1, 14]).Value = левая[1];
                                    ((Excel.Range)sheet.Cells[j + 2, 13]).Value = правая[0];
                                    ((Excel.Range)sheet.Cells[j + 2, 14]).Value = правая[1];
                                    nashel = true;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
                catch { }
                
                
            }
             if (nashel) this.Close();
        }
    }
}
