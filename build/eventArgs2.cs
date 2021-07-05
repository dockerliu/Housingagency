using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace build
{
   public class eventArgs2:System.EventArgs
    {
        string stri1 = "";
        int ssnum;
        public string str
        {
            get
            {
                return stri1;
            }
            set
            {
                stri1 = value;
            }
        }
        public int ss_num
        {

            get
            {
                return ssnum;
            }
            set
            {
                ssnum = value;
            }
        }
    }
}
