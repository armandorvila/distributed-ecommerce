<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ArmandoShop.WebApplication.Models.Services.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Arrmando Shop - Products By Category
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Products of Category  <%: ViewData["Category"] %></h2>
     <a href="<%= Request.UrlReferrer %>">Back</a>
    <asp:Panel ID="CategoriesPanel" CssClass="Categories" Font-Bold="true" BorderStyle="Inset"
        runat="server" ScrollBars="Vertical" Enabled="true" EnableTheming="false">
     <table>
        <tr>
             <th>
                Name
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

