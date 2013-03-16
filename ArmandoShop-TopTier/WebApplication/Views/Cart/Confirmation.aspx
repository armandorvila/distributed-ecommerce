<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Armando Shop - Confirmation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Congratulations</h2>
    <p>
        Your shopping ocurred successfully, your Order Id is
        <%: ViewData["OrderId"] %>, contact me if you have any problem.</p>
        <p>Your order Bla bla bla bla bla ...
     <p>   Your order Bla bla bla bla bla  </p>
      <p>  Your order Bla bla bla bla bla  </p>
      <p>  Your order Bla bla bla bla bla  </p>
      <p>  Your order Bla bla bla bla bla  </p>
        </p>
        <p>
        </p>
   
    <%: Html.ActionLink("Continue", "LoadHome", "Info")%>

</asp:Content>
