<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarRol.aspx.cs" Inherits="WebAppPGODMM.EliminarRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="lblRolId" />
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Nombre</label>
                <asp:RequiredFieldValidator
                    ID="rfvRolnombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Administrador" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Descripción</label>
                <asp:RequiredFieldValidator
                    ID="rfvRoldescripcion"
                    runat="server"
                    ControlToValidate="txtDescripcion"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Maneja el sistema" />
            </div>
        </div>
    </div>
    <hr />
    <asp:Button runat="server" CssClass="btn btn-danger" ID="btnGrabar" Text="Eliminar" OnClick="btnGrabar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
    <hr />
    <asp:Label ForeColor="Red" ID="lblError" runat="server" />
</asp:Content>
