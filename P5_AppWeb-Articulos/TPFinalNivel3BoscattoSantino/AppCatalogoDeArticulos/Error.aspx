<%@ Page Title="" Language="C#" MasterPageFile="~/ErrorMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AppCatalogoDeArticulos.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contenido">
        <h1 class="text-white ">Se Produjo un Error, Porfavor intentelo mas tarde o comuniquese con su 
        proveedor.</h1>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="" class="text-white Error"></asp:Label>
    </div>
    

</asp:Content>
