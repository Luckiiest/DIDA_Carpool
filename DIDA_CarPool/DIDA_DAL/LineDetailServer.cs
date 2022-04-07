using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DIDA_Model;

namespace DIDA_DAL
{
    public class LineDetailServer
    {
        //查找长途线路详细信息
        public static DataTable SelectLongLineInfo(string id)
        {
            string sql = string.Format("select * from LongInfo l inner join UserInfo u on l.UserID=u.UserID join CarType c on l.CarID=c.CarID where l.ID='{0}'", id);
            return DBHelper.GetDataTable(sql);

            /*List<LongInfo> longInfos = new List<LongInfo>();
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
                longInfo.Phone = data.Rows[i]["Phone"].ToString();
                longInfos.Add(longInfo);
            }
            return longInfos;*/
        }

        //查找短途线路详细信息
        public static DataTable SelectShowLineInfo(string id)
        {
            string sql = string.Format("select * from ShowInfo s inner join UserInfo u on s.UserID=u.UserID join CarType c on s.CarID=c.CarID where s.ID='{0}'", id);

            return DBHelper.GetDataTable(sql);

           /* List<ShowInfo> showInfos = new List<ShowInfo>();
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
            return showInfos;*/
        }

    }
}
