using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace build
{
   public class genjinkehu
    {
        private string _bianhao;
        private string _genjinren;
        private DateTime _genjin_time;
        private string _neirong;
        private string _iftixing;
        private string _f_genjin;
        private string _tixing_type;
        private string _tixing_date;
        private string _tixing_time;

        public string bianhao
        {
            get { return _bianhao; }
            set { _bianhao = value; }
        }
        public string genjinren
        {
            get { return _genjinren; }
            set { _genjinren = value; }
        }
        public string neirong
        {
            get { return _neirong; }
            set { _neirong = value; }
        }
        public string iftixing
        {
            get { return _iftixing; }
            set { _iftixing = value; }
        }
        public string f_genjin
        {
            get { return _f_genjin; }
            set { _f_genjin = value; }
        }
        public string tixing_type
        {
            get { return _tixing_type; }
            set { _tixing_type = value; }
        }
        public string tixing_date
        {
            get { return _tixing_date; }
            set { _tixing_date = value; }
        }
        public string tixing_time
        {
            get { return _tixing_time; }
            set { _tixing_time = value; }
        }
        public DateTime genjin_time
        {
            get { return _genjin_time; }
            set { _genjin_time = value; }
        }
    }
}
