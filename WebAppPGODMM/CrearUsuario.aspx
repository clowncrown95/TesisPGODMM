<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="WebAppPGODMM.CrearUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">ROL</label>
                <asp:RequiredFieldValidator 
                    ID="rfvIdRol" 
                    runat="server"
                    ControlToValidate="txtIdRol"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red" 
                    Font-Size="Small"/>
                <asp:TextBox runat="server" ID="txtIdRol" CssClass="form-control" placeholder="Administrador" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Persona</label>
                <asp:RequiredFieldValidator 
                    ID="rfvPersona" 
                    runat="server"
                    ControlToValidate="txtPersona"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red" 
                    Font-Size="Small"/>
                <asp:TextBox runat="server" ID="txtPersona" CssClass="form-control" placeholder="Jefferson Benites" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Usuario</label>
                 <asp:RequiredFieldValidator 
                    ID="rfvUsuario" 
                    runat="server"
                    ControlToValidate="txtUsuario"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red" 
                    Font-Size="Small"/>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" placeholder="Usuario"/>
            </div>
        </div>
    </div>
    <div class="col-md-3">
       <div class="form-group">
            <label class="control-label" for="focusedInput">Password</label>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage=" Campo Requerido."
                ForeColor="Red"
                Font-Size="Small" />
            <asp:TextBox runat="server" type="password" ID="txtPassword" CssClass="form-control" placeholder="Password" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Tipo</label>
                <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control">
                    <asp:ListItem Value="B" Text="Bien" Selected="True" />
                    <asp:ListItem Value="S" Text="Servicio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">IVA</label>
                <asp:DropDownList runat="server" ID="ddlImpuesto" CssClass="form-control">
                    <asp:ListItem Value="0" Text="0%" Selected="True" />
                    <asp:ListItem Value="2" Text="12%" />
                    <asp:ListItem Value="3" Text="14%" Enabled="false" />
                    <asp:ListItem Value="6" Text="No Objeto de Impuesto" />
                    <asp:ListItem Value="7" Text="Exento de IVA" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <hr />
    <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
    <hr />
    <asp:Label runat="server" ID="lblResultado" />
</asp:Content>
