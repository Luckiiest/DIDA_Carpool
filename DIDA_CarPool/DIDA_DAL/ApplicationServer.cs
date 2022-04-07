using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DIDA_DAL;
using DIDA_Model;

namespace DIDA_DAL
{
    public class ApplicationServer
    {
        //申请通过操作
        public static bool ApplicationIsSuccess(string lineID, string userID,string showOrLong,string status)
        {
            string sql = $"exec pass_application '{lineID}','{userID}','{showOrLong}','{status}'";
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 查询申请表中本人发送的长途线路
        public static DataTable SelectLongApplicant(string userID)
        {
            string sql = string.Format("select us.UserName,a.LineID,a.ShowOrLong,a.UserID,l.UserID 本用户,l.OpenCity,l.CloseCity from Application a ,LongInfo l,UserInfo us where a.LineID = l.ID and l.UserID = '{0}' and a.UserID = us.UserID and a.Status = '2'", userID);
            return DBHelper.GetDataTable(sql);
        }

        // 查询申请表中本人发送的短途线路
        public static DataTable SelectShowApplicant(string userID)
        {
            string sql = string.Format("select us.UserName,a.LineID,a.UserID,a.ShowOrLong,s.UserID,s.OpenCity,s.CloseCity  from Application a ,ShowInfo s,UserInfo us where a.LineID = s.ID and s.UserID = '{0}' and a.UserID = us.UserID and  a.Status = '2'", userID);
            return DBHelper.GetDataTable(sql);
        }

        //将通过的申请插入到LineMembers表中
        public static bool InsertMember(string lineID,string showOrlong, string members)
        {
            string sql = string.Format("insert into LineMembers(LineID, ShowOrLong, Members) Values({0}, {1}, '{2}')",lineID,showOrlong,members);
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 添加lineMembers中的成员
        public static bool UpdateMembers(string lineID, string showOrlong, string members)
        {
            string sql = string.Format("update LineMembers set Members = Members + '、' + '{0}' where LineID = '{1}' and ShowOrLong = '{2}'", members,lineID,showOrlong);
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 查询LineMember表中是否已经存在此线路
        public static DataTable SelectMembersIsExists(string lineID, string showOrlong)
        {
            string sql = string.Format("select * from LineMembers where LineID='{0}' and ShowOrLong='{1}'",lineID,showOrlong);
            return DBHelper.GetDataTable(sql);
        }


        // 更改申请表中的申请状态
        public static bool UpdateApplicationStatus(string lineID,string userID,string showOrlong,string status)
        {
            string sql = string.Format("update Application set Status='{0}' where lineID='{1}' and UserID = '{2}' and ShowOrLong='{3}'",status,lineID,userID,showOrlong);
            return DBHelper.ExecuteNonQuery(sql);
        }


        // 更改申请表中的用户已经申请状态
        public static bool UpdateStatus(string lineID, string userID, string showOrLong, string status)
        {
            string sql = string.Format("update Application set Status='{0}' + '-' where lineID='{1}' and UserID = '{2}' and ShowOrLong='{3}'", status, lineID, userID, showOrLong);
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 查询本用户是否申请过发布长途的线路，如果申请过，则查询
        public static DataTable SelectLongWhetherApply(string userID)
        {
            string sql = string.Format("select a.UserID,a.LineID,l.UserID 发布用户,a.ShowOrLong ,us.UserName, a.status, l.OpenCity, l.CloseCity from Application a,LongInfo l,UserInfo us where a.UserID='{0}' and (a.status='1' or a.status = '0') and a.UserID=us.UserID and l.ID = a.LineID", userID);
            return DBHelper.GetDataTable(sql);
        }

        // 查询本用户是否申请过发布短途的线路，如果申请过，则查询
        public static DataTable SelectShowWhetherApply(string userID)
        {
            string sql = string.Format("select a.UserID,a.LineID,s.UserID 发布用户,us.UserName,a.ShowOrLong, a.status, s.OpenCity, s.CloseCity from Application a,ShowInfo s,UserInfo us where a.UserID='{0}' and (a.status='1' or a.status = '0') and a.UserID=us.UserID and s.ID = a.LineID", userID);
            return DBHelper.GetDataTable(sql);
        }


        //删除申请表中申请失败的线路
        public static bool DeleteApplication(string lineID,string userID,string showOrLong,string status)
        {
            string sql = string.Format("delete from Application where userID='{0}' and lineID='{1}' and ShowOrLong='{2}' and Status='{3}'", userID, lineID, showOrLong,status);
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 更改长途信息中已参加人数
        public static bool UpdateLongInfoParticipants(string lindID)
        {
            string sql = string.Format("update LongInfo set NumberParticipants = NumberParticipants+1 where ID = '{0}'", lindID);
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 更改短途信息中已参加人数
        public static bool UpdateShowInfoParticipants(string lindID)
        {
            string sql = string.Format("update ShowInfo set NumberParticipants = NumberParticipants+1 where ID = '{0}'", lindID);
            return DBHelper.ExecuteNonQuery(sql);
        }


        // 查询长途线路的信息
        public static DataTable SelectLongInfo(string lineID)
        {
            string sql = string.Format("select * from LongInfo where ID='{0}'",lineID);
            return DBHelper.GetDataTable(sql);
        }


        // 查询短途线路的信息
        public static DataTable SelectShowInfo(string lineID)
        {
            string sql = string.Format("select * from ShowInfo where ID='{0}'",lineID);
            return DBHelper.GetDataTable(sql);
        }


        // 查询用户申请的长途线路
        public static DataTable SelectSelfApplyLongLine(string userID)
        {
            string sql = string.Format("select l.ID,l.OpenCity,l.CloseCity,l.DepartureTime,l.Price,c.CarName,l.NumberParticipants,l.HoldNumberPeople,a.Status from Application a,LongInfo l,UserInfo us,UserType ut,CarType c where a.UserID='{0}' and l.CarID = c.CarID and l.UserID = us.UserID  and a.LineID=l.ID and l.UserTypeID = ut.UserTypeId and a.ShowOrLong='0'", userID);
            return DBHelper.GetDataTable(sql);
        }

        // 查询用户申请的长途线路
        public static DataTable SelectSelfApplyShowLine(string userID)
        {
            string sql = string.Format("select s.ID, s.OpenCity, s.CloseCity, s.DepartureTime, s.Price, c.CarName, s.NumberParticipants, s.HoldNumberPeople, a.Status from Application a, ShowInfo s, UserInfo us, UserType ut, CarType c where a.UserID = '{0}' and s.CarID = c.CarID and s.UserID = us.UserID  and a.LineID = s.ID and s.UserTypeID = ut.UserTypeId and a.ShowOrLong='0'", userID);
            return DBHelper.GetDataTable(sql);
        }


        //添加申请表
        public static bool AddApplication(string lineID, string userID, string type)
        {
            string addSql = string.Format("insert into Application(LineID,UserID,ShowOrLong,Status) values('{0}','{1}','{2}','2')", lineID, userID, type);
            return DBHelper.ExecuteNonQuery(addSql);
        }

        // 查询是否申请过此条线路
        public static DataTable SelectApplication(string lineID, string userID, string type)
        {
            string sql = string.Format("select ID,UserID,LineID,ShowOrLong from Application where LineID='{0}' and UserID='{1}' and ShowOrLong='{2}'", lineID, userID, type);
            return DBHelper.GetDataTable(sql);
        }

        // 申请加入后更改长途线路申请人数
        public static bool UpdateLongApplicationNumber(string lineID)
        {
            string sql = string.Format("update LongInfo set NumberApplicants = NumberApplicants+1 where ID = '{0}'", lineID);
            return DBHelper.ExecuteNonQuery(sql);
        }

        // 申请加入后更改短途线路申请人数
        public static bool UpdateShowApplicationNumber(string lineID)
        {
            string sql = string.Format("update ShowInfo set NumberApplicants = NumberApplicants+1 where ID = '{0}'", lineID);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }   
}
