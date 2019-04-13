<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginValidation.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder2" runat="server">


     <div>
            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
            <asp:TextBox ID="tbusername" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="tbpassword" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
            <br />
&nbsp;<asp:Button ID="loginBtn" runat="server" OnClick="loginBtn_Click" Text="Login" />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Registration.aspx">Create a new account</asp:LinkButton>
        </div>

</asp:Content>
