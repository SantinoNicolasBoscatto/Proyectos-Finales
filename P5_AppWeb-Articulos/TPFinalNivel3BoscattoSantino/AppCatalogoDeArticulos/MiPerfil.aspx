<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="AppCatalogoDeArticulos.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .radio-inline {
            display: inline-block;
            margin-right: 10px; /* Ajusta este valor según sea necesario para el espaciado deseado entre los radio buttons */
        }

        .Ajuste{
            margin-top: 20px;
        }
    </style>
    <link href="Css/Grilla.css" rel="stylesheet" />
    <link href="Css/MiPerfil.css" rel="stylesheet" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3 mt-3">
                <label for="EmailBox" class="form-label text-white">Email</label>
                <asp:TextBox ID="EmailBox" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="PassBox" class="form-label text-white">Contraseña</label>
                <asp:TextBox ID="PassBox" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidadorPass" runat="server"
                    ErrorMessage="Por Favor Coloque una contraseña" ControlToValidate="PassBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="NombreBox" class="form-label text-white">Nombre</label>
                <asp:TextBox ID="NombreBox" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidarNombre" runat="server"
                    ErrorMessage="Por Favor Coloque su nombre" ControlToValidate="NombreBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-1">
                <label for="ApellidoBox" class="form-label text-white">Apellido</label>
                <asp:TextBox ID="ApellidoBox" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidarApellido" runat="server"
                    ErrorMessage="Por Favor Coloque su apellido" ControlToValidate="NombreBox" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="">
                <asp:Button ID="GuardarCambios" runat="server" Text="Guardar" OnClick="GuardarCambios_Click" CssClass="btn btn-secondary" />
                <a href="Catalogo.aspx">Ir a Catalogo</a>
            </div>

        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpRadio" runat="server">
                <ContentTemplate>
                    <div class="mb-3 mt-5">
                        <label for="ImagenWeb" class="form-label text-white">Cargar Imagen Por URL</label>
                        <asp:RadioButton runat="server" ID="ImagenWeb" Text="" GroupName="Image" AutoPostBack="true" OnCheckedChanged="ImagenServer_CheckedChanged" CssClass="radio-inline" />

                        <label for="ImagenServer" class="form-label text-white">Cargar Imagen Por Server</label>
                        <asp:RadioButton runat="server" ID="ImagenServer" Text="" GroupName="Image" AutoPostBack="true" OnCheckedChanged="ImagenServer_CheckedChanged" CssClass="radio-inline" />
                    </div>
                    <div class="mb-3 Ajuste">
                        <% if (ImagenWeb.Checked == true)
                            {%>
                         <div class="Centrado ">
                        <label for="URLBox" class="form-label text-white">URL</label>
                        <asp:TextBox ID="URLBox" CssClass="form-control" MaxLength="1000" runat="server" OnTextChanged="URLBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:Image ID="ImagenPorUrl" runat="server" CssClass="" />
                             </div>
                        <%} %>

                        <% if (ImagenWeb.Checked == false)
                            {%>
                        <label for="ServerBox" class="form-label text-white">Archivo</label>
                        <input id="SeleccionarImagen" runat="server" type="file" class="form-control mb-3" />
                        <%} %>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpRadio2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="Centrado">
                        <% if (ImagenWeb.Checked == false)
                            {%>
                        <asp:Button ID="UpImagen" runat="server" Text="Cambiar Imagen" OnClick="UpImagen_Click" CssClass="btn btn-secondary mb-3"/>
                        <asp:Image ID="ImagenPorLocal" runat="server"  />
                        <%} %>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="UpImagen" />
                    <asp:AsyncPostBackTrigger ControlID="ImagenServer" EventName="CheckedChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ImagenWeb" EventName="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
