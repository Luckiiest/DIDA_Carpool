using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIDA_Model;
using DIDA_BLL;
using System.Data;
using System.Data.SqlClient;

namespace DIDA_UI
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 控件验证
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                if(Session["userName"] != null)
                {
                    this.phone_txt.Value = Session["userName"].ToString();
                   // this.pwd_txt.Text = Session["Pwd"].ToString();
                }
            }
        }

        //登陆
        protected void Login_Btn_Click(object sender, EventArgs e)
        {
            //判断验证
            if (Page.IsValid)
            {
                string userName = this.phone_txt.Value;
                string pwd = this.pwd_txt.Value;
                //验证数据库是否可以查询出来,如果查询不出来就是null
                UserInfo userInfo = UserInfoManager.Login(userName, pwd);
                if (userInfo != null)
                {
                    SessionUser(userInfo);

                    Response.Redirect("./Index.aspx");
                }else
                {
                    ShowMessage("账号或密码不正确，请重新输入！");
                    this.phone_txt.Value = "";
                    this.pwd_txt.Value = "";
                }
            } 
        }


        //缓存用户信息
        protected void SessionUser(UserInfo userInfo)
        {
            if(userInfo.Phone != null)
            {
                Session["userName"] = userInfo.Phone;
            } else
            {
                Session["userName"] = userInfo.UserName;
            }
            Session["Pwd"] = userInfo.Password;
        }



        //显示弹窗
        public void ShowMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "');window.location.href='./Login.aspx'</script>");
        }
        //显示弹窗
        public void ShowMessage(string msg, string url)
        {
            Response.Write("<script>" +
                                    "window.alert('" + msg + "');" +
                                    "window.location.href ='" + url + "'" +
                                "</script>");
        }


    }
}