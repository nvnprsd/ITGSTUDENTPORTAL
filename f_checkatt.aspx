<%@ Page Title="" Language="C#" MasterPageFile="~/faculty.master" AutoEventWireup="true" CodeFile="f_checkatt.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="block" style="margin-left:20px; margin-top:30px; width:80%">
    <asp:ScriptManager  id="s1" runat="server" ></asp:ScriptManager>
         <asp:Label ID="Cstatus" runat="server"></asp:Label>
         <asp:Label ID="at" runat="server" Visible="false"></asp:Label>
        <br />
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                        <br />
                       <strong>Present Student</strong>
                     <asp:CheckBoxList ID="pr" runat="server" OnLoad="pr_Load">
                    </asp:CheckBoxList>
                        <asp:Timer ID="Timer1" runat="server" Interval="9000" OnTick="Timer1_Tick">
                        </asp:Timer>
                    <br />
                    <strong>Absent Student</strong>
                    <asp:CheckBoxList ID="ab" runat="server" TextAlign="Left">
                    </asp:CheckBoxList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
           <div class="container-login100-form-btn m-b-40" >
			 <asp:Button ID="checkatt" runat="server" Text="Submit Strength" OnClick="checkatt_Click" class="login100-form-btn"/></div>
            <div class="container-login100-form-btn m-b-40" >
			<asp:Button ID="abort" runat="server" Text="Abort Class" OnClick="abort_Click" class="login100-form-btn"/></div>
            <br />
        </div>
         </div>
</asp:Content>

