using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FK_NewPenal
{
    public class деталь
    {
        public деталь(string x,string name)
        {
            this.x = x;
            this.name = name;   
        }
        public string x;
        public string name;
        public prisadka сверление;

        public void addSverlenie(prisadka _сверление)
        {
            this.сверление = _сверление;
        }
    }

    public class Profil
    {        
        public string имя;
        public prisadka дно;
        public prisadka щит;
        public prisadka полка;
    }

    [Serializable]
    public class sverlenie
    {
      
        public string y;
        public string шагX;
        public string шагY;
        public string диаметр;
        public string количество_отверстий;
        public string глубина;
        public _тип_сверла тип_сверла;
        public string зона_сверления;
    }

    public struct prisadka
    {
        //public prisadka()
        //{
        //    this.name = "пусто";
        //    сверление = new ArrayList();

        //}


        [XmlElement(Type = typeof(sverlenie))]
        public ArrayList сверление;        
        public string name;
        public void add(sverlenie присадка)
        {
            сверление.Add(присадка);
        }
    }

    public enum _тип_сверла
    {  
        глухое,
        сквозное
    }

    public enum сторона
    {
        B,
        J
    }



}

