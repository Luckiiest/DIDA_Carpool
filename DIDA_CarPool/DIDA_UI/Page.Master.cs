using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIDA_BLL;
using DIDA_Model;
using System.Data;

namespace DIDA_UI
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["userName"] != null && Session["Pwd"] != null)
                {
                    string userName = Session["userName"].ToString();
                    string pwd = Session["Pwd"].ToString();
                    if (UserInfoManager.Login(userName, pwd) != null)
                    {
                        DataTable data = UserInfoManager.SelectUserInfo(userName, pwd);
                        Name = data.Rows[0]["userName"].ToString();
                    }
                }
                else
                {
                    Name = null;
                }
            }
        }


        //退出清空Session
        protected void Exit_Click(object sender, EventArgs e)
        {
            if(Session["userName"] != null)
            {
                Session.Remove("Phone");
                Session.Remove("userName");
                Session.Remove("Pwd");
            }
            Response.Redirect("Index.aspx");
        }
    }
}