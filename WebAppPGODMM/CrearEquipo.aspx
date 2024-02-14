<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEquipo.aspx.cs" Inherits="WebAppPGODMM.CrearEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Categoria</label>
                <asp:RequiredFieldValidator
                    ID="rfvIdCategoria"
                    runat="server"
                    ControlToValidate="txtIdCategoria"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtIdCategoria" CssClass="form-control" placeholder="Maquinaria" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Nombre</label>
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="jbenites" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Codigo</label>
                <asp:RequiredFieldValidator
                    ID="rfvCodigo"
                    runat="server"
                    ControlToValidate="txtCodigo"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" placeholder="MAFR001" />
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
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Descripción" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Tiempo</label>
                <asp:RequiredFieldValidator
                    ID="rfvTiempo"
                    runat="server"
                    ControlToValidate="txtTiempo"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtTiempo" CssClass="form-control" placeholder="10" />
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
                <asp:TextBox runat="server" Type="number" ID="txtCosto" CssClass="form-control" placeholder="2500.50" />
            </div>
        </div>
    </div>
<hr />
<asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
<asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
<hr />
<asp:Label runat="server" ID="lblResultado" />
</asp:Content>
