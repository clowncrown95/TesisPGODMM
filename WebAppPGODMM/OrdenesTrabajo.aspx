<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenesTrabajo.aspx.cs" Inherits="WebAppPGODMM.OrdenesTrabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Orden de Trabajo</h1>
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
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("ORD_ID")%>' CommandName="edit"><span class='glyphicon glyphicon-edit' aria-hidden='true'></span> Editar</asp:LinkButton></li>
                                <li role="presentation">
                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("ORD_ID")%>' CommandName="delete"><span class='glyphicon glyphicon-minus-sign' aria-hidden='true'></span> Eliminar</asp:LinkButton></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID ORDEN" DataField="ORD_ID" Visible="true" />
                <asp:BoundField HeaderText="Usuario" DataField="USU_USUARIO" Visible="true" />
                <asp:BoundField HeaderText="Local" DataField="LOC_NOMBRE" Visible="true" />
                <asp:BoundField HeaderText="Estado" DataField="EST_NOMBRE" Visible="true" />
                <asp:BoundField HeaderText="Fecha Inicio" DataField="ORD_FECHAINI" Visible="true" />
                <asp:BoundField HeaderText="Fecha Fin" DataField="ORD_FECHAFIN" Visible="true" />
                <asp:BoundField HeaderText="#Orden" DataField="ORD_NUMERO" Visible="true" />
                <asp:BoundField HeaderText="Equipo" DataField="EQU_NOMBRE" Visible="true" />
                <asp:BoundField HeaderText="Detalle" DataField="DTOR_DETALLE" Visible="true" />
                <asp:BoundField HeaderText="Resumen Tecnico" DataField="RTEC_DESCRIPCION" Visible="true" />
                <asp:BoundField HeaderText="Respaldo Tecnico" DataField="RTEC_RESPALDO" Visible="true" />
                <asp:BoundField HeaderText="Costo Reparación" DataField="RTEC_COSTO" Visible="true" />
                <asp:BoundField HeaderText="Firma" DataField="RTEC_FIRMA" Visible="true" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:Panel ID="pnlDatos" runat="server" ScrollBars="Auto" Height="400" BackColor="White">
        
        <asp:Label runat="server" ID="lblRegistros" Text="Registros" />
    </asp:Panel>
</asp:Content>
