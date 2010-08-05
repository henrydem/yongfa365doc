<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server">
        </asp:DataList>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Repeater ID="Repeater1" runat="server">
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
