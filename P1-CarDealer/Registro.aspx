<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CarDealer.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            overflow: hidden;
        }

        .font-size-12 {
            font-size: 12px !important;
        }

        input:-webkit-autofill,
        input:-webkit-autofill:hover,
        input:-webkit-autofill:focus,
        input:-webkit-autofill:active {
            transition: background-color 5000s ease-in-out 0s;
            -webkit-text-fill-color: #000 !important;
        }

        .yellow {
            color: yellow;
            font-size: .7rem;
            float: right;
        }

        .red {
            color: red;
            font-size: .7rem;
            float: left;
        }
    </style>
    <br />
    <div class="row">
        <div class="col-3"></div>
        <div class="col">
            <div class="mb-5">
                <asp:Label for="EmailBox" ID="EmailLabel" runat="server" CssClass="form-label" Text="Email" ForeColor="White"></asp:Label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control text-dark"></asp:TextBox>
                <asp:RegularExpressionValidator CssClass="red" ClientIDMode="Static" ID="EmailFormat" runat="server" Text="Ingrese un Email Valido" ToolTip="Porfavor Ingrese un Mail valido" ControlToValidate="EmailBox" ValidationExpression="(\w)+@(\w)+.com(.(\w)+)*" ForeColor="Red" />
                <asp:Label ID="Unico" runat="server" Text="Esta Mail ya esta registrado, uso uno sin registrar" Visible="false" CssClass="yellow">
                </asp:Label>
            </div>
            <div class="mb-5">
                <asp:Label for="PassBox" ID="PassLabel" runat="server" CssClass="form-label" Text="Contraseña" ForeColor="White"></asp:Label>
                <asp:TextBox ID="PassBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Registrarse" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="Registrarse_Click" />
        </div>
        <div class="col-3">
        </div>
    </div>
</asp:Content>
