<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="CarDealer.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .d-flex {
    display: flex;
}

.justify-content-center {
    justify-content: center;
}
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row mt-5">
        <div class="col-6">
            <div class="mb-4">
                <label for="Nombre" class="form-label text-white">Nombre</label>
                <asp:TextBox ID="Nombre" runat="server" class="form-control" placeHolder="Nombre"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label for="Email" class="form-label text-white">Email</label>
                <asp:TextBox ID="EmailPerfil" type="Email" runat="server" class="form-control" placeHolder="Email"></asp:TextBox>
            </div>
            <div class="mb-4">
                <label for="Password" class="form-label text-white">Password</label>
                <asp:TextBox ID="Password" type="password" runat="server" class="form-control" placeHolder="Password"></asp:TextBox>
            </div>
            <asp:Button ID="ActualizarPerfil" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="ActualizarPerfil_Click"/>
            <asp:Button ID="Volver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="Volver_Click"/>
        </div>

        <div class="col-6">
            <div class="mb-4">
                <label for="ImagenUrl" class="form-label text-white">Imagen Url</label>
                <asp:TextBox ID="ImagenUrl" runat="server" class="form-control" placeHolder="Url" AutoPostBack="true" OnTextChanged="ImagenUrl_TextChanged"></asp:TextBox>
            </div>
            <div class="mb-4 d-flex justify-content-center">
                <asp:Image ID="ImgPerfil" runat="server" Width="185px" />
            </div>

        </div>

    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
