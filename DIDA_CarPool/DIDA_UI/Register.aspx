<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DIDA_UI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
    <link rel="stylesheet" href="./css/login-register.css" />
    <link rel="stylesheet" href="./css/reset.css" />
</head>
<body>
   <form runat="server">
            <div class="container">
                <div class="login-register">
                    <div class="btn-group">
                        <a href="./Login.aspx">登陆</a>
                        <a class="active" href="#">注册</a>
                    </div>
                </div>
                <div class="title">
                    <h2>创建一个账户</h2>
                </div>
                <div class="form-group">
                    <label class="form-label-control" for="phone">电话号码:</label>
                    <div class="input-group">
                        <input class="form-control" runat="server" id="phone_txt" name="Phone" placeholder="电话号码" />
                    </div>
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                 ControlToValidate="phone_txt" ErrorMessage="请填写正确的电话号码" ForeColor="Red"
            ValidationExpression="^1[3|4|5|7|8]\d{9}$"></asp:RegularExpressionValidator>

                    <br />

                    <label class="form-label-control" for="pwd">密码:</label>
                    <div class="input-group">
                        <input class="form-control" type="password" runat="server" id="pwd_txt" placeholder="密码" name="Password" />
                    </div>


                    <asp:RegularExpressionValidator ID="revPwd" runat="server" 
                 ControlToValidate="pwd_txt" ErrorMessage="密码至少包含 数字和英文，长度6-20" ForeColor="Red"
            ValidationExpression="^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,20}$"></asp:RegularExpressionValidator>

                    <br />

                    <label class="form-label-control" for="pwd">确认密码:</label>
                    <div class="input-group">
                         <input class="form-control" runat="server" type="password" id="RepeatPwd" placeholder="确认密码" name="Password" />
                    </div>

                    <asp:CompareValidator ID="revPwdCompare" runat="server" Operator="Equal" Type="String" ControlToCompare="pwd_txt" ControlToValidate="RepeatPwd"  ForeColor="Red" ErrorMessage="输入密码不一致"></asp:CompareValidator>

                    <br />

                    <label class="form-label-control" for="pwd">用户名:</label>
                    <div class="input-group">
                        <input class="form-control" runat="server" type="text" id="UserName" placeholder="昵称" name="UserName" />
                    </div>

                    <asp:RegularExpressionValidator ID="revUserNameRegExp" runat="server" 
                 ControlToValidate="UserName" ErrorMessage="用户名为4到16位（字母，数字，下划线，减号）" ForeColor="Red"
            ValidationExpression="^[a-zA-Z0-9_-]{4,16}$"></asp:RegularExpressionValidator>

                    <asp:RequiredFieldValidator ID="revUserName" runat="server" ForeColor="Red" ControlToValidate="UserName" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>

                </div>
                
                <button runat="server" onserverclick="Register_Btn_Click" id="Register_Btn" class="login-btn">注册</button>
                <div class="back-home">
                    <span>欢迎光临嘀嗒拼车</span>
                    <a href="./Index.aspx" class="home">首页</a>
                </div>
            </div>
        </form>
</body>
</html>
