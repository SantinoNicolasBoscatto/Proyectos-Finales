<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCategoria.aspx.cs" Inherits="AppCatalogoDeArticulos.DetalleCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Grilla.css" rel="stylesheet" />
    <div class="row ">
        <div class="col-7 mt-4">
            <div class="mb-3">
                <label for="IdCat" class="form-label text-white">Id Categoria</label>
                <asp:TextBox ID="IdCat" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="NombreCategoria" class="form-label text-white">Nombre Categoria</label>
                <asp:TextBox ID="NombreCategoria" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CodigoVerificador" ControlToValidate="NombreCategoria" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>
                
            </div>
            <div>
                <asp:Button ID="ModificarBoton" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="ModificarBoton_Click"/>
                <a href="GrillaMC.aspx">Volver</a>
            </div>
        </div>
    </div>

</asp:Content>
