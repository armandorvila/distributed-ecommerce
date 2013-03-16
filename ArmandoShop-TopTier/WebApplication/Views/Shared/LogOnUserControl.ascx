<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        ¡Welcome <b><%: Page.User.Identity.Name %></b>!
         <%: Html.ActionLink("Log Out", "LogOff", "Access") %> 
<%
    }
    else {
%> 
         <%: Html.ActionLink("Access", "LogOn", "Access") %> 
<%
    }
%>
