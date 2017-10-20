using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FK_NewPenal
{
    public partial class FindExcel : Form
    {
        public FindExcel()
        {
            InitializeComponent();
            load();
        }

        void load()
        {
            var tek = new Excel.Application();
            System.Diagnostics.Process[] tekProc = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //System.Diagnostics.Process[] oldProc = System.Diagnostics.Process.GetProcessesByName("EXCEL");

            Excel.Application instance = null;
            try
            {
                instance = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка выполнения" + ex.Message);
            }

            instance = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");


            for (int i = 1; i < instance.Workbooks.Count+1; i++)
            {
                Excel.Workbook books = instance.Workbooks[i];
                Excel.Worksheet sheet = (Excel.Worksheet)books.Sheets[1];
                string temp = sheet.Cells[1, 2].ToString();
                MessageBox.Show(temp);
            }


            
            //var tek = (Excel.Application)tekProc[0].get;
            Excel.Workbooks book = tek.Workbooks;
            //Excel.Workbook book = books.Open((string)((object[])value)[0]);
            //Excel.Worksheet sheet = null;



        }
    }
}
