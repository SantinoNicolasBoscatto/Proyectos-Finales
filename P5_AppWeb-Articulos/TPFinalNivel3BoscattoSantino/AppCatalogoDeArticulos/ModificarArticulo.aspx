<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="AppCatalogoDeArticulos.ModificarArticulo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Grilla.css" rel="stylesheet" />
    <div class="row">
        <div class="col-5">
            <div class="mt-3 mb-3">
                <label for="IdBox" class="form-label text-white">Id</label>
                <asp:TextBox ID="IdBox" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="CodigoBox" class="form-label text-white">Codigo</label>
                <asp:TextBox ID="CodigoBox" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CodigoVerificador" ControlToValidate="CodigoBox" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="NombreBox" class="form-label text-white">Nombre</label>
                <asp:TextBox ID="NombreBox" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NombreBoxVerificador" ControlToValidate="NombreBox" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="PrecioBox" class="form-label text-white">Precio</label>
                <asp:TextBox ID="PrecioBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PrecioBoxVerificador" ControlToValidate="PrecioBox" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
            <div class="mb-3">
                <asp:Button ID="ModificarBoton" runat="server" Text="Modificar" OnClick="ModificarBoton_Click" CssClass="btn btn-warning" />
                <a href="GrillaArticulos.aspx">Volver </a>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-5">
            <div class="mb-3 mt-3">
                <label for="CategoriaBox" class="form-label text-white">Categoria</label>
                <asp:DropDownList ID="CategoriaBox" CssClass="dropdown form-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="MarcaBox" class="form-label text-white">Marca</label>
                <asp:DropDownList ID="MarcaBox" CssClass="dropdown form-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="DescripcionBox" class="form-label text-white">Descripcion</label>
                <asp:TextBox ID="DescripcionBox" MaxLength="150" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="DescripcionBoxVerificador" ControlToValidate="DescripcionBox" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <asp:UpdatePanel ID="UpRadio" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="ImagenWeb" class="form-label text-white">Cargar Imagen Por  URL</label>
                        <asp:RadioButton runat="server" ID="ImagenWeb" Text="" GroupName="Image" AutoPostBack="true" OnCheckedChanged="ImagenServer_CheckedChanged" />
                        <br />
                        <label for="ImagenServer" class="form-label text-white">Cargar Imagen Por Server</label>
                        <asp:RadioButton runat="server" ID="ImagenServer" Text="" GroupName="Image" AutoPostBack="true" OnCheckedChanged="ImagenServer_CheckedChanged" />
                    </div>
                    <div class="mb-3 Centrado">
                        <% if (ImagenWeb.Checked)
                            {%>
                        <label for="URLBox" class="form-label text-white">URL</label>
                        <asp:TextBox ID="URLBox" CssClass="form-control" MaxLength="1000" runat="server" OnTextChanged="URLBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="URLBoxVerificador" ControlToValidate="URLBox" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>

                        <%} %>
                        <% if (ImagenServer.Checked)
                            {%>
                        <label for="ServerBox" class="form-label text-white">Archivo</label>
                        <ajaxToolkit:AsyncFileUpload ID="SeleccionarImagen" CssClass="form-control mb-3" runat="server" ThrobberID="ImagenProducto" OnUploadedComplete="SeleccionarImagen_UploadedComplete" />
                        <%} %>
                        <asp:Image ID="ImagenProducto" runat="server" CssClass="" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
