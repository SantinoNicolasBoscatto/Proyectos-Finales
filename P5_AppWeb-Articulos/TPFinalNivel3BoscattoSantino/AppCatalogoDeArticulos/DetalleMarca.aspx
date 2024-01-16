<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleMarca.aspx.cs" Inherits="AppCatalogoDeArticulos.DetalleMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Grilla.css" rel="stylesheet" />
    <style>
        .BackDinamico{
            height:auto;
        }
    </style>
    <div class="row ">
        <div class="col-7 mt-4 mb-3">
            <div class="mb-3">
                <label for="IdMarca" class="form-label text-white">Id Marca</label>
                <asp:TextBox ID="IdMarca" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="NombreMarca" class="form-label text-white">Nombre Marca</label>
                <asp:TextBox ID="NombreMarca" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CodigoVerificador" ControlToValidate="NombreMarca" runat="server" ErrorMessage="Porfavor Complete el Campo" ForeColor="Red"></asp:RequiredFieldValidator>
                
            </div>
            <div>
                <asp:Button ID="ModificarBoton" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="ModificarBoton_Click"/>
                <a href="GrillaMC.aspx">Volver</a>
            </div>
        </div>
    </div>
</asp:Content>
