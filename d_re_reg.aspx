﻿<%@ Page Title="" Language="C#" MasterPageFile="~/depthead.master" AutoEventWireup="true" CodeFile="d_re_reg.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:DropDownList ID="Year" runat="server" AutoPostBack="True" Height="40px" OnTextChanged="Year_TextChanged">
        <asp:ListItem>Select Year</asp:ListItem>
        <asp:ListItem Value="2018">1st Year</asp:ListItem>
        <asp:ListItem Value="2017">2nd Year</asp:ListItem>
        <asp:ListItem Value="2016">3rd Year</asp:ListItem>
        <asp:ListItem Value="2015">4th Year</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:CheckBoxList ID="CheckBoxList2" runat="server">
    </asp:CheckBoxList>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Button ID="verify" runat="server" Text="Verify" Class="login100-form-btn" OnClick="verify_Click" />
    <br />
    <asp:Repeater ID="Repeater1" runat="server">
    </asp:Repeater>
</div>
</asp:Content>

