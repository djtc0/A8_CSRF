<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="simpleASPNetCSRF.shop" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Shop</title>
</head>
<body>
    <form id="form1" runat="server" method="get">
        <%--<asp:HiddenField ID="__HiddenField1ForgeryToken" runat="server" /><input type="submit" />--%>
        <asp:panel id="shopList" runat="server">

        </asp:panel>
        <div style="margin-top: 10px">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>

</body>
</html>
