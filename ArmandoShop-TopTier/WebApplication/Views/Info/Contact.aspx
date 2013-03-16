<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Armando Shop - Contact
</asp:Content>
<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Contact with us..</h2>
    
    <asp:Panel runat="server" BorderWidth="2" BorderStyle="Inset" Width="50%" Font-Bold="true">
    <ul>
        <li>Name : Armando Ramírez </li>
        <li>Mail :
            <ol>
                <li>UO213731@uniovi.es</li>
                <li>armandorv@innova.uniovi.es</li>
                <li>armmandoo2@gmail.com</li>
            </ol>
        </li>
        <li>Address : Calle C N0 N</li>
        <li> Phones :
            <ol>
                <li>675880908</li>
                <li>323232323</li>
                <li>2323232323</li>
            </ol>
        </li>
        <li>More Info in : <a href="http://www.armandorv.com">armandorv.com</a></li>
    </ul>
    </asp:Panel>
</asp:Content>
