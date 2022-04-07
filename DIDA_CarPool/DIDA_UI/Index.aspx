<%@ Page Title="" Language="C#" MasterPageFile="~/page.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DIDA_UI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./css/release.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <a href="#" class="carpool release-long-distance" id="Release_Long_CarPool" runat="server">发布长途拼车</a>

                    <span class="tips-info">嘀嗒拼车将永远为您服务！</span>
                </div>
            </nav>
            <div class="search">
                <div class="search-container">
                    <div class="open-city">
                        <label class="form-label-control" for="open-city-input">出发城市:</label>
                        <input class="city-input open-city-input" id="open_city_input" runat="server"/>
                    </div>
                    <div class="close-city">
                        <label class="form-label-control" for="close-city-input">目的城市:</label>
                        <input class="city-input close-city-input" type="text" id="close_city_input" runat="server"/>
                    </div>

                    <a class="search-line" id="Btn_Line_Search" runat="server" onserverclick="Btn_Line_Search_Click"> 查询线路</a>
                    <a class="search-line  search-city" id="A1" > 查询地图线路</a>
                    <div class="release-time">
                        <label class="form-label-control" for="release-time-input"></label>
                        <input type="date" class="city-input" runat="server" id="release_time_input" />
                    </div>

                    <a class="search-datetime" runat="server" onserverclick="Btn_Line_Search_Click">
                        <img src="./image/search.png" alt="" />
                    </a>
                </div>
            </div>
            <div class="info-list">
                <div class="info-list-container">
                    <asp:Repeater ID="LongInfo_Repeater" runat="server">
                        <HeaderTemplate>
                            <ul class="capation">
                                <li>类型</li>
                                <li>出发日期</li>
                                <li>费用</li>
                                <li>车型</li>
                                <li>出发城市</li>
                                <li>目的城市</li>
                                <li>操作</li>
                            </ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <ul class="content">
                                <li>
                                    <%# Eval("UserTypeID").ToString() == "1" ? "<img src='./image/ico_type_car.gif' alt='' />" : "<img src='./image/ico_type_person.gif' alt='' />" %>
                                </li>
                                <li>
                                    <%# Eval("DepartureTime","{0:yyyy-MM-dd}") %>
                                </li>
                                <li>
                                    ￥<%# Eval("Price") %>
                                </li>
                                <li>
                                    <%# Eval("CarID") %>
                                </li>
                                <li>
                                    <%# Eval("OpenCity") %>
                                </li>
                                <li>
                                    <%# Eval("CloseCity") %>
                                </li>
                                <li>
                                    <a href='LineDetail.aspx?id=<%# Eval("ID").ToString()%>&type=long' class="invitation">
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
                        <h2 class="release-title">发布长途拼车</h2>
                        <i class="close">
                            <img src="./image/close.png" alt="" />
                        </i>
                    </div>
                    <dl class="tab-list">
                        <dd class="menu-list active">
                            <a href="#CarOwner">我是车主</a>
                        </dd>
                    </dl>
                    <div class="tab-container">
                        <div id="CarOwner" class="menu-content tab-carOwner">
                            <div class="form-group-top">
                                <div class="form-group">
                                    <label class="form-label-control" for="ownerOpenCity">出发城市:</label>
                                    <input class="form-input" type="text" runat="server" name="openCity" id="ownerOpenCity" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="ownerCloseCity">目的城市:</label>
                                    <input class="form-input" type="text" runat="server" id="ownerCloseCity" name="ownerCloseCity" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="ownerOpenTime">出发时间:</label>
                                    <input class="form-input" type="date" runat="server" id="ownerOpenTime" name="openTime" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="ownerReleaseCount">已报名人数:</label>
                                    <input class="form-input" type="text" runat="server" id="ownerReleaseCount" name="ownerReleaseCount" />
                                </div>

                                <div class="form-group">
                                    <label class="form-label-control" for="ownerholdCount">容纳人数:</label>
                                    <input class="form-input" type="text" runat="server" id="ownerholdCount" name="ownerholdCount" />
                                </div>
    
                                <div class="form-group">
                                    <label class="form-label-control" for="ownerCarType">汽车类型:</label>
                                    <asp:DropDownList class="form-input" ID="ownerCarType" runat="server"></asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label class="form-label-control">
                                        费用方式
                                    </label>
                                    <input class="form-input" id="ownerFacePrice" runat="server" type="radio" checked value="面议" name="price">面议
                                    <input class="form-input" id="ownerDecisionPrice" runat="server" type="radio" value="一口价" name="price">
                                    <input class="form-input" id="ownerPriceText" runat="server" type="text">
                                    元 / 位
                                </div>
                            </div>

                            
                            <div class="form-label-control form-label-Msg">
                                <span>车主留言：</span>
                                <textarea class="form-Msg" runat="server" name="ownerMsg" id="ownerMsg"></textarea>
                            </div>

                            <button class="long-owner-btn  submit-btn" runat="server" onserverclick="LongOwner_ServerClick" id="LongOwner">立即发布</button>
                        </div>
                    </div>
                </div>
            </div>


    <div class="popup-arr">
        <asp:Repeater ID="Popup_Repeater1" runat="server" OnItemCommand="Popup_ItemCommand">
           <ItemTemplate>
                <div class="popup">
                    <p>用户 <mark><%# Eval("UserName") %></mark> 申请加入你发布的 <mark><%# Eval("OpenCity") %></mark> 到 <mark><%# Eval("CloseCity") %></mark> 的编号为<mark><%# Eval("LineID") %></mark><%# Eval("ShowOrLong").ToString() == "0" ? "长途" : "短途" %>线路，请通过！</p>
                     <asp:LinkButton Text="拒绝" runat="server" CssClass="btn" CommandName='fail' CommandArgument='<%# Eval("LineID")+","+Eval("UserID") + "," + Eval("ShowOrLong")  %>' id="RefuseLine" />

                    <asp:LinkButton Text="通过" runat="server" CssClass="btn" CommandName='adopt' CommandArgument='<%# Eval("LineID")+","+Eval("UserID") + "," + Eval("ShowOrLong")  %>' id="PassLine" />
                
                    <div class="close">
                        <img src="./image/close.png" alt="Alternate Text" />
                    </div>
                </div>
           </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="Popup_Repeater2" runat="server" OnItemCommand="Popup1_ItemCommand">
           <ItemTemplate>
                <div class="popup">
                    <p>你申请加入的 <mark><%# Eval("OpenCity") %></mark> 到 <mark><%# Eval("CloseCity") %></mark> 的编号为<mark><%# Eval("LineID") %></mark><%# Eval("ShowOrLong").ToString() == "0" ? "长途" : "短途" %>线路，被用户ID为<mark><%# Eval("发布用户") %></mark><%# Eval("Status").ToString() == "0" ? "拒绝了" : "同意了" %></p>
                
                    <asp:LinkButton Text="确定" runat="server" CssClass="btn" CommandName='determine' CommandArgument='<%# Eval("LineID")+","+Eval("UserID")+","+Eval("Status") +"," + Eval("ShowOrLong")  %>' id="PassLine" />
                
                    <div class="close">
                        <img src="./image/close.png" alt="Alternate Text" />
                    </div>
                </div>
           </ItemTemplate>
        </asp:Repeater>
    </div>

    

    <script src="./scripts/popup.js"></script>
</asp:Content>


