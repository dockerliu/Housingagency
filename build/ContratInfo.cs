using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace build
{
  public  class ContratInfo
    {
        private string _ContractName;//合同
        private string _ContractAddress;//合同

        private string _ParaInfo;//参数设置
        private string _ParaSet;//参数设置

        private string _Warn;//提醒管理 借用以上4个参数
        private string _Warn2;//提醒管理



        public string ContractName//合同
        {
            get { return _ContractName; }
            set { _ContractName = value; }
        }

        public string ContractAddress//合同
        {
            get { return _ContractAddress; }
            set { _ContractAddress = value; }
        }

        public string ParaInfo //参数设置
        {
            get { return _ParaInfo; }
            set { _ParaInfo = value; }
        }
        public string ParaSet //参数设置
        {
            get { return _ParaSet; }
            set { _ParaSet = value; }
        }
        public string Warn //提醒管理
        {
            get { return _Warn; }
            set { _Warn = value; }
        }
        public string Warn2 //提醒管理
        {
            get { return _Warn2; }
            set { _Warn2 = value; }
        }
    }
}
