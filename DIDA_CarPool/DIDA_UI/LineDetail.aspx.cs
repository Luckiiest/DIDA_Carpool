using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIDA_BLL;
using DIDA_Model;
using System.Data;
using System.Data.SqlClient;

namespace DIDA_UI
{
    public partial class LineDetail : System.Web.UI.Page
    {
        string lineID; //线路ID
        string lineType; //线路类型
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                lineID = Request.QueryString["id"];
                lineType = Request.QueryString["type"];
                if (lineType == "long")
                {
                    this.GetInfo(lineID,lineType);
                } else if(lineType == "show")
                {
                    this.GetInfo(lineID, lineType);
                }
            }
        }

        //获取线路中中属于该线路ID的信息
        protected void GetInfo(string id,string type)
        {
            if(type == "long")
            {
                DataTable longInfo = LineDetailManager.SelectLongLineInfo(id);
                LongInfoDetail_Repeater.DataSource = longInfo;
            } else if(type == "show")
            {
                DataTable showInfo = LineDetailManager.SelectShowLineInfo(id);
                LongInfoDetail_Repeater.DataSource = showInfo;
            }
            LongInfoDetail_Repeater.DataBind();
        }


        //申请/邀请加入点击事件
        protected void addRelease_ServerClick(object sender, EventArgs e)
        {
            if (IsLogin())
            {
                string userID = GetUserID(); //用户ID
                string id = lineID; //申请线路ID
                string type = lineType == "long" ? "0" : "1"; //线路类型
                bool IsApplyAndSelf = ApplicationManager.SelectApplication(id, userID, type); //判断是否申请过该条线路
                if(IsApplyAndSelf)
                {
                    // 添加入申请表中
                        ApplicationManager.AddApplication(id, userID, type);
                        ShowMessage("您已申请成功，请稍微等待通过！", "./Index.aspx");
                } else
                {
                    ShowMessage("自己不可以申请自己发布的线路！或您已申请过该条线路！", "./Index.aspx");
                }
            }
        }


        //获取本用户ID
        protected string GetUserID()
        {
            string userName = Session["userName"].ToString();
            string userID = UserInfoManager.SelectUserInfo(userName).UserID.ToString();
            return userID;
        }


        //是否登陆
        public bool IsLogin()
        {
            if (Session["userName"] == null)
            {
                ShowMessage("您还没有登陆，请登录。", "./Login.aspx");
                return false;
            }
            return true;
        }

        //显示弹窗
        public void ShowMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "');window.location.href='LineDetail.aspx?id=" + lineID + "&type=" + lineType + "'</script>");
        }

        //显示弹窗
        public void ShowMessage(string msg, string url)
        {
            Response.Write("<script>" +
                                    "window.alert('" + msg + "');" +
                                    "window.location.href ='" + url + "'" +
                                "</script>");
        }
        
        //获取手机号事件
        protected void LongInfoDetail_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (IsLogin())
            {
                if(e.CommandName == "requestPhone_Command")
                {
                    ShowMessage(e.CommandArgument.ToString());
                }
            }
        }
    }
}