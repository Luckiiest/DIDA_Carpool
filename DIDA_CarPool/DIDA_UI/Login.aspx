<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DIDA_UI.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户登陆</title>
    <link rel="stylesheet" href="./css/login-register.css" />
    <link rel="stylesheet" href="./css/reset.css" />
</head>
<body>
   <form action="#" runat="server">
            <div class="container">
                <div class="login-register">
                    <div class="btn-group">
                        <a href="#" class="active">登陆</a>
                        <a href="./Register.aspx">注册</a>
                    </div>
                </div>
                <div class="title">
                    <h2>欢迎登陆</h2>
                </div>
                <div class="form-group">
                    <label class="form-label-control" for="phone_txt">用户名/电话号码:</label>
                    <div class="input-group">
                        <input id="phone_txt" type="text" class="form-control" runat="server" placeholder="请输入用户名或电话" value="" />
                    </div>

                    <asp:RequiredFieldValidator ID="revUserName" runat="server" ForeColor="Red" ControlToValidate="phone_txt" ErrorMessage="请输入用户名或电话"></asp:RequiredFieldValidator>
                    
                    <br />

                    <label class="form-label-control" for="pwd">密码:</label>
                    <div class="input-group">
                        <input id="pwd_txt" type="password" class="form-control" runat="server" placeholder="请输入密码" value="" />
                    </div>
                    
                    <asp:RegularExpressionValidator ID="revPwd" runat="server" 
                 ControlToValidate="pwd_txt" ErrorMessage="密码至少包含 数字和英文，长度6-20" ForeColor="Red"
            ValidationExpression="^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,20}$"></asp:RegularExpressionValidator>

                    <br />
                </div>
                
                
                <button id="Login_Btn" class="login-btn" runat="server" onserverclick="Login_Btn_Click">登陆</button>
                <div class="back-home">
                    <span>欢迎光临嘀嗒拼车</span>
                    <a href="./Index.aspx" class="home">首页</a>
                </div>
            </div>
        </form>

</body>
</html>
