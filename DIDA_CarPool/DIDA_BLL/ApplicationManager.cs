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
    public class ApplicationManager
    {
        //申请通过操作
        public static bool ApplicationIsSuccess(string lineID, string userID, string showOrLong, string status)
        {
            return ApplicationServer.ApplicationIsSuccess(lineID, userID, showOrLong, status);
        }

        // 查询申请表中本人发送的长途线路
        public static DataTable SelectLongApplicant(string userID)
        {
            return ApplicationServer.SelectLongApplicant(userID);
        }

        // 查询申请表中本人发送的短途线路
        public static DataTable SelectShowApplicant(string userID)
        {
            return ApplicationServer.SelectShowApplicant(userID);
        }

        //将通过的申请插入到LineMembers表中
        public static bool InsertMember(string lineID, string showOrlong, string members)
        {
            return ApplicationServer.InsertMember(lineID, showOrlong, members);
        }

        // 添加lineMembers中的成员
        public static bool UpdateMembers(string lineID, string showOrlong,string members)
        {
            return ApplicationServer.UpdateMembers(lineID, showOrlong, members);
        }

        // 查询LineMember表中是否已经存在此线路
        public static bool SelectMembersIsExists(string lineID, string showOrlong)
        {
            DataTable dt = ApplicationServer.SelectMembersIsExists(lineID, showOrlong);
            if(dt.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        // 更改申请表中的申请状态
        public static bool UpdateApplicationStatus(string lineID, string userID, string showOrlong, string status)
        {
            return ApplicationServer.UpdateApplicationStatus(lineID, userID, showOrlong, status);
        }


        // 查询本用户是否申请过发布的长途线路，如果申请过，则查询
        public static DataTable SelectLongWhetherApply(string userID)
        {
            return ApplicationServer.SelectLongWhetherApply(userID);
        }

        // 查询本用户是否申请过发布短途的线路，如果申请过，则查询
        public static DataTable SelectShowWhetherApply(string userID)
        {
            return ApplicationServer.SelectShowWhetherApply(userID);
        }

        //删除申请表中申请失败的线路
        public static bool DeleteApplication(string lineID, string userID, string showOrLong,string status)
        {
            return ApplicationServer.DeleteApplication(lineID, userID, showOrLong,status);
        }


        // 更改申请表中的用户已经申请状态
        public static bool UpdateStatus(string lineID, string userID, string showOrLong, string status)
        {
            return ApplicationServer.UpdateStatus(lineID, userID, showOrLong, status);
        }


        // 更改长途信息中已参加人数

        public static bool UpdateLineInfoParticipants(string lineID, string type)
        {
            switch (type)
            {
                case "0":
                    return ApplicationServer.UpdateLongInfoParticipants(lineID);
                case "1":
                    return ApplicationServer.UpdateShowInfoParticipants(lineID);
            }
            return false;
        }


        //查询线路的信息
        public static DataTable SelectLineInfo(string lineID, string type)
        {
            switch(type)
            {
                case "0":
                    return ApplicationServer.SelectLongInfo(lineID);
                case "1":
                    return ApplicationServer.SelectShowInfo(lineID);
            }
            return null;
        }


        // 查询用户申请的长途线路
        public static DataTable SelectSelfApplyLongLine(string userID)
        {
            return ApplicationServer.SelectSelfApplyLongLine(userID);
        }

        // 查询用户申请的长途线路
        public static DataTable SelectSelfApplyShowLine(string userID)
        {
            return ApplicationServer.SelectSelfApplyShowLine(userID);
        }

        //添加申请表
        public static bool AddApplication(string lineID, string userID, string type)
        {
            return ApplicationServer.AddApplication(lineID, userID, type);
        }


        // 查询申请表，是否已经申请过
        public static bool SelectApplication(string lineID, string userID, string type)
        {
            // 查询是否申请过此线路
            DataTable data = ApplicationServer.SelectApplication(lineID, userID, type);
            //判断是否是本人
            bool IsOnSelf = LineDetailManager.SelectSelfUser(lineID, userID, type);

            if (IsOnSelf && data.Rows.Count <= 0)
            {
                // 根据线路类型更新长途线路申请人数
                switch (type)
                {
                    case "0":
                        return ApplicationServer.UpdateLongApplicationNumber(lineID);
                    case "1":
                        return ApplicationServer.UpdateShowApplicationNumber(lineID);
                }
                return true;
            }
            return false;
        }
    }
}
