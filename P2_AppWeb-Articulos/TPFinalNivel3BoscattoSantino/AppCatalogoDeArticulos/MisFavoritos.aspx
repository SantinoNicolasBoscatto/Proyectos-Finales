<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="AppCatalogoDeArticulos.MisFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Catalogo.css" rel="stylesheet" />
    <div class="row row-cols-1 row-cols-md-3 g-4 align-items-start pt-5">
        <asp:Repeater ID="RepetidorCatalogo" runat="server">
            <ItemTemplate>
                <div class="col mb-3">
                    <div class="card h-100 ColorCard p-1">
                        <img src="<%#Eval("ImagenDelProducto") %>" class="card-img-top MyImage" alt="...">
                        <div class="card-body pb-1">
                            <h4 id="nombreArticulo<%#Container.ItemIndex %>" class="card-title mb-4 text-center text-white"><%#Eval("NombreDeArticulo") %></h4>
                            <div class="Centrar_Responsive">
                                <p class="Plata mt-auto align-self-end pb-1 mb-0 d-inline-block">$ <%#Eval("PrecioDelProducto") %></p>
                                <asp:Button ID="MasDetalles" runat="server" Text="Mas Detalles" CssClass="btn btn-dark Info" OnClick="MasDetalles_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
