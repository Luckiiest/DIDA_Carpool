using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class UserType
    {
        /*
            UserTypeId 用户类型Id
            UserTypeName 用户类型名称
        */

        int userTypeId;
        string UserTypeName;

        public int UserTypeId { get => userTypeId; set => userTypeId = value; }
        public string UserTypeName1 { get => UserTypeName; set => UserTypeName = value; }
    }
}
