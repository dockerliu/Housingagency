using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace build
{
   public class NameEventArgs:EventArgs
    {
     private  string str1 = "";
     private  int snum;
       public string Str
       {
           get { return str1; }
           set { str1 = value; }
       }
       public int Snum
       {
           get { return snum; }
           set { snum = value; }
       }
    }
}
