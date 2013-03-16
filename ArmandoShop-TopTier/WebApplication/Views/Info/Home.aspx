<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArmandoShop.WebApplication.Models.Model.StaticsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Armando Shop - Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Welcome to Armando 's Shop</h2>
    <asp:Panel CssClass="InfoPanel" runat="server" BorderStyle="Inset" BorderWidth="2"
        Font-Bold="true" Width="45%" Height="300">
        <h3>
            Advices for my shop</h3>
        <ul>
            <li>Select your prefer category among several categories.. </li>
            <li>Explore products of your favour category </li>
            <li>Register without financial information </li>
            <li>Add your produccts to the cart </li>
            <li>Finish your transaction against your own bank</li>
        </ul>
        <h3>
            New functionalities</h3>
        <ul>
            <li>Customers Enrichment Client (Not yet)</li>
        </ul>
    </asp:Panel>
    <asp:Panel ID="StaticsPanel" CssClass="Statics" runat="server" BorderStyle="Inset"
        Font-Bold="true" BorderWidth="2" Width="40%" Height="300" Wrap="true">
        <% var item = Model; %>
        <h3>
            Enjoy buying on my shop !!!</h3>
        <ul>
            <li>
                <%: Html.LabelFor(m => m.CustomersNumber)%>
                <%: Html.DisplayFor(m => m.ProductsNumber) %>
            </li>
            <li>
                <%: Html.LabelFor(m => m.CategoriesNumber)%>
                <%: Html.DisplayFor(m => m.CategoriesNumber)%></li>
            <li>
                <%: Html.LabelFor(m => m.OrdersNumber) %>
                <%: Html.DisplayFor(m => m.OrdersNumber)%></li>
            <li>
                <%: Html.LabelFor(m => m.ContractsNumber)%>
                <%: Html.DisplayFor(m => m.ContractsNumber)%></li>
            <li>
                <%: Html.LabelFor(m => m.ProductsNumber)%>
                <%: Html.DisplayFor(m => m.ProductsNumber)%></li>
            <li>
                <%: Html.LabelFor(m => m.ProviedersNumber)%>
                <%: Html.DisplayFor(m => m.ProviedersNumber)%></li>
        </ul>
    </asp:Panel>
</asp:Content>
