<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppPGODMM.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Login</title>
    <style type="text/css">
        .loading {
        position: fixed;
            top: 0;
            left: 0;
            background-color: silver;
            z-index: 99;
            opacity: 0.8;
            min-height: 100%;
            width: 100%;    
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upLogin" runat="server">
            <ContentTemplate>
                <br />
                <div class="container">
                    <div class="jumbotron">
                        <h1>Gestion de Equipos</h1>
                        <h3>Iniciar Sesión</h3>
                        <b>Usuario</b>
                        <asp:TextBox ID="txtCorreoElectronico" runat="server" placeholder="Usuario" MaxLength="30" Required="" />
                        <b>Password</b>
                        <asp:TextBox ID="txtContrasenia" runat="server" placeholder="Password" TextMode="Password" MaxLength="50" Required="" />
                        <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" />
                        <br />
                        <asp:UpdateProgress runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upLogin" DisplayAfter="1">
                            <ProgressTemplate>
                                <div class="progress progress-striped active">
                                   <div class="progress-bar" style="width: 90%" ></div>
                                </div>                             
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <hr />
                        <asp:Label runat="server" ID="lblResultado" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
