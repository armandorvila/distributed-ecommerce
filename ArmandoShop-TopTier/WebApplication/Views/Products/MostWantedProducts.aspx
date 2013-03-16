<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ArmandoShop.WebApplication.Models.Services.Product>>" %>

<asp:Content ID="mostWPTitleSection" ContentPlaceHolderID="TitleContent" runat="server">
    Armando Shop - Most Wanted Products
</asp:Content>
<asp:Content ID="mostWPMainSection" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Most Wanted Products</h2>
    <asp:Panel ID="CategoriesPanel" CssClass="Categories" Font-Bold="true" BorderStyle="Inset"
        runat="server" ScrollBars="Vertical" Enabled="true" EnableTheming="false">
        <table>
            <tr>
                <th>
                    Name
                </th>
                 <th>
                    Category
                </th>
                <th class="Description">
                    Description
                </th>
                <th>
                    Price
                </th>
                <%
    if (Request.IsAuthenticated) {
                    %>
                <th>           
                </th>
                <%} %>
            </tr>
            <% foreach (var item in Model)
               { %>
            <tr>
                <td>
                    <%: item.name %>
                </td>
                 <td>
                    <%: item.category.name %>
                </td>
                <td class="Description">
                    <%: item.description %>
                </td>
                <td>
                    <%: String.Format("{0:F}", item.price) %>
                </td>
                 <%
    if (Request.IsAuthenticated) {
                    %>
                <td>
                    <%: Html.ActionLink("Add To Cart", "AddToCart", item)%>
                </td>
                <%} %>
            </tr>
            <% } %>
        </table>
    </asp:Panel>
</asp:Content>
