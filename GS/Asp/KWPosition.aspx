﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KWPosition.aspx.cs" Inherits="Asp.KWPosition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Check position of your website by a specified Keyword.</h2>
<p>    
    Position will be checked in Google, Bing and Yahoo for the first 1000 results
</p>
<br />
    <asp:Label ID="Label1" runat="server" Text="Keyword:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Website:"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
    <asp:Button ID="btnGo" runat="server" Text="Go!" Width="100px" 
        onclick="btnGo_Click" />
<br />
<br />
    <asp:Panel ID="pnlResult" runat="server">
        <asp:DataList ID="dtlResults" runat="server" HorizontalAlign="Center">
        </asp:DataList>
    </asp:Panel>

</asp:Content>
