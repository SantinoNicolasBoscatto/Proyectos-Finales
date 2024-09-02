<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GrillaMC.aspx.cs" Inherits="AppCatalogoDeArticulos.GrillaMC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Grilla.css" rel="stylesheet" />
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="pt-3">
                        <div class="col-2 mb-2">
                            <asp:Button ID="AgregarBoton" runat="server" Text="Agregar Categoria" CssClass="btn btn-outline-success" OnClick="AgregarBoton_Click" />
                        </div>
                        <asp:GridView ID="DGV" runat="server" PageSize="4" AllowPaging="true" DataKeyNames="IdCategoria" OnSelectedIndexChanged="DGV_SelectedIndexChanged"
                            OnPageIndexChanging="DGV_PageIndexChanging" AutoGenerateColumns="false" CssClass="table table-dark table-striped">
                            <Columns>
                                <asp:BoundField DataField="NombreCategoria" HeaderText="Nombre Categoria" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Editor" />
                            </Columns>
                        </asp:GridView>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="pt-3">
                        <div class="col-2 mb-2">
                            <asp:Button ID="AgregarMarca" runat="server" Text="Agregar Marca" CssClass="btn btn-outline-success" OnClick="AgregarMarca_Click" />
                        </div>
                        <asp:GridView ID="DGVMarca" runat="server" PageSize="4" AllowPaging="true" DataKeyNames="IdMarca" OnSelectedIndexChanged="DGVMarca_SelectedIndexChanged"
                            OnPageIndexChanging="DGVMarca_PageIndexChanging" AutoGenerateColumns="false" CssClass="table table-dark table-striped">
                            <Columns>
                                <asp:BoundField DataField="NombreMarca" HeaderText="Nombre Marca" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Editar" HeaderText="Editor" />
                            </Columns>
                        </asp:GridView>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="botones-container">
        <a href="GrillaArticulos.aspx">Volver</a>
    </div>

</asp:Content>
