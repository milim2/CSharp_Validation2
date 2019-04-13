<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="LoginValidation.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder2" runat="server">

     <div>
            <asp:Label ID="Label1" runat="server" Text="User Name "></asp:Label>
            <asp:TextBox ID="tbusername" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="tbpassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="User Type"></asp:Label>
        <asp:TextBox ID="tbusertype" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btregister" runat="server" OnClick="btregister_Click" Text="Register" />
&nbsp;&nbsp;
        <asp:Button ID="btcancel" runat="server" OnClick="btcancel_Click" Text="Cancel" />

</asp:Content>
