<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="LineDetail.aspx.cs" Inherits="DIDA_UI.LineDetail" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/lineDetail.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="LongInfoDetail_Repeater" OnItemCommand="LongInfoDetail_Repeater_ItemCommand">
        <ItemTemplate>
            <div class="line-detail">
                <div class="detail-content">
                    <div class="top">
                        <a class="back" href="#">
                            <image src="./image/back.png"></image>
                        </a>
                        <h2 class="release-title">线路信息</h2>
                    </div>

                    <div class="detail-container">
                        <div class="status">
                            <h3 class="status-title">信息状态:</h3>
                            <div class="status-info">出发城市：
                                <span class="open-city"><%# Eval("OpenCity") %></span> 
                                ·······························&gt;
                                <span class="close-city"><%# Eval("CloseCity") %></span>
                            </div>
                            <div class="status-info">出发时间：<span>
                                <%# Eval("DepartureTime") %>
                            </span></div>
                        </div>
                        <div class="detail-info">
                            <div class="info-content">
                                <div>可容纳人数：
                                    <span><%# Eval("HoldNumberPeople") %></span>
                                </div>
                                <div>
                                    已报名人数：
                                    <span><%# Eval("NumberParticipants") %></span>
                                </div>
                                <div>
                                    已有
                                    <span class="red">
                                        <%# Eval("NumberApplicants") %>
                                    </span>
                                    人申请
                                </div>
                                <div>
                                    汽车类型：
                                    <span><%# Eval("CarID") %></span>
                                </div>
                                <div>
                                    费用方式：
                                    <span>￥<%# Eval("Price") %></span>
                                </div>
                            </div>
                            <div class="info-msg">
                                留言：
                                <p class="msg">
                                    <%# Eval("Message") %>
                                </p>
                            </div>
                            <div class="btn-request">
                                <button class="detail-btn" id="addRelease" runat="server" onserverclick="addRelease_ServerClick">
                                    <%# int.Parse(Eval("UserTypeId").ToString())==1?"申请加入":"邀请加入" %>
                                </button>
                                <asp:LinkButton class="detail-btn" id="requestPhone" runat="server" onserverclick="requestPhone_ServerClick" CommandName="requestPhone_Command" CommandArgument='<%# Eval("Phone") %>'>获取车主联系方式</asp:LinkButton>
                            <div class="release-info">
                                <div>
                                    发布用户：
                                    <span> <%# Eval("UserName") %> <%# int.Parse(Eval("UserTypeID").ToString())==1 ? "师傅" :"用户" %></span>
                                </div>
                                <div>
                                    拼车编号：
                                    <span> <%# Eval("ID") %></span>
                                </div>
                                <div>
                                    发布时间：
                                    <span> <%# Eval("ReleaseTime") %></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
