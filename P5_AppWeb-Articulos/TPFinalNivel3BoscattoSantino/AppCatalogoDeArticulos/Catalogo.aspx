<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="AppCatalogoDeArticulos.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Catalogo.css" rel="stylesheet" />
    <script>
        function validarFiltro() {
            var filtroBoxValue = document.getElementById('<%= FiltroBox.ClientID %>').value;
            var Caja = document.getElementById('<%= FiltroBox.ClientID %>');
            if (filtroBoxValue === "") {
                Caja.classList.add("is-invalid");
                Caja.classList.remove("is-valid");
                return false;
            }
            Caja.classList.remove("is-invalid");
            Caja.classList.add("is-valid");
            return true;
        }
        document.addEventListener("DOMContentLoaded", function () {
            var repeaterItems = document.querySelectorAll('[id^="nombreArticulo"]');

            repeaterItems.forEach(function (item) {
                var length = item.textContent.trim().length;

                if (length > 28) {
                    item.classList.add("h5");
                } else if (length > 17) {
                    item.classList.add("h4");
                }
            });
        });

        function MasDetalles_Click(index) {
            // Capturar el valor en JavaScript usando el índice
            var idValue = document.getElementById('idValue_' + index).textContent;
            alert(idValue);
            // Imprimir el valor en la consola para verificar

        }
    </script>
    <asp:UpdatePanel ID="UpMO" runat="server">
        <ContentTemplate>
            <div class="row">
                <% if (!((bool)ViewState["MostrarOcultar"]))
                    {%>
                <div class="col-4">
                    <div class="mt-3 mb-3">
                        <label for="CampoBox" class="form-label text-white ms-1">Campo</label>
                        <asp:DropDownList ID="CampoBox" CssClass="dropdown form-control" runat="server" OnSelectedIndexChanged="CampoBox_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Nombre" Value="1" />
                            <asp:ListItem Text="Descripcion" Value="2" />
                            <asp:ListItem Text="Marca" Value="3" />
                            <asp:ListItem Text="Producto" Value="4" />
                            <asp:ListItem Text="Precio" Value="5" />
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="col-4">
                    <div class="mt-3 mb-3">
                        <label for="CriterioBox" class="form-label text-white ">Criterio</label>
                        <asp:DropDownList ID="CriterioBox" CssClass="dropdown form-control" runat="server">
                            <asp:ListItem Text="Empieza Por" Value="1" />
                            <asp:ListItem Text="Termina Por" Value="2" />
                            <asp:ListItem Text="Contiene Por" Value="3" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-4">
                    <div class="mt-3 mb-3">
                        <label for="FiltroBox" class="form-label text-white">Filtro</label>
                        <asp:TextBox ID="FiltroBox" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%} %>
                <div class="botones-container">
                    <asp:Button ID="MostrarOcultar" runat="server" Text="Mostrar Filtros" CssClass="btn btn-primary boton-izquierda" OnClick="MostrarOcultar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpFA" runat="server" UpdateMode="Conditional" CssClass="d-none">
        <ContentTemplate>
            <div class="botones-container mb-3">
                <asp:Button OnClientClick="return validarFiltro();" ID="FiltroAvanzado" runat="server" Text="Filtrar" CssClass="btn btn-danger boton-derecha" OnClick="FiltroAvanzado_Click" Visible="false" />
                <asp:Button ID="Clean" runat="server" Text="Desfiltrar" CssClass="btn btn-warning boton-derecha" OnClick="Clean_Click" Visible="false" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MostrarOcultar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpCatalogo" runat="server" UpdateMode="Conditional" CssClass="d-none">
        <ContentTemplate>
            <div class="row row-cols-1 row-cols-md-3 g-4 align-items-start">
                <asp:Repeater ID="RepetidorCatalogo" runat="server">
                    <ItemTemplate>
                        <div class="col mb-3">
                            <div class="card h-100 bg-warning <%--text-white bg-dark--%> ">
                                <img src="<%#Eval("ImagenDelProducto") %>" class="card-img-top MyImage " alt="...">
                                <div class="card-body pb-1">
                                    <h4 id="nombreArticulo<%#Container.ItemIndex %>" class="card-title mb-4 text-center"><%#Eval("NombreDeArticulo") %></h4>
                                    <%--<p class="card-text"><%#Eval("DescripcionDeArticulo") %></p>--%>
                                    <div class="Centrar_Responsive">
                                        <p class="Plata mt-auto align-self-end pb-1 mb-0 d-inline-block">$ <%#Eval("PrecioDelProducto") %></p>
                                        <asp:Button ID="MasDetalles" runat="server" Text="Mas Detalles" CssClass="btn btn-dark Info" OnClientClick='<%# "MasDetalles_Click(" + Container.ItemIndex + "); return true;" %>' OnClick="MasDetalles_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="FiltroAvanzado" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Clean" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
