<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UI.aspx.cs" Inherits="bcms.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%Response.WriteFile("<p>HelloWorld</p>"); %>
        </div>
    </form>
</body>
</html>
