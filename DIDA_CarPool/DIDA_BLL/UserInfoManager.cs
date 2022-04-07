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
    public class UserInfoManager
    {
        //登陆验证
        public static UserInfo Login(string userName,string pwd)
        {
            DataTable ds = UserInfoServer.CheckLogin(userName, pwd);

            if (ds.Rows.Count > 0)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.Phone = userName;
                userInfo.UserName = userName;
                userInfo.Password = pwd;
                return userInfo;
            }
            else
            {
                return null;
            }
        }

        // 注册验证
        public static bool CheckRegister(string phone,string userName)
        {
            DataTable ds = UserInfoServer.CheckRegister(phone, userName);
            if (ds != null && ds.Rows.Count >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //注册添加
        public static bool AddUser(UserInfo user)
        {
            return UserInfoServer.AddUser(user);
        }


        /// 通过电话号码查找用户信息
        public static DataTable SelectUserInfo(string userName,string pwd)
        {
            return UserInfoServer.SelectUser(userName,pwd);
        }



        //根据电话号码查询或用户名用户ID
        public static UserInfo SelectUserInfo(string phone)
        {
            return UserInfoServer.SelectUserInfo(phone);
        }
    }
}
