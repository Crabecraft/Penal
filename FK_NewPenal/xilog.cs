using System;
using System.Windows.Forms;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace FK_NewPenal
{
    public class xilog
    {
        деталь[] список_сверления;
        string txt_programm;

    
        public void load(ArrayList список_сверления, сторона сторона, float DX,float DY)
        {
            try
            {
                txt_programm = "H DX=" + DX.ToString() + " DY=" + DY.ToString() + " DZ=18.00 -" + сторона.ToString() + " C=0 V71 T=1073741824 R=1 *MM /\"def.tlg\"\n";
                this.список_сверления = (деталь[])список_сверления.ToArray(typeof(деталь));
                createProgramm();
            }
            catch { }
        }
        void createProgramm()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(Application.StartupPath + "\\txt_programm");
                DirectoryInfo[] dirs = info.GetDirectories();
                FileInfo[] files = info.GetFiles();
                for (int i = 0; i < files.Length; i++)
                    files[i].Delete();
            }
            catch { }
            Directory.CreateDirectory(Application.StartupPath + "\\txt_programm");
            for (int i = 0; i < список_сверления.Length; i++)
              if(список_сверления[i].сверление.name != "")
                  if(список_сверления[i].сверление.сверление != null)
                      for (int j = 0; j < список_сверления[i].сверление.сверление.Count; j++)
                      {
                          sverlenie temp = (sverlenie)список_сверления[i].сверление.сверление[j];
                          if(temp.тип_сверла == _тип_сверла.глухое)
                              txt_programm += 
                                  "XBO X=" + список_сверления[i].x 
                                  + " Y=" + temp.y.ToUpper()
                                  + " Z=" + temp.глубина.ToUpper()
                                  + " D=" + temp.диаметр.ToUpper()
                                  + " R=" + temp.количество_отверстий.ToUpper() 
                                  + " x=" + temp.шагX.ToUpper()
                                  + " y=" + temp.шагY.ToUpper()
                                  + " N=\"P\" F=" 
                                  + temp.зона_сверления 
                                  + " K=0 P=0\n";
                          else
                              txt_programm += 
                                  "XBO X=" + список_сверления[i].x
                                 + " Y=" + temp.y.ToUpper()
                                 + " Z=" + temp.глубина.ToUpper()
                                 + " D=" + temp.диаметр.ToUpper()
                                 + " R=" + temp.количество_отверстий.ToUpper()
                                 + " x=" + temp.шагX.ToUpper()
                                 + " y=" + temp.шагY.ToUpper()
                                 + " N=\"L\" F="
                                 + temp.зона_сверления
                                 + " K=0 P=0\n";
                              
                      }
            //XBO X=9 Y=100 Z=34 D=5 R=5 x=0 y=32 N="P" F=3 K=0 P=0

            txt_programm = txt_programm.Replace(",", ".");
            string data = DateTime.Now.ToString().Replace(":", "").Replace(".", "").Replace(" ", "");

            System.IO.File.WriteAllText(Application.StartupPath + "\\txt_programm\\fk_proga" + data + ".xxl", txt_programm);
            try
            {
                Process.Start(Application.StartupPath + "\\txt_programm\\fk_proga" + data + ".xxl");
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
}
