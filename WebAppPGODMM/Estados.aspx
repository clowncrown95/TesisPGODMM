<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estados.aspx.cs" Inherits="WebAppPGODMM.Estados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Estados</h1>
    <div class="form-group">
        <div class="input-group">
            <span class="input-group-addon">Busqueda</span>
            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" placeholder="Escribir..." Width="80%"/>
            <span class="input-group-btn">
                <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" CssClass="btn btn-success" OnClick="btnNuevo_Click" />
            </span>
         </div>
            <asp:GridView ID="gvDatos" runat="server" OnRowCommand="gvDatos_RowCommand" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="dropdown">
                            <button class="btn btn-primary btn-sm dropdown-toggle" type="button" data-toggle="dropdown"><span class="glyphicon glyphicon-chevron-right"></span></button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                <li role="presentation">
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("EST_ID")%>' CommandName="edit"><span class='glyphicon glyphicon-edit' aria-hidden='true'></span> Editar</asp:LinkButton></li>
                                <li role="presentation">
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("EST_ID")%>' CommandName="delete"><span class='glyphicon glyphicon-minus-sign' aria-hidden='true'></span> Eliminar</asp:LinkButton></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Código" DataField="EST_ID" Visible="true" />
                <asp:BoundField HeaderText="Estado" DataField="EST_NOMBRE" Visible="true" />
                <asp:BoundField HeaderText="Descripción" DataField="EST_DESCRIPCION" Visible="true" />
                <asp:BoundField HeaderText="Crea" DataField="EST_CREA" Visible="true" />
                <asp:BoundField HeaderText="Actualizo" DataField="EST_ACTUALIZO" Visible="true" />
                <asp:BoundField HeaderText="Creación" DataField="EST_FECHACREA" Visible="true" />
                <asp:BoundField HeaderText="Modificación" DataField="EST_FECHAACTUA" Visible="true" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Panel ID="pnlDatos" runat="server" ScrollBars="Auto" Height="400" BackColor="White">
        
        <asp:Label runat="server" ID="lblRegistros" Text="Registros" />
    </asp:Panel>
</asp:Content>