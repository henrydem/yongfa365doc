<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepeaterInRepeater.aspx.cs" Inherits="Asp.net.Demo.RepeaterInRepeater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="repOut" OnItemDataBound="repOut_ItemDataBound">
        <ItemTemplate>
            <div>
                <strong><%#Eval("Key") %></strong>
                <asp:Repeater runat="server" ID="repIn">
                    <ItemTemplate>
                        <%#Eval("FacilityName")%>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
