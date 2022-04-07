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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Bind();
                this.CarTypeBind();
            }
        }

        //绑定显示数据
        void Bind()
        {
            //绑定显示线路信息
            this.ShowInfo_Repeater.DataSource = ShowInfoManager.SelectShowInfo();
            this.ShowInfo_Repeater.DataBind();
        }

        void CarTypeBind()
        {
            //绑定汽车类型下拉选项框信息
            //车主
            this.showCarType.DataSource = CarTypeManager.SelectCarType();
            this.showCarType.DataTextField = "CarName";
            this.showCarType.DataValueField = "CarID";
            this.showCarType.DataBind();
        }


        //点击查询起始城市线路事件
        protected void Btn_Line_Search_Click(object sender, EventArgs e)
        {
            string open = this.open_city_input.Value;
            string close = this.close_city_input.Value;

            ClickBind(open, close);

            this.open_city_input.Value = "";
            this.close_city_input.Value = "";
        }

        // 查找起始城市之间线路
        void ClickBind(string open, string close)
        {
            List<ShowInfo> data = ShowInfoManager.SelectShowLine(open, close);
            if (data.Count > 0)
            {
                this.ShowInfo_Repeater.DataSource = data;
                this.ShowInfo_Repeater.DataBind();
            }
            else
            {
                this.ShowMessage("没有您想要的拼车信息，看看其他线路吧！", "./ShortDistance.aspx");
                Bind();
            }
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
            Response.Write("<script>alert('" + msg + "');window.location.href='ShortDistance.aspx'</script>");
        }

        //显示弹窗
        public void ShowMessage(string msg, string url)
        {
            Response.Write("<script>" +
                                    "window.alert('" + msg + "');" +
                                    "window.location.href ='" + url + "'" +
                                "</script>");
        }



        //车主发布信息点击事件
        protected void ShowOwner_ServerClick(object sender, EventArgs e)
        {
            //判断是否登陆成功
            if (IsLogin())
            {
                // 调用存储信息函数
                ShowInfo showInfo = OwnerInfo();
                // 判断出发时间是否在当前时间之后
                if (showInfo.DepartureTime > DateTime.Now.AddDays(-1))
                {
                    try
                    {
                        //执行插入函数
                        bool flag = ShowInfoManager.AddShowInfo(showInfo);
                        if (flag)
                        {
                            this.ShowMessage("发布成功！", "./ShortDistance.aspx");
                        }
                    }
                    catch (Exception)
                    {
                        this.ShowMessage("发布失败！");
                        throw;
                    }
                } else
                {
                    this.ShowMessage("出发时间不可以在今天之前");
                }
               
            }
        }

        //存储车主填写信息
        protected ShowInfo OwnerInfo()
        {
            try
            {
                ShowInfo showInfo= new ShowInfo();
                showInfo.OpenCity = this.showOpenCity.Value; //出发城市
                showInfo.CloseCity = this.showCloseCity.Value; //目的城市
                showInfo.DepartureTime = DateTime.Parse(this.showOpenTime.Value); //出发时间
                showInfo.HoldNumberPeople = int.Parse(this.showReleaseCount.Value); //可容纳人数
                showInfo.CarID = this.showCarType.Text; //汽车类型
                showInfo.Message = this.showMsg.Value; //留言
                showInfo.UserTypeID = 1; //用户类型ID
                showInfo.NumberParticipants = 0; //已报名人数
                showInfo.NumberApplicants = 0; //申请人数，一开始为0
                showInfo.ReleaseTime = DateTime.Now; //发布时间
                showInfo.Price = this.showPriceText.Value;

                //用户ID
                string userName = Session["userName"].ToString();
                UserInfo dt = UserInfoManager.SelectUserInfo(userName);
                int userID = int.Parse(dt.UserID.ToString());
                showInfo.UserID = userID;

                return showInfo;
            }
            catch (Exception)
            {
                ShowMessage("请输入有效值");
                return null;
            }
        }
    }
}