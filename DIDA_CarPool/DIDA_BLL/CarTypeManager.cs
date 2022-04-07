using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDA_Model;
using System.Data;
using DIDA_DAL;

namespace DIDA_BLL
{
    public class CarTypeManager
    {
        //查询车辆类型表
        public static List<CarType> SelectCarType()
        {
            string sql = "select * from CarType";
            DataTable data = DBHelper.GetDataTable(sql);

            List<CarType> typeList = new List<CarType>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                CarType type = new CarType();
                type.CarID = int.Parse(data.Rows[i]["CarID"].ToString());
                type.CarName = data.Rows[i]["CarName"].ToString();

                typeList.Add(type);
            }
            return typeList;
        }
    }
}
