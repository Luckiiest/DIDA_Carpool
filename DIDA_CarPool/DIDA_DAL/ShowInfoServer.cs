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
    public class ShowInfoServer
    {

        //查询短途线路信息
        public static List<ShowInfo> SelectShowInfo()
        {
            string sql = "select * from showInfo s,CarType c, UserInfo us, UserType ut where s.CarID = c.CarID and s.UserID = us.UserID and s.UserTypeID = ut.UserTypeId and s.DepartureTime > GETDATE()-1 order by ID desc";
            DataTable data = DBHelper.GetDataTable(sql);

            List<ShowInfo> showInfos = new List<ShowInfo>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ShowInfo showInfo = new ShowInfo();
                showInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                showInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                showInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                showInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                showInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                showInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                showInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                showInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                showInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                showInfo.CarID = data.Rows[i]["CarName"].ToString();
                showInfo.Message = data.Rows[i]["Message"].ToString();
                showInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                showInfo.Price = data.Rows[i]["Price"].ToString();

                showInfos.Add(showInfo);
            }
            return showInfos;
        }

        
        public static List<ShowInfo> SelectShowInfo(string userID)
        {
            string sql = string.Format("select * from showInfo s,CarType c, UserInfo us, UserType ut where s.CarID = c.CarID and s.UserID = us.UserID and s.UserTypeID = ut.UserTypeId and us.UserID='{0}' order by ID desc", userID);
            DataTable data = DBHelper.GetDataTable(sql);

            List<ShowInfo> showInfos = new List<ShowInfo>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ShowInfo showInfo = new ShowInfo();
                showInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                showInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                showInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                showInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                showInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                showInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                showInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                showInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                showInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                showInfo.CarID = data.Rows[i]["CarName"].ToString();
                showInfo.Message = data.Rows[i]["Message"].ToString();
                showInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                showInfo.Price = data.Rows[i]["Price"].ToString();

                showInfos.Add(showInfo);
            }
            return showInfos;
        }

        // 根据起始地址查询线路信息
        public static List<ShowInfo> SelectShowLine(string open, string close)
        {
            string sql = string.Format("select * from showInfo s,CarType c, UserInfo us, UserType ut where s.CarID = c.CarID and s.UserID = us.UserID and s.UserTypeID = ut.UserTypeId and s.DepartureTime > GETDATE() and OpenCity like '%{0}%' and CloseCity like '%{1}%' order by ID desc", open, close);
            DataTable data = DBHelper.GetDataTable(sql);

            List<ShowInfo> showInfos = new List<ShowInfo>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ShowInfo showInfo = new ShowInfo();
                showInfo.ID = int.Parse(data.Rows[i]["ID"].ToString());
                showInfo.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                showInfo.UserTypeID = int.Parse(data.Rows[i]["UserTypeID"].ToString());
                showInfo.OpenCity = data.Rows[i]["OpenCity"].ToString();
                showInfo.CloseCity = data.Rows[i]["CloseCity"].ToString();
                showInfo.DepartureTime = DateTime.Parse(data.Rows[i]["DepartureTime"].ToString());
                showInfo.HoldNumberPeople = int.Parse(data.Rows[i]["HoldNumberPeople"].ToString());
                showInfo.NumberParticipants = int.Parse(data.Rows[i]["NumberParticipants"].ToString());
                showInfo.NumberApplicants = int.Parse(data.Rows[i]["NumberApplicants"].ToString());
                showInfo.CarID = data.Rows[i]["CarName"].ToString();
                showInfo.Message = data.Rows[i]["Message"].ToString();
                showInfo.ReleaseTime = DateTime.Parse(data.Rows[i]["ReleaseTime"].ToString());
                showInfo.Price = data.Rows[i]["Price"].ToString();

                showInfos.Add(showInfo);
            }
            return showInfos;
        }


        //删除短途信息表
        public static bool DeleteLongInfo(string id)
        {
            string sql = string.Format("delete from ShowInfo where ID={0}", id);
            return DBHelper.ExecuteNonQuery(sql);
        }


        //添加短途线路信息
        public static bool AddShowInfo(ShowInfo infoList)
        {
            string sql = string.Format("insert into ShowInfo(UserTypeID, UserID, OpenCity, CloseCity, DepartureTime, HoldNumberPeople, NumberParticipants, NumberApplicants, CarID, Message, ReleaseTime, Price) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", infoList.UserTypeID, infoList.UserID, infoList.OpenCity, infoList.CloseCity, infoList.DepartureTime, infoList.HoldNumberPeople, infoList.NumberParticipants, infoList.NumberApplicants, infoList.CarID, infoList.Message, infoList.ReleaseTime, infoList.Price);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
