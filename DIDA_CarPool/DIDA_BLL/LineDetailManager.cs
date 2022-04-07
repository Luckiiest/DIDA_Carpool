using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDA_Model;
using DIDA_DAL;
using System.Data;

namespace DIDA_BLL
{
    public class LineDetailManager
    {
        //查询线路信息
        public static DataTable SelectLongLineInfo(string id)
        {
            return LineDetailServer.SelectLongLineInfo(id);
        }

        //查找短途线路详细信息
        public static DataTable SelectShowLineInfo(string id)
        {
            return LineDetailServer.SelectShowLineInfo(id);
        }

        // 查询用户ID，是否是本人，本人不可申请
        public static bool SelectSelfUser(string lineID, string userID, string type)
        {
            string lineUserID;
            switch (type)
            {
                case "0":
                    lineUserID = LineDetailServer.SelectLongLineInfo(lineID).Rows[0]["UserID"].ToString(); //线路中的UserID
                    return lineUserID == userID ? false : true;
                case "1":

                    lineUserID = LineDetailServer.SelectShowLineInfo(lineID).Rows[0]["UserID"].ToString(); //线路中的UserID
                    return lineUserID == userID ? false : true;
            }
            return true;
        }
    }
}
