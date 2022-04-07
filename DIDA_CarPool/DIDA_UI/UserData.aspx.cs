using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIDA_Model;
using DIDA_BLL;
using System.Data.SqlClient;
using System.Data;

namespace DIDA_UI
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["userName"] == null)
            {
                Response.Write("<script>alert('您还未登录，请登录！');window.location.href='./Login.aspx';</script>");
            }else
            {
                //获取用户的id
                string userId = UserInfoManager.SelectUserInfo(Session["userName"].ToString()).UserID.ToString();

                Bind(userId);
            }

        }
    
        protected void Bind(string userId)
        {
            //绑定长途订单
            List<LongInfo> LongData = LongInfoManager.SelectLongInfo(userId);
            this.LongData_Repeater.DataSource = LongData;
            this.LongData_Repeater.DataBind();

            //绑定短途订单
            List<ShowInfo> ShowData = ShowInfoManager.SelectShowInfo(userId);
            this.ShowData_Repeater.DataSource = ShowData;
            this.ShowData_Repeater.DataBind();

            //绑定申请长途订单
            DataTable LongApplyData = ApplicationManager.SelectSelfApplyLongLine(userId);
            this.LongApply_Repeater.DataSource = LongApplyData;
            this.LongApply_Repeater.DataBind();

            //绑定申请短途订单
            DataTable ShowApplyData = ApplicationManager.SelectSelfApplyShowLine(userId);
            this.ShowApply_Repeater.DataSource = ShowApplyData;
            this.ShowApply_Repeater.DataBind();
        }

        protected string GetUserPhoto(string photoPath)
        {
            if (photoPath == "0" || photoPath == "0-")
            {
                return "申请失败";
            }
            else if (photoPath == "1" || photoPath == "1-")
            {
                return "申请成功";
            }
            else
            {
                return "座位已满";
            }
        }
    }
}