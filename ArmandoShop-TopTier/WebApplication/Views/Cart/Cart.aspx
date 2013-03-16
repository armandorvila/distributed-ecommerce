<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArmandoShop.WebApplication.Models.Model.Cart>" %>

<asp:Content ID="CartTitleSection" ContentPlaceHolderID="TitleContent" runat="server">
    Armando Shop - Cart
</asp:Content>
<asp:Content ID="CartMainSection" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        You Cart</h2>
    <a href="<%= Request.UrlReferrer %>">Back</a>
      <%: Html.ValidationSummary(true) %>
    <asp:Panel ID="ProductsPanel" CssClass="Categories" Font-Bold="true" BorderStyle="Inset"
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
                <th>
                    Units
                </th>
                <th>
                </th>
            </tr>
            <% foreach (var item in Model.Products)
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
                <td>
                    <%: Html.DisplayFor(m => m.Amounts[item.id]) %>
                   
                </td>
                <td>
                    <%: Ajax.ActionLink("Add", "AddUnit",item ,new AjaxOptions { })%>
                    <%: Ajax.ActionLink("Quit", "DecrementUnits",item ,new AjaxOptions { })%>
                    <%: Ajax.ActionLink("Remove", "RemoveOfCart", item, new AjaxOptions { })%>
                </td>
            </tr>
            <% } %>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" cssStyle ="CartOptions">
        <%: Html.ActionLink("Buy All", "BuyCart")%>
        <%: Ajax.ActionLink("Clean Cart", "CleanCart", new AjaxOptions { })%>
    </asp:Panel>
</asp:Content>
