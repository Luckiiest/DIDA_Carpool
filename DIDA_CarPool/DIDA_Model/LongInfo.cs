using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class LongInfo
    {
        /* 
             LongID 长途信息ID
             UserTypeID 用户类型ID
             UserID 用户ID
             OpenCity 出发城市
             CloseCity 目的城市
             DepartureTime 出发时间
             HoldNumberPeople 可容纳人数
             NumberParticipants 报名人数
             NumberApplicants 申请人数
             CarID 汽车类型
             LongMsg 长途留言
             ReleaseTime 发布时间
             Price 价格
        */

        int id;                  //长途信息ID
        int userTypeID;              //用户类型ID
        int userID;                  //用户ID
        string openCity;             //出发城市
        string closeCity;            //目的城市
        DateTime departureTime;      //出发时间
        int holdNumberPeople;        //可容纳人数
        int numberParticipants;      //已报名人数
        int numberApplicants;        //申请人数
        string carID;                   //汽车类型
        string message;              //长途留言
        DateTime releaseTime;        //发布时间
        string price;                //价格

        public int ID { get => id; set => id = value; }
        public int UserTypeID { get => userTypeID; set => userTypeID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string OpenCity { get => openCity; set => openCity = value; }
        public string CloseCity { get => closeCity; set => closeCity = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public int HoldNumberPeople { get => holdNumberPeople; set => holdNumberPeople = value; }
        public int NumberParticipants { get => numberParticipants; set => numberParticipants = value; }
        public int NumberApplicants { get => numberApplicants; set => numberApplicants = value; }
        public string CarID { get => carID; set => carID = value; }
        public string Message { get => message; set => message = value; }
        public DateTime ReleaseTime { get => releaseTime; set => releaseTime = value; }
        public string Price { get => price; set => price = value; }
    }
}
