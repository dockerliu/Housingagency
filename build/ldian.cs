using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace build
{
   public class ldian
    {
        private string _id;
        private string _ld_kehuleixing;
        private string _ld_name;
        private string _tele;
        private string _ld_neirong;
        private string _date;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ld_kehuleixing
        {
            get { return _ld_kehuleixing; }
            set { _ld_kehuleixing = value; }
        }
        public string ld_name
        {
            get { return _ld_name; }
            set { _ld_name = value; }
        }
        public string tele
        {
            get { return _tele; }
            set { _tele = value; }
        }
        public string ld_neirong
        {
            get { return _ld_neirong; }
            set { _ld_neirong = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
