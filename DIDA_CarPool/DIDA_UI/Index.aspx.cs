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
using System.Web.Services;

namespace DIDA_UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Bind();
                this.CarTypeBind();
                if (Session["userName"] != null)
                {
                    this.BindApplyLine();
                    this.BindDetermineLine();
                }
            }
        }

        //绑定显示数据
        void Bind()
        {
            //绑定显示线路信息
            this.LongInfo_Repeater.DataSource = LongInfoManager.SelectLongInfo();
            this.LongInfo_Repeater.DataBind();
        }

        // 汽车类型绑定
        void CarTypeBind()
        {
            //绑定汽车类型下拉选项框信息
            //车主
            this.ownerCarType.DataSource = CarTypeManager.SelectCarType();
            this.ownerCarType.DataTextField = "CarName";
            this.ownerCarType.DataValueField = "CarID";
            this.ownerCarType.DataBind();
        }

        // 申请加入线路显示绑定
        void BindApplyLine()
        {
            string userID = GetUserID();

            DataTable dt = ApplicationManager.SelectLongApplicant(userID);

            DataTable ds = ApplicationManager.SelectShowApplicant(userID);

            dt.Merge(ds);
            this.Popup_Repeater1.DataSource = dt;
            this.Popup_Repeater1.DataBind();
        }

        // 申请加入线路失败或成功显示绑定
        void BindDetermineLine()
        {
            string userID = GetUserID();
            DataTable dt = ApplicationManager.SelectLongWhetherApply(userID);

            DataTable ds = ApplicationManager.SelectShowWhetherApply(userID);

            dt.Merge(ds);
            this.Popup_Repeater2.DataSource = dt;
            this.Popup_Repeater2.DataBind();
        }

        //获取本用户ID
        protected string GetUserID()
        {
            if(Session["userName"] != null)
            {
                string userName = Session["userName"].ToString();
                string userID = UserInfoManager.SelectUserInfo(userName).UserID.ToString();
                return userID;
            }
            return null;
        }

        //点击绑定数据事件
        protected void Btn_Line_Search_Click(object sender, EventArgs e)
        {
            string open = this.open_city_input.Value;
            string close = this.close_city_input.Value;
            string time = this.release_time_input.Value.ToString();

            ClickBind(open, close, time);

            this.open_city_input.Value = "";
            this.close_city_input.Value = "";
            this.release_time_input.Value = "";
        }

        // 查找起始城市之间线路
        void ClickBind(string open, string close, string time)
        {
            // 查询长途线路
            List<LongInfo> data = LongInfoManager.SelectLongLine(open, close, time);
            if (data.Count > 0)
            {
                this.LongInfo_Repeater.DataSource = data;
                this.LongInfo_Repeater.DataBind();
            }
            else
            {
                Response.Write("<script>alert('没有您想要的拼车信息，看看其他线路吧！')</script>");
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
            Response.Write("<script>alert('" + msg + "');window.location.href='Index.aspx'</script>");
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
        protected void LongOwner_ServerClick(object sender, EventArgs e)
        {
            //判断是否登陆成功
            if (IsLogin())
            {
                // 调用存储信息函数
                LongInfo longInfo = OwnerInfo();

                // 判断出发时间是否在当前时间之后
                if (longInfo.DepartureTime > DateTime.Now.AddDays(-1))
                {
                    try
                    {
                        //执行插入函数
                        bool flag = LongInfoManager.AddLongInfo(longInfo);
                        if (flag)
                        {
                            this.ShowMessage("发布成功！", "./Index.aspx");
                        }
                    }
                    catch (Exception)
                    {
                        this.ShowMessage("发布失败！");
                        throw;
                    }
                }else
                {
                    this.ShowMessage("不可以发布在今天之前");
                }
            }
            else
            {
                this.ShowMessage("请输入现在之后的时间");
            }
        }


        //存储车主填写信息
        protected LongInfo OwnerInfo()
        {
            try
            {
                LongInfo longInfo = new LongInfo();
                longInfo.OpenCity = this.ownerOpenCity.Value; //出发城市
                longInfo.CloseCity = this.ownerCloseCity.Value; //目的城市
                longInfo.DepartureTime = DateTime.Parse(this.ownerOpenTime.Value); //出发时间
                longInfo.NumberParticipants = int.Parse(this.ownerReleaseCount.Value); //已报名人数
                longInfo.HoldNumberPeople = int.Parse(this.ownerholdCount.Value); //可容纳人数
                longInfo.CarID = this.ownerCarType.Text; //汽车类型
                longInfo.Message = this.ownerMsg.Value; //留言
                longInfo.UserTypeID = 1; //用户类型ID
                longInfo.NumberApplicants = 0; //申请人数，一开始为0
                longInfo.ReleaseTime = DateTime.Now; //发布时间

                //用户ID
                string userName = Session["userName"].ToString();
                UserInfo dt = UserInfoManager.SelectUserInfo(userName);
                int userID = int.Parse(dt.UserID.ToString());
                longInfo.UserID = userID;

                //价格
                if (this.ownerFacePrice.Checked)
                {
                    longInfo.Price = "面议";
                }
                else if (this.ownerDecisionPrice.Checked)
                {
                    longInfo.Price = this.ownerPriceText.Value;
                }

                return longInfo;
            }
            catch (Exception)
            {
                ShowMessage("请输入有效值");
                return null;
            }
        }

        // 申请的线路被拒绝或同意
        protected void Popup1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            if(cmdName == "determine")
            {
                string[] arr = e.CommandArgument.ToString().Split(',');
                string lineID = arr[0];
                string userID = arr[1];
                string status = arr[2];
                string showOrLong = arr[3];

               
                bool result = ApplicationManager.UpdateStatus(lineID, userID, showOrLong, status);
                if (result)
                {
                    ShowMessage("可以多来看看！");
                }
            }
        }


        // 发布的用户进行是否接受，拒绝线路
        protected void Popup_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            // 获取线路信息
            string cmdName = e.CommandName;
            
            // 同意申请
            if (cmdName == "adopt")
            {
                string[] arr = e.CommandArgument.ToString().Split(',');
                string lineID = arr[0];
                string userID = arr[1];
                string showOrLong = arr[2];
                string status = "1";
                this.PassApplication(lineID, showOrLong, userID, status);

            // 拒绝申请
            } else if(cmdName == "fail")
            {
                string[] arr = e.CommandArgument.ToString().Split(',');
                string lineID = arr[0];
                string userID = arr[1];
                string showOrLong = arr[2];
                string status = "0";
                this.RefuseApplication(lineID, showOrLong, userID, status);
            }
        }

        // 申请拒绝操作
        protected void RefuseApplication(string lineID, string showOrLong, string userID, string status)
        {
            bool refuse = ApplicationManager.UpdateApplicationStatus(lineID, userID, showOrLong, status);
            if(refuse)
            {
                ShowMessage("您拒绝了他的请求！");
            }
        }

        // 申请通过操作
        protected void PassApplication(string lineID,string showOrLong,string userID, string status)
        {
            DataTable lineInfo = ApplicationManager.SelectLineInfo(lineID, showOrLong);

            // 获取HoldNumber和participants两个值是否相等，如果相等，则不可以在同意申请
            string holdNumber = lineInfo.Rows[0]["HoldNumberPeople"].ToString();
            string participants = lineInfo.Rows[0]["NumberParticipants"].ToString();
            if (holdNumber == participants)
            {
               //ShowMessage(participants);
               /* bool IsSeat = ApplicationSettingManager.UpdateStatus(lineID, userID, showOrLong, "2");
                if (IsSeat)
                {*/
                    ShowMessage("不能再同意了，您的座位已经满了");
                //}
            }
            else
            {

                bool result = ApplicationManager.ApplicationIsSuccess(lineID, userID, showOrLong, status);
                if(result)
                {
                    ShowMessage("您已通过他的申请");
                } else
                {
                    ShowMessage("无法通过！");
                }
               /* // 获取lineMembers中是否存在此线路
                bool IsExistsLine = ApplicationSettingManager.SelectMembersIsExists(lineID, showOrLong);
                if (IsExistsLine)
                {
                    // 是否插入成员表成功
                    bool IsSuccess = ApplicationSettingManager.InsertMember(lineID, showOrLong, userID);
                    if (IsSuccess)
                    {
                        // 更改申请表中申请状态
                        bool result = ApplicationSettingManager.UpdateApplicationStatus(lineID, userID, showOrLong, status);
                        if (result)
                        {
                            // 申请线路通过之后更改已通过人数
                            bool IsParticipants = ApplicationSettingManager.UpdateLineInfoParticipants(lineID, showOrLong);
                            if(IsParticipants)
                            {
                                ShowMessage("您已通过他的申请");
                            }
                        }
                    }
                    else
                    {
                        ShowMessage("无法通过！");
                    }
                }
                else
                {
                    // 如果该线路已经有人申请过，则更改添加线路成员
                    bool IsSuccess = ApplicationSettingManager.UpdateMembers(lineID, showOrLong, userID);
                    if (IsSuccess)
                    {
                        // 更改申请表中申请状态
                        bool result = ApplicationSettingManager.UpdateApplicationStatus(lineID, userID, showOrLong, status);
                        if (result)
                        {
                            // 申请线路通过之后更改已通过人数
                            bool IsParticipants = ApplicationSettingManager.UpdateLineInfoParticipants(lineID, showOrLong);
                            if (IsParticipants)
                            {
                                ShowMessage("您已通过他的申请");
                            }
                        }
                    }
                    else
                    {
                        ShowMessage("无法通过！");
                    }
                }*/
            }
        }
    }
}