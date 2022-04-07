using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDA_Model;
using System.Data;
using System.Data.SqlClient;

namespace DIDA_DAL
{
    public class LongInfoServer
    {

        //查询长途线路信息
        public static List<LongInfo> SelectLongInfo()
        {
            List<LongInfo> longInfos = new List<LongInfo>();
            string sql = "select * from longInfo l,CarType c, UserInfo us, UserType ut where l.CarID = c.CarID and l.UserID = us.UserID and l.UserTypeID = ut.UserTypeId and l.DepartureTime > GETDATE()-1 order by ID desc";
            DataTable data = DBHelper.GetDataTable(sql);
            for(int i = 0;i < data.Rows.Count; i++)
            {
                LongInfo longInfo = new LongInfo();
                longInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                longInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                longInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                longInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                longInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                longInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                longInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                longInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                longInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                longInfo.CarID = data.Rows[i]["CarName"].ToString();
                longInfo.Message = data.Rows[i]["Message"].ToString();
                longInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                longInfo.Price = data.Rows[i]["Price"].ToString();

                longInfos.Add(longInfo);
            }
            return longInfos;
        }

        public static List<LongInfo> SelectLongInfo(string userID)
        {
            string sql = string.Format("select * from longInfo l,CarType c, UserInfo us, UserType ut where l.CarID = c.CarID and l.UserID = us.UserID and l.UserTypeID = ut.UserTypeId and us.UserID = '{0}' order by ID desc",userID);
            DataTable data = DBHelper.GetDataTable(sql);

            List<LongInfo> longInfos = new List<LongInfo>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                LongInfo longInfo = new LongInfo();
                longInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                longInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                longInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                longInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                longInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                longInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                longInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                longInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                longInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                longInfo.CarID = data.Rows[i]["CarName"].ToString();
                longInfo.Message = data.Rows[i]["Message"].ToString();
                longInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                longInfo.Price = data.Rows[i]["Price"].ToString();

                longInfos.Add(longInfo);
            }
            return longInfos;
        }

        //删除长途信息表
        public static bool DeleteLongInfo(string id)
        {
            string sql = string.Format("delete from LongInfo where ID={0}", id);
            return DBHelper.ExecuteNonQuery(sql);
        }


        //添加长途线路信息
        public static bool AddLongInfo(LongInfo infoList)
        {
            string sql = string.Format("insert into LongInfo(UserTypeID, UserID, OpenCity, CloseCity, DepartureTime, HoldNumberPeople, NumberParticipants, NumberApplicants, CarID, Message, ReleaseTime, Price) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')",infoList.UserTypeID,infoList.UserID,infoList.OpenCity,infoList.CloseCity,infoList.DepartureTime,infoList.HoldNumberPeople,infoList.NumberParticipants,infoList.NumberApplicants,infoList.CarID,infoList.Message,infoList.ReleaseTime,infoList.Price);
            return DBHelper.ExecuteNonQuery(sql);
        }

        


        //根据起始地址和时间查找长途线路信息
        public static List<LongInfo> SelectLongLine(string openCity,string closeCity, string openTime, string closeTime)
        {
            string sql = string.Format("select * from longInfo l,CarType c, UserInfo us, UserType ut where l.CarID = c.CarID and l.UserID = us.UserID and l.UserTypeID = ut.UserTypeId and l.DepartureTime > GETDATE()-1 and OpenCity like '%{0}%' and CloseCity like '%{1}%' and DepartureTime between '{2}' and '{3}' order by ID desc",openCity,closeCity,openTime,closeTime);
            DataTable data = DBHelper.GetDataTable(sql);

            List<LongInfo> longInfos = new List<LongInfo>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                LongInfo longInfo = new LongInfo();
                longInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                longInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                longInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                longInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                longInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                longInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                longInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                longInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                longInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                longInfo.CarID = data.Rows[i]["CarName"].ToString();
                longInfo.Message = data.Rows[i]["Message"].ToString();
                longInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                longInfo.Price = data.Rows[i]["Price"].ToString();

                longInfos.Add(longInfo);
            }
            return longInfos;
        }
        //根据起始地址或时间查询长途线路信息
        public static List<LongInfo> SelectLongLine(string open, string close)
        {
            string sql = string.Format("select * from longInfo l,CarType c, UserInfo us, UserType ut where l.CarID = c.CarID and l.UserID = us.UserID and l.UserTypeID = ut.UserTypeId and l.DepartureTime > GETDATE()-1 and OpenCity like '%{0}%' and CloseCity like '%{1}%' order by ID desc",open,close);
            DataTable data = DBHelper.GetDataTable(sql);

            List<LongInfo> longInfos = new List<LongInfo>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                LongInfo longInfo = new LongInfo();
                longInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                longInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                longInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                longInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                longInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                longInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                longInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                longInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                longInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                longInfo.CarID = data.Rows[i]["CarName"].ToString();
                longInfo.Message = data.Rows[i]["Message"].ToString();
                longInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                longInfo.Price = data.Rows[i]["Price"].ToString();

                longInfos.Add(longInfo);
            }
            return longInfos;
        }
    }   
}
