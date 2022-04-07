using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDA_Model;
using DIDA_DAL;
using System.Data;
using System.Data.SqlClient;

namespace DIDA_BLL
{
    public class LongInfoManager
    {
        //查询长途线路信息
        public static List<LongInfo> SelectLongInfo()
        {
            return LongInfoServer.SelectLongInfo();
        }
        public static List<LongInfo> SelectLongInfo(string userID)
        {
            return LongInfoServer.SelectLongInfo(userID);
        }


        //删除长途信息表
        public static bool DeleteLongInfo(string id)
        {
            return LongInfoServer.DeleteLongInfo(id);
        }

        //添加长途线路信息
        public static bool AddLongInfo(LongInfo infoList)
        {
            return LongInfoServer.AddLongInfo(infoList);
        }


        


        //根据起始地址和时间查找长途线路信息
        public static List<LongInfo> SelectLongLine(string open, string close, string time)
        {
            if(time == "")
            {
                return LongInfoServer.SelectLongLine(open, close);
            }
            string timeOne = time;
            string timeTwo = DateTime.Parse(time).AddDays(1).ToString();
            return LongInfoServer.SelectLongLine(open, close, timeOne, timeTwo);
        }
    }
}
