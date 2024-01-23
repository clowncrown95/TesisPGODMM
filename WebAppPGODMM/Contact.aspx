<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebAppPGODMM.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Datos de Contacto.</h3>
    <address>
        Mail: pein951@hotmail.com<br />
        Nombre: Jefferson Benites<br />
        <abbr title="Phone">Telefono:</abbr>
        0991316042
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">pein951@hotmail.com</a><br />
    </address>
</asp:Content>
