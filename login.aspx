<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="bcms.css.WebForm1" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="css/login.css">
    <title>BlueLadder Construction Management System</title>

</head>

<body>
    <form id="form1" runat="server">
    <div id="container">
        <div class="main" id="left">
            <div id="login">
                <h1 id="loginText">LOGIN</h1>
                <div id="userName">
                    <h2 class="inputText">USERNAME</h2>
                    <input type="text">
                </div>
                <div id="passCode">
                    <h2 class="inputText">PASSCODE</h2>
                    <input type="password">
                </div>
                <div id="divBtn">
                    <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="LOGIN" Width="232px" />
                </div>
            </div>
        </div>
        <div class="main jumbotron" id="right">

            <p id="bTitle">
                BlueLadder
                <br>
                Construction
                <br>
                Management<br>
                System<br>
            </p>
            <p id="mTitle">BlueLadder Construction Management System</p>

        </div>
    </div>
    </form>
</body>
</html>
