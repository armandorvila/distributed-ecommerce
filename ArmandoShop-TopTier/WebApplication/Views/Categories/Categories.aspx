<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ArmandoShop.WebApplication.Models.Services.Category>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Armando Shop - Categories
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Categories</h2>
    <p class="info">
        In this Section you can select a category and exam their products..
    </p>
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
                    Show
                </th>
            </tr>
            <% foreach (var item in Model)
               { %>
            <tr>
                <td>
                    <%: item.name %>
                </td>
                <td class="Description" onclick="Alert('Description');">
                    <%: item.description %>
                </td>
                <td>
                    <%: Html.ActionLink("Show Products", "ShowProducts",
                        new { id = item.id,item.name })%>
                </td>
            </tr>
            <% } %>
        </table>
    </asp:Panel>
</asp:Content>
