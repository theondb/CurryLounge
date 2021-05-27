<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadCheckout.aspx.cs" Inherits="CurryLounge.Checkout.ReadCheckout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Checkout Order</h1>
    <br />
    <h3 style="">Your Order:</h3>
    <asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="10" Width="500" BorderColor="#efeeef" BorderWidth="5">              
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText=" Product ID" />        
            <asp:BoundField DataField="Product.ProductName" HeaderText=" Product Name" />        
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (per)" DataFormatString="{0:c}"/>     
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />        
        </Columns>    
    </asp:GridView>
    <asp:DetailsView ID="DeliveryInfo" runat="server" AutoGenerateRows="False" GridLines="None" CellPadding="10" BorderStyle="None" CommandRowStyle-BorderStyle="None">
        <Fields>
            <asp:TemplateField>
                <ItemTemplate>
                    <h3>Order Total:</h3>
                    <asp:Label ID="Total" runat="server" Text='<%#: Eval("Total", "{0:C}") %>'></asp:Label>
                     <p></p>
                    <h3>Delivery Address:</h3>
                    <asp:Label ID="Firstname" runat="server" Text='<%#: Eval("Firstname") %>'></asp:Label>  
                    <asp:Label ID="Surname" runat="server" Text='<%#: Eval("Surname") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Address" runat="server" Text='<%#: Eval("Address") %>'></asp:Label>
                    <br />
                    <asp:Label ID="City" runat="server" Text='<%#: Eval("City") %>'></asp:Label>
                    <asp:Label ID="Postcode" runat="server" Text='<%#: Eval("Postcode") %>'></asp:Label>
                </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
      </Fields>
    </asp:DetailsView>
    <p></p>
    <hr />
    <asp:Button ID="CheckoutConfirm" runat="server" Text="Complete Order" OnClick="CheckoutConfirm_Click" BackColor="Orange" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" CssClass="btn" Height="36px" Width="157px" />
</asp:Content>
