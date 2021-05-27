<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="CurryLounge.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:FormView ID="productDetail" runat="server" ItemType="CurryLounge.Models.Product" SelectMethod ="GetProducts" RenderOuterTable="false">
        <ItemTemplate>
<%--            <div>
                <h1><%#:Item.ProductName %></h1>
            </div>
            <br />--%>
            <table>
                <tr>
                    <td>
                        <img src="/Assets/<%#:Item.ImagePath %>" style="border:solid; border-color:black; height:300px" alt="<%#:Item.ProductName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <h1><%#:Item.ProductName %></h1>
                        <b>Description:</b><br /><%#:Item.Description %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span>
                        <br />
                        <a href="/AddToBasket.aspx?productID=<%#:Item.ProductID %>">               
                            <span class="ProductListItem">
                                <b>Add Order<b>
                            </span>           
                        </a>    
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
