using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DIDA_Model;

namespace DIDA_DAL
{
    public class UserInfoServer
    {
        /**
         * 验证登陆模块
         * 
         */
        public static DataTable CheckLogin(string userName, string pwd)
        {
            string sql = string.Format("select UserID from UserInfo where (Phone='{0}' or UserName='{0}') and PassWord='{1}'", userName, pwd);

            return DBHelper.GetDataTable(sql);
        }


        /**
         * 
         * 注册添加模块
         */
        public static bool AddUser(UserInfo user)
        {
            string sql = string.Format("insert into UserInfo(UserName,Phone,PassWord) values('{0}','{1}','{2}')", user.UserName, user.Phone, user.Password);
            return DBHelper.ExecuteNonQuery(sql);
        }

        /**
         * 注册验证模块
         * 判断用户是否存在
         */
        public static DataTable CheckRegister(string phone,string userName)
        {
            string sql = string.Format("select * from UserInfo where Phone='{0}' or UserName='{1}'",phone, userName);
            return DBHelper.GetDataTable(sql);
        }


        /// <summary>
        /// 通过用户的电话号码查找ID
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static DataTable SelectUser(string userName, string pwd)
        {
            return DBHelper.GetDataTable(string.Format("select [UserID] ,[UserName] ,[Phone] ,[Password] from [UserInfo]  where ([Phone]='{0}' or [UserName]='{0}') and [PassWord]='{1}'", userName,pwd));
        }


        //根据电话号码查询或用户名用户ID
        public static UserInfo SelectUserInfo(string phone)
        {
            string sql = string.Format("select UserID,UserName,Phone,PassWord from UserInfo where Phone='{0}' or UserName='{0}'", phone);
            DataTable data = DBHelper.GetDataTable(sql);

            UserInfo user = new UserInfo();
            for (int i = 0; i < data.Rows.Count; i++)
            {

                user.UserID = int.Parse(data.Rows[i]["UserID"].ToString());
                user.UserName = data.Rows[i]["UserName"].ToString();
                user.Phone = data.Rows[i]["Phone"].ToString();
                user.Password = data.Rows[i]["Password"].ToString();
            }
            return user;
        }
    }
}
