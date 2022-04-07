<%@ Page Title="" Language="C#" MasterPageFile="~/page.Master" AutoEventWireup="true" CodeBehind="ShortDistance.aspx.cs" Inherits="DIDA_UI.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/release.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
            <div class="banner">
                <div id="allmap">
                    <!--百度地图API  -->
                </div>
            </div>
           <nav class="nav">
                <div class="nav-container">
                    <a href="./Index.aspx" class="carpool long-distance">长途拼车</a>
                    <a href="./ShortDistance.aspx" class="carpool short-distance">上下班拼车</a>
                    <a href="./UserData.aspx" class="carpool follow">拼车关注</a>
                    <a href="#" class="carpool release-long-distance">发布上下班拼车</a>

                    <span class="tips-info">嘀嗒拼车将永远为您服务！</span>
                </div>
            </nav>
            <div class="search">
                <div class="search-container">
                    <div class="open-city">
                        <label for="open_city_input">出发地址:</label>
                        <input runat="server" class="city-input  open-city-input" id="open_city_input" />
                    </div>
                    <div class="close-city">
                        <label for="close_city_input">目的地址:</label>
                        <input runat="server" class="city-input  close-city-input" type="text" id="close_city_input" />
                    </div>
                    <a  onserverclick="Btn_Line_Search_Click" runat="server" class="search-line">查询线路</a>
                    <a class="search-line  search-city" id="" > 查询地图线路</a>
                </div>
            </div>
            <div class="info-list">
                <div class="info-list-container">
                    <ul class="capation">
                        <li>编号</li>
                        <li>拼车线路</li>
                        <li>出发时间</li>
                        <li>单程费用</li>
                        <li>操作</li>
                    </ul>
                    <asp:Repeater ID="ShowInfo_Repeater" runat="server">
                        <ItemTemplate>
                            <ul class="content">
                                <li><%# Eval("ID") %></li>
                                <li><%# Eval("OpenCity") %> --> <%# Eval("CloseCity") %></li>
                                <li><%# Eval("DepartureTime","{0:yyyy-MM-dd-ss}") %></li>
                                <li>￥<%# Eval("Price") %></li>
                                <li>
                                    <a href='LineDetail.aspx?id=<%# Eval("ID").ToString()%>&type=show' class="invitation">
                                        <%# int.Parse(Eval("UserTypeId").ToString())==1?"申请加入":"邀请加入" %>
                                    </a>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>


            <div class="release-container">
                <div class="release-content">
                    <div class="top">
                        <h2 class="release-title">发布上下班拼车拼车</h2>
                        <i class="close">
                            <img src="./image/close.png" alt="" />
                        </i>
                    </div>
                    <div class="tab-container">
                        <div class="tab-passenger menu-content" id="Passenger">
                            <div class="form-group-top">
                                <div class="form-group">
                                    <label class="form-label-control" for="showOpenCity">出发地址:</label>
                                    <input class="form-input" type="text" name="showOpenCity" id="showOpenCity" runat="server" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="showCloseCity">目的地址:</label>
                                    <input class="form-input" type="text" id="showCloseCity" name="showCloseCity" runat="server" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="showOpenTime">出发时间:</label>
                                    <input class="form-input" type="date" id="showOpenTime" runat="server" name="showOpenTime" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="showReleaseCount">容纳人数:</label>
                                    <input class="form-input" type="text" id="showReleaseCount" runat="server" name="showReleaseCount" />
                                </div>

                                <div class="form-group">
                                    <label class="form-label-control" for="showCarType">汽车类型:</label>
                                    <asp:DropDownList class="form-input" ID="showCarType" runat="server"></asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label class="form-label-control" for="showPriceText">
                                        每人单程费用：
                                    </label>
                                    <input class="form-input" id="showPriceText" runat="server" type="text">
                                    元 / 位
                                </div>
                            </div>
                            
                            <div class="form-label-control form-label-Msg">
                                <span>补充说明：</span>
                                <textarea class="form-Msg" runat="server" name="showMsg" id="showMsg"></textarea>
                            </div>

                            <button runat="server" onserverclick="ShowOwner_ServerClick" class="show-owner-btn submit-btn" id="showOwner">立即发布</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <script src="./js/index.js"></script>
</asp:Content>
