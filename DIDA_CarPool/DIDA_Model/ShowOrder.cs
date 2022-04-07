using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class ShowOrder
    {
        /*
            OrderID 短途订单ID
            ShowID 短途信息ID
            UserID 用户ID
        */
        int orderID;
        int showID;
        int userID;

        public int OrderID { get => orderID; set => orderID = value; }
        public int ShowID { get => showID; set => showID = value; }
        public int UserID { get => userID; set => userID = value; }
    }
}
