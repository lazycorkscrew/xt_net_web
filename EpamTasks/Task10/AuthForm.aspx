<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthForm.aspx.cs" Inherits="Task10.AuthForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Логин: <div>
            <asp:TextBox ID="textBoxLogin" runat="server"></asp:TextBox>
        </div>
        Пароль: <div>
            <asp:TextBox ID="textBoxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
        </form>
</body>
</html>
