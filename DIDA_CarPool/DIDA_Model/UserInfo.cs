using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class UserInfo
    {
        /*    UserID 用户ID
            UserName 用户昵称
            Phone 用户电话          --添加索引
            Password 用户密码*/

        int userID;
        string userName;
        string phone;
        string password;

        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
    }
}
