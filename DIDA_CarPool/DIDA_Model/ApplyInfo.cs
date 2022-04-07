using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class ApplyInfo
    {
        /* 
             InfoID 长/短信息ID
             UserID 申请用户ID
             InfoType 长短信息类别  0-短 1-长
        */


        int infoID;
        int userID;
        int InfoType;

        public int InfoID { get => infoID; set => infoID = value; }
        public int UserID { get => userID; set => userID = value; }
        public int InfoType1 { get => InfoType; set => InfoType = value; }
    }
}
