using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIDA_Model;
using DIDA_BLL;

namespace DIDA_UI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Register_Btn_Click(object sender, EventArgs e)
        {
           
            //判断验证是否存在
            if(Page.IsValid)
            {
                // 验证手机号码和用户名是否存在
                if (UserInfoManager.CheckRegister(this.phone_txt.Value,this.UserName.Value))
                {
                    UserInfo userInfo = new UserInfo();
                    //存储信息
                    this.UserInfo(userInfo);
                    // 注册验证是否成功
                    bool isAdd = this.IsAddUser(userInfo);
                    //如果成功则缓存手机号码
                    this.IsSuccess(isAdd,userInfo);
                } else
                {
                    ShowMessage("该手机号或用户名已存在，请重新输入");
                }
            }
        }


        //存储信息
        protected void UserInfo(UserInfo userInfo)
        {
            userInfo.Phone = this.phone_txt.Value;
            userInfo.Password = this.pwd_txt.Value;
            userInfo.UserName = this.UserName.Value;
        }

        //判断是否注册成功
        protected bool IsAddUser(UserInfo userInfo)
        {
            try
            {
                //进行注册信息，向数据库添加数据，如果失败，返回false
                UserInfoManager.AddUser(userInfo);
                return true;
            } catch (Exception)
            {
                return false;
            }
        }


        //判断注册是否成功，跳转页面
        protected void IsSuccess(bool isAdd,UserInfo userInfo)
        {
            if(isAdd)
            {
                this.SessionUser(userInfo);
                this.ShowMessage("注册成功，请登陆！", "./Login.aspx");
            } else
            {
                this.ShowMessage("注册失败，请请重试！");
            }
        }


        //缓存用户信息
        protected void SessionUser(UserInfo userInfo)
        {
            if (userInfo.Phone != null)
            {
                Session["userName"] = userInfo.Phone;
            }
            else
            {
                Session["userName"] = userInfo.UserName;
            }
        }



        //显示弹窗
        public void ShowMessage(string msg)
        {
            Response.Write("<script>alert('" + msg + "'); window.location.href='./Register.aspx'</script>");
        }
        //显示弹窗
        public void ShowMessage(string msg,string url)
        {
            Response.Write("<script>" +
                                    "window.alert('"+ msg + "');" +
                                    "window.location.href ='" + url + "'" +
                                "</script>");
        }

    }
}