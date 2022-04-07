using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDA_Model
{
    public class CarType
    {
        /*
            CarID 汽车类型ID
            CarName 汽车类型名称
        */

        int carID;
        string carName;

        public int CarID { get => carID; set => carID = value; }
        public string CarName { get => carName; set => carName = value; }
    }
}
