using System;
namespace SuperSrting
{
    public static class SuperStr
    {   
        public static string SubString(string value, string v1, string v2)
        {
            string[] returnStrings = SubStrings(value,v1,v2);
            if (returnStrings != null) return returnStrings[0];
            return null;
        }
        public static string[] SubStrings(string value, string v1, string v2)
        {
            return  eSubStrings(value,v1,v2);
        }
        public static string[] SubStrings(string value, string v1, string v2, SubStringsOptions SubStringsOption)
        {
            string[] returnStr = eSubStrings(value, v1, v2);
            if (returnStr != null && (int)SubStringsOption == 1)
            {
                System.Collections.ArrayList returnStrArr = new System.Collections.ArrayList();
                foreach (string v in returnStr) if (v.Replace(" ", "") != "") returnStrArr.Add(v);
                return (string[])returnStrArr.ToArray(typeof(string));
            }
            return returnStr;
        }                

        private static string[] eSubStrings(string value,string v1, string v2)
        {
            Char[] charStroka = value.ToCharArray();
            Char[] charV1 = v1.ToCharArray();
            Char[] charV2 = v2.ToCharArray();
            System.Collections.ArrayList returnList = new System.Collections.ArrayList();

            for(int i = 0; i < charStroka.Length;i ++)
                if (charStroka[i] == charV1[0])
                    for (int j = 0; j < charV1.Length; j++)
                        try
                        {
                   
                        if (charV1[j] != charStroka[i + j]) break;
                        if (j == charV1.Length - 1)
                            for (int x = i + j + 1; x < charStroka.Length; x++)
                                if (charStroka[x] == charV2[0])
                                {
                                    for (int y = 0; y < charV2.Length; y++)
                                    {
                                        if (charV2[y] != charStroka[x + y]) break;
                                        if (y == charV2.Length - 1)
                                        {
                                            returnList.Add(value.Substring(i + j + 1, (x+y - charV2.Length) - (i + j)));
                                            break;
                                        }
                                    }
                                    break;
                                }
                
                        }
                        catch { }
            if (returnList.Count > 0)
                return (string[])returnList.ToArray(typeof(string));


            return null;
        }
    }

    public enum SubStringsOptions
    {        
        None = 0,
        RemoveEmptyEntries = 1,
    }
}
  