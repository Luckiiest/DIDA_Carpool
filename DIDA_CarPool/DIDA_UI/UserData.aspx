<%@ Page Title="" Language="C#" MasterPageFile="~/page.Master" AutoEventWireup="true" CodeBehind="UserData.aspx.cs" Inherits="DIDA_UI.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/userData.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <nav class="nav">
            <div class="nav-container">
                <a href="./Index.aspx" class="carpool long-distance">长途拼车</a>
                <a href="./ShortDistance.aspx" class="carpool short-distance">上下班拼车</a>
                <a href="./UserData.aspx" class="carpool follow">拼车关注</a>

                <span class="tips-info">请您放心查看您的个人数据！</span>
            </div>
        </nav>

        <div class="content">
            <div class="to-left">
                <div class="user-center">
                    <i class="user-center-image">
                        <img src="./image/user-center.png" alt="">
                    </i>
                    <span>用户中心</span>
                </div>
                <dl class="right-menu">
                    <dt class="menu-title">长途拼车</dt>
                    <dd class="menu-list"> <a href="#Long"> 发布的长途拼车</a></dd>
                    <dd class="menu-list"> <a href="#ApplyLong"> 申请加入的长途拼车</a></dd>
                </dl>
                <dl class="right-menu">
                    <dt class="menu-title">短途拼车</dt>
                    <dd class="menu-list"> <a href="#Show"> 发布的上下班拼车</a></dd>
                    <dd class="menu-list"> <a href="#ApplyShow"> 申请加入的上下班拼车</a></dd>
                </dl>
            </div>
            <div class="content-info">
                <ul class="capation">
                    <li>编号</li>
                    <li>出发城市</li>
                    <li>目的城市</li>
                    <li>出发日期</li>
                    <li>费用</li>
                    <li>车型</li>
                    <li>加入 / 容纳</li>
                    <li>状态</li>
                    <li>操作</li>
                </ul>
                <div class="menu-content" id="Long">
                    <asp:Repeater ID="LongData_Repeater" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><%# Eval("ID") %></li>
                                <li><%# Eval("OpenCity") %></li>
                                <li><%# Eval("CloseCity") %></li>
                                <li><%# Eval("DepartureTime", "{0:yyyy-MM-dd}") %></li>
                                <li><%# Eval("Price") %></li>
                                <li><%# Eval("CarID") %></li>
                                <li><%# Eval("NumberParticipants") %> / <%# Eval("HoldNumberPeople") %></li>
                                <li><%# DateTime.Parse(Eval("DepartureTime").ToString()) < DateTime.Now.AddDays(-1) ? "关闭" : "有效" %></li>
                                <li> 
                                    <a href='LineDetail.aspx?id=<%# Eval("ID").ToString()%>&type=long' class="invitation">
                                        查看
                                    </a>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="menu-content" id="ApplyLong">
                    <asp:Repeater ID="LongApply_Repeater" runat="server">
                         <ItemTemplate>
                             <ul>
                                <li><%# Eval("ID") %></li>
                                <li><%# Eval("OpenCity") %></li>
                                <li><%# Eval("CloseCity") %></li>
                                <li><%# Eval("DepartureTime", "{0:yyyy-MM-dd}") %></li>
                                <li><%# Eval("Price") %></li>
                                <li><%# Eval("CarName") %></li>
                                <li><%# Eval("NumberParticipants") %> / <%# Eval("HoldNumberPeople") %></li>
                                <li><%# DateTime.Parse(Eval("DepartureTime").ToString()) < DateTime.Now.AddDays(-1) ? "关闭" : "有效" %> <%# GetUserPhoto(Eval("Status").ToString()) %></li>
                                <li> 
                                    <a href='LineDetail.aspx?id=<%# Eval("ID").ToString()%>&type=long' class="invitation">
                                        查看
                                    </a>
                                </li>
                            </ul>
                         </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="menu-content" id="Show">
                    <asp:Repeater ID="ShowData_Repeater" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><%# Eval("ID") %></li>
                                <li><%# Eval("OpenCity") %></li>
                                <li><%# Eval("CloseCity") %></li>
                                <li><%# Eval("DepartureTime", "{0:yyyy-MM-dd}") %></li>
                                <li><%# Eval("Price") %></li>
                                <li><%# Eval("CarID") %></li>
                                <li><%# Eval("NumberParticipants") %> / <%# Eval("HoldNumberPeople") %></li>
                                <li><%# DateTime.Parse(Eval("DepartureTime").ToString()) < DateTime.Now.AddDays(-1) ? "关闭" : "有效" %> </li>
                                <li> 
                                    <a href='LineDetail.aspx?id=<%# Eval("ID").ToString()%>&type=show' class="invitation">
                                        查看
                                    </a>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="menu-content" id="ApplyShow">
                    <asp:Repeater ID="ShowApply_Repeater" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><%# Eval("ID") %></li>
                                <li><%# Eval("OpenCity") %></li>
                                <li><%# Eval("CloseCity") %></li>
                                <li><%# Eval("DepartureTime", "{0:yyyy-MM-dd}") %></li>
                                <li><%# Eval("Price") %></li>
                                <li><%# Eval("CarName") %></li>
                                <li><%# Eval("NumberParticipants") %> / <%# Eval("HoldNumberPeople") %></li>
                                <li><%# DateTime.Parse(Eval("DepartureTime").ToString()) < DateTime.Now.AddDays(-1) ? "关闭" : "有效" %> <%# GetUserPhoto(Eval("Status").ToString()) %></li>
                                <li> 
                                    <a href='LineDetail.aspx?id=<%# Eval("ID").ToString()%>&type=show' class="invitation">
                                        查看
                                    </a>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div> 

</asp:Content>
