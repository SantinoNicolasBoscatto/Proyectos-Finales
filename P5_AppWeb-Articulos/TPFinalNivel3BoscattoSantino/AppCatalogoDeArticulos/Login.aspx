<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppCatalogoDeArticulos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function enviarPostback() {
            __doPostBack('Log', '');
        }
    </script>
    <div class="row">
        <div class="col">
            <div class="login-box  mt-4">
                <div class="Contenedor">
                    <div class="user-box mb-3">
                        <asp:TextBox PlaceHolder="Email" ID="EmailBox" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RegularExpressionValidator CssClass="RegularExp" ClientIDMode="Static" ID="EmailFormat" runat="server" Text="Ingrese un Email Valido" ToolTip="Porfavor Ingrese un Mail valido" ControlToValidate="EmailBox" ValidationExpression="(\w)+@(\w)+.com(.(\w)+)*" ForeColor="Red"/>
                    </div>
                    <div class="user-box">
                        <asp:TextBox  PlaceHolder="Contraseña" ID="PassBox" runat="server" TextMode="Password" ></asp:TextBox>
                        <asp:Label ID="LabelError" ClientIDMode="Static" runat="server" Text="Error en el Login, el Email y\o la Clave son Erroneas"
                            CssClass="RegularExp" Visible="false" ForeColor="Red"></asp:Label>
                    </div>
                    <center class="mt-3">
                        <a href="#" onclick="enviarPostback(); return false;" id="btnLog" TabIndex="0">Login
                        <span></span>
                        </a>
                    </center>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>
