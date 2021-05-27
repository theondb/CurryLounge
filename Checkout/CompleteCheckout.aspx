<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompleteCheckout.aspx.cs" Inherits="CurryLounge.Checkout.CompleteCheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Checkout Complete</h1>
    <p></p>
    <h3>Transaction ID:</h3> <asp:Label ID="TransactionId" runat="server"></asp:Label>
    <p></p>
    <h3>Thank You!</h3>
    <p>Your meal will be coming to yuor address shortly.</p>
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continue Shopping" OnClick="Continue_Click" BackColor="Orange" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="btn" Height="38px" Width="200px" />
</asp:Content>
