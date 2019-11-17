<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="D_internalmarks.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:DropDownList ID="Year" runat="server" Height="40px" AutoPostBack="True" OnSelectedIndexChanged="Year_SelectedIndexChanged" >
                <asp:ListItem>Select Year</asp:ListItem>
                <asp:ListItem Value="2018">1st Year</asp:ListItem>
                <asp:ListItem Value="2017">2nd Year</asp:ListItem>
                <asp:ListItem Value="2016">3rd Year</asp:ListItem>
                <asp:ListItem Value="2015">4th Year</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="students" runat="server">
    </asp:DropDownList>
          <asp:Button ID="get_result" runat="server" Text="Get Result"  Class="login100-form-btn" OnClick="get_result_Click" />
</asp:Content>

