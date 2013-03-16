<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArmandoShop.WebApplication.Models.Model.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Registrarse
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create a new account as customer of my shop !!</h2>
    <p>
        Introduce your information ..
    </p>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "Regisstration Failed, check errors and try again..") %>
    <div>
        <fieldset>
            <legend>Información de cuenta</legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Name) %>
                <%: Html.ValidationMessageFor(m => m.Name) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Surname) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Surname) %>
                <%: Html.ValidationMessageFor(m => m.Surname) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Address) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Address) %>
                <%: Html.ValidationMessageFor(m => m.Address) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Phone) %>
                <%: Html.ValidationMessageFor(m => m.Phone) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Email) %>
                <%: Html.ValidationMessageFor(m => m.Email) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.UserName) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.Password) %>
                <%: Html.ValidationMessageFor(m => m.Password) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
            </div>
            <p>
                <input type="submit" value="Registrarse" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
