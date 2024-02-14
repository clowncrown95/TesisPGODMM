<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearRtecnico.aspx.cs" Inherits="WebAppPGODMM.CrearTecnico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Detalle Orden ID</label>
                <asp:RequiredFieldValidator
                    ID="rfvIddet"
                    runat="server"
                    ControlToValidate="txtIddet"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtIddet" CssClass="form-control" placeholder="Detalle Orden ID" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Descripción</label>
                <asp:RequiredFieldValidator
                    ID="rfvDescripcion"
                    runat="server"
                    ControlToValidate="txtDescripcion"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Detalle de la revisión" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Respaldo</label>
                <asp:RequiredFieldValidator
                    ID="rfvRespaldo"
                    runat="server"
                    ControlToValidate="txtRespaldo"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtRespaldo" CssClass="form-control" placeholder="Subir el respaldo" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Costo</label>
                <asp:RequiredFieldValidator
                    ID="rfvCosto"
                    runat="server"
                    ControlToValidate="txtCosto"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" Type="number" ID="txtCosto" CssClass="form-control" placeholder="250.50" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Firma</label>
                <asp:RequiredFieldValidator
                    ID="rfvFirma"
                    runat="server"
                    ControlToValidate="txtFirma"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtFirma" CssClass="form-control" placeholder="Adjunte firma" />
            </div>
        </div>
    </div>
<hr />
<asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
<asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
<hr />
<asp:Label runat="server" ID="lblResultado" />
</asp:Content>