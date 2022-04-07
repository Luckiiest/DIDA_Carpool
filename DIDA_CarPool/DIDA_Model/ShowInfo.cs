using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class ShowInfo
    {
        /*
            ShowID 短途信息ID
            UserID 用户ID
            CarID 汽车类型
            UserTypeID 用户类型ID
            OpenCity 出发地址
            CloseCity 目的地址
            DepartureTime 出发时间
            Price 价格
            NumberParticipants 报名人数
            NumberApplicants 申请人数
            HoldNumberPeople 可容纳人数
            ReleaseTime 发布时间
            ShowMsg 短途留言
        */
        int id;
        int userID;
        string carId;
        int userTypeID;
        string openCity;
        string closeCity;
        DateTime departureTime;
        string price;
        int numberParticipants;
        int numberApplicants;
        int holdNumberPeople;
        DateTime releaseTime;
        string message;

        public int ID { get => id; set => id = value; }
        public int UserID { get => userID; set => userID = value; }
        public string CarID { get => carId; set => carId = value; }
        public int UserTypeID { get => userTypeID; set => userTypeID = value; }
        public string OpenCity { get => openCity; set => openCity = value; }
        public string CloseCity { get => closeCity; set => closeCity = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public string Price { get => price; set => price = value; }
        public int NumberParticipants { get => numberParticipants; set => numberParticipants = value; }
        public int NumberApplicants { get => numberApplicants; set => numberApplicants = value; }
        public int HoldNumberPeople { get => holdNumberPeople; set => holdNumberPeople = value; }
        public DateTime ReleaseTime { get => releaseTime; set => releaseTime = value; }
        public string Message { get => message; set => message = value; }
    }
}
