<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="PresentationTier.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ListBox ID="ListBox1" runat="server" Height="134px" Width="166px"></asp:ListBox>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Find" />
        </p>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="VideoInfoButton" runat="server" OnClick="VideoInfoButton_Click" Text="GetVidInfo" />
        <asp:Label ID="Label1" runat="server" Text="VidTitle:"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="HopefullyWorks"></asp:Label>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
