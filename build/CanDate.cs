using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
namespace build
{
    public partial class CanDate : Form
    {
        public CanDate()
        {
            InitializeComponent();
        }
       public const string   CelestialStem="甲乙丙丁戊己庚辛壬癸";
       public const string TerrestrialBranch = "子丑寅卯辰巳午未申酉戌亥";
       public const string TreeYear = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
        private void CanDate_Load(object sender, EventArgs e)
        {
            string intmonth = monthCalendar1.TodayDate.Month.ToString();
            string intday = monthCalendar1.TodayDate.Day.ToString();
            if (monthCalendar1.TodayDate.Month < 10)
            {
                intmonth = "0" + monthCalendar1.TodayDate.Month.ToString();
            }
            if (monthCalendar1.TodayDate.Day < 10)
            {
                intday = "0" + monthCalendar1.TodayDate.Day.ToString();
            }
            string s = String.Format("{0}年{1}月{2}", GetStemBranch(monthCalendar1.TodayDate), GetMonth(monthCalendar1.TodayDate), GetDay(monthCalendar1.TodayDate));//把当前的日期转换成中国传统日期
            this.label1.Text = monthCalendar1.TodayDate.Year + "年" + intmonth + "月" + intday + "日" + "      " + s + " " + getReturnYear(monthCalendar1.TodayDate)+"年";
           
        }

        ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        /// <summary>
        /// 将公历日期中的月份转换成农历的月份
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string GetMonth(DateTime time)
        {
            int month = calendar.GetMonth(time);
            int year = calendar.GetYear(time);
            int leap = 0;
            for (int i = 3; i <= month;i++ )
            {
                if (calendar.IsLeapMonth(year, i))//判断是否为闰月
                {
                    leap = i;
                    break;//一年中只有一个闰月
                }
            }
            if (leap > 0) month--;
            return(leap==month+1?"闰":"")+ChineseMonthName[month-1];
        }
        public static readonly string[] ChineseMonthName = new string[] {"正","二","三","四","五","六","七","八","九","十","十一","十二" };

        public string GetDay(DateTime time)
        {
            return ChineseDayName[calendar.GetDayOfMonth(time)-1];
        }
        public static readonly string[] ChineseDayName = new string[] {"初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
            "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
            "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十" };
       
        public string GetStemBranch(DateTime time)//将公历日期转换成农历年份的干支纪年。
        {
            int sexxagenaryYear = calendar.GetSexagenaryYear(time);
            string stemBranch = CelestialStem.Substring(calendar.GetCelestialStem(sexxagenaryYear)-1,1)+TerrestrialBranch.Substring(calendar.GetTerrestrialBranch(sexxagenaryYear)-1,1);
            return stemBranch;

        }
        //取出公历日期中的生肖年份
        public string getReturnYear(DateTime time)
        {
            int sexagenaryYear = calendar.GetSexagenaryYear(time);
            string Tree = TreeYear.Substring(calendar.GetTerrestrialBranch(sexagenaryYear)-1,1);
            return Tree;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string strYesr = String.Format("{0}年{1}月{2}", GetStemBranch(monthCalendar1.SelectionStart),
                GetMonth(monthCalendar1.SelectionStart),
                GetDay(monthCalendar1.SelectionStart));
            toolTip1.ToolTipTitle = monthCalendar1.SelectionStart.ToShortDateString();
            toolTip1.Show(strYesr + " " + getReturnYear(monthCalendar1.SelectionStart) + "年", monthCalendar1, monthCalendar1.Location, 5000);
        }
        
    }
     
}
