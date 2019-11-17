<%@ Page Title="" Language="C#" MasterPageFile="~/depthead.master" AutoEventWireup="true" CodeFile="d_uploadmarks.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


      * {
    box-sizing: border-box;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <br /><br /> <div id="block" style="margin-left:20px; width:80%">
   
         <asp:DropDownList ID="Year" runat="server" Height="40px" AutoPostBack="True">
                <asp:ListItem>Select Year</asp:ListItem>
                <asp:ListItem Value="2018">1st Year</asp:ListItem>
                <asp:ListItem Value="2017">2nd Year</asp:ListItem>
                <asp:ListItem Value="2016">3rd Year</asp:ListItem>
                <asp:ListItem Value="2015">4th Year</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:FileUpload ID="FileUpload1" runat="server" OnDataBinding="FileUpload1_DataBinding" />
    <asp:Button ID="fileuploadbtn" runat="server" Text="Upload" Class="login100-form-btn" OnClick="fileuploadbtn_Click" />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="the excel sheet must be in proper Pre define Stucture Click here to Get Strcture"></asp:Label>
</div>

</asp:Content>

