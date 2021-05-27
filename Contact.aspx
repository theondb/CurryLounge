<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CurryLounge.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> Page</h2>
    <address>
        Sunnyhill Lane<br />
        Huddersfield, HD1 CL1<br />
        <abbr title="Phone">P:</abbr>
        012345 678901
    </address>

    <address>
        <strong>Email:</strong>   <a href="currylounge-merchant@email.com">currylounge-merchant@email.com</a><br />
    </address>
</asp:Content>
