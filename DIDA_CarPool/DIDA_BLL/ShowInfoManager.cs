using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDA_DAL;
using DIDA_Model;
using System.Data;
using System.Data.SqlClient;

namespace DIDA_BLL
{
    public class ShowInfoManager
    {
        //查询短途线路信息
        public static List<ShowInfo> SelectShowInfo()
        {
            return ShowInfoServer.SelectShowInfo();
        }

        public static List<ShowInfo> SelectShowInfo(string userID)
        {
            return ShowInfoServer.SelectShowInfo(userID);
        }

        // 根据起始地址查询线路信息
        public static List<ShowInfo> SelectShowLine(string open, string close)
        {
            return ShowInfoServer.SelectShowLine(open, close);
        }

        //删除短途信息表
        public static bool DeleteLongInfo(string id)
        {
            string sql = string.Format("delete from ShowInfo where ID={0}", id);
            return DBHelper.ExecuteNonQuery(sql);
        }

        //添加长途线路信息
        public static bool AddShowInfo(ShowInfo infoList)
        {
            return ShowInfoServer.AddShowInfo(infoList);
        }
    }
}
