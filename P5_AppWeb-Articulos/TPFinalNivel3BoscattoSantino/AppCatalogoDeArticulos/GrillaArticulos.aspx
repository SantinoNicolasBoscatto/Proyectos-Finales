<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GrillaArticulos.aspx.cs" Inherits="AppCatalogoDeArticulos.GrillaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Grilla.css" rel="stylesheet" />
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
    </script>

    <div class="pt-3">
        <div class="col-2 mb-2">
            <asp:Button ID="AgregarBoton" runat="server" Text="Agregar" CssClass="btn btn-outline-success" OnClick="AgregarBoton_Click"/>
        </div>
        
    <asp:UpdatePanel ID="UpdateDGV" runat="server" >
        <ContentTemplate>
            <asp:GridView ID="DGV" runat="server" PageSize="5" AllowPaging="true" DataKeyNames="Id" OnSelectedIndexChanged="DGV_SelectedIndexChanged"
                OnPageIndexChanging="DGV_PageIndexChanging" AutoGenerateColumns="false" CssClass="table table-dark table-striped">
                <Columns>
                    <asp:BoundField DataField="CodigoDeArticulo" HeaderText="Codigo" />
                    <asp:BoundField DataField="NombreDeArticulo" HeaderText="Nombre" />
                    <asp:BoundField DataField="PrecioDelProducto" HeaderText="Precio" />
                    <asp:BoundField DataField="MarcaDelProducto" HeaderText="Marca" />
                    <asp:BoundField DataField="CategoriaDelProducto" HeaderText="Categoria" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Editor" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="FiltroAvanzado" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Clean" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="DGV" EventName="PageIndexChanging" />
        </Triggers>
    </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpMO" runat="server">
        <ContentTemplate>
            <div class="row">
                <% if (!((bool)ViewState["MostrarOcultar"]))
                    {%>
                <div class="col-4">
                    <div class="mt-2 mb-3">
                        <label for="CampoBox" class="form-label text-white ms-1">Campo</label>
                        <asp:DropDownList ID="CampoBox" CssClass="dropdown form-control" runat="server" OnSelectedIndexChanged="CampoBox_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Nombre" Value="1" />
                            <asp:ListItem Text="Descripcion" Value="2" />
                            <asp:ListItem Text="Marca" Value="3" />
                            <asp:ListItem Text="Categoria" Value="4" />
                            <asp:ListItem Text="Precio" Value="5" />
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="col-4">
                    <div class="mt-2 mb-3">
                        <label for="CriterioBox" class="form-label text-white ">Criterio</label>
                        <asp:DropDownList ID="CriterioBox" CssClass="dropdown form-control" runat="server">
                            <asp:ListItem Text="Empieza Por" Value="1" />
                            <asp:ListItem Text="Termina Por" Value="2" />
                            <asp:ListItem Text="Contiene" Value="3" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-4">
                    <div class="mt-2 mb-3">
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
            <div class="botones-container mb-2">
                <asp:Button OnClientClick="return validarFiltro();" ID="FiltroAvanzado" runat="server" Text="Filtrar" CssClass="btn btn-danger boton-derecha" OnClick="FiltroAvanzado_Click" Visible="false" />
                <asp:Button ID="Clean" runat="server" Text="Desfiltrar" CssClass="btn btn-warning boton-derecha" OnClick="Clean_Click" Visible="false" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MostrarOcultar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
