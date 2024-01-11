<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCatalogo.aspx.cs" Inherits="AppCatalogoDeArticulos.DetalleCatalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Detalle.css" rel="stylesheet" />
    <div class="row">
        <div class="col-6 pt-3">
            <div class="mb-3 ContenedorImg">
                <asp:Image ID="ImagenProducto" runat="server" CssClass="MyImg"
                    ImageUrl="https://www.delabahia.com.ar/wp-content/uploads/2017/11/unnamed-1.png" />
            </div>
        </div>
        <div class="col-6 pt-3">
            <div class="mb-5">
                <div class="mb-3 ContenedorDatos pt-2">
                    <asp:Label ID="TituloLabel" Text="" runat="server" CssClass="h1 mb-3"></asp:Label>
                    <asp:Label ID="DescripcionLabel" Text=""
                        runat="server" CssClass="Descripcion mb-3"></asp:Label>
                    <div class="mb-3">
                        <asp:Label ID="LabelCategoria" Text="" runat="server" CssClass="Myh3"></asp:Label>
                        <asp:Label ID="LabelMarca" runat="server" CssClass="Myh3" Text="<strong>Marca:</strong> Samsung">
                        </asp:Label>
                    </div>
                    <div style="display: grid; grid-template-columns: 1fr auto; width:100%;">
                        <asp:Label ID="PrecioLabel" Text="$50.000" runat="server" CssClass="Money"></asp:Label>
                        <asp:Button ID="MasDetalles" runat="server" Text="Volver" CssClass="btn btn-dark Volver mb-2" OnClick="MasDetalles_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
