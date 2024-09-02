<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="CarDealer.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @keyframes changeColor {
            0% {
                color: lightgreen;
            }

            20% {
                color: mediumseagreen;
            }

            40% {
                color: limegreen;
            }

            60% {
                color: forestgreen;
            }

            80% {
                color: mediumseagreen;
            }

            100% {
                color: lightgreen;
            }
        }

        .MyMarca {
            object-fit: contain;
            max-width: 35px;
            max-height: 35px;
        }

        .Dinero {
            font-size: 30px;
            font-weight: bold;
            animation: changeColor 5s infinite; /* 5s para completar el ciclo, infinite para repetir la animación */
        }


        body {
            width: 100%;
            height: 100%;
            --color: rgba(114, 114, 114, 0.3);
            background-color: #191a1a;
            background-image: linear-gradient(0deg, transparent 24%, var(--color) 25%, var(--color) 26%, transparent 27%,transparent 74%, var(--color) 75%, var(--color) 76%, transparent 77%,transparent), linear-gradient(90deg, transparent 24%, var(--color) 25%, var(--color) 26%, transparent 27%,transparent 74%, var(--color) 75%, var(--color) 76%, transparent 77%,transparent);
            background-size: 55px 55px;
        }

        .MyImg {
            border-radius: 5px;
            border: #666 2px solid;
            place-items: center;
            background-color: rgba(0,128,128,.33);
            transition: background-color ease-in .8s, transform ease .5s;
            height: auto;
            width: 100%;
            min-height: 430px;
            max-height: 430px;
            object-fit: cover;
        }


        .ContenedorImg {
            display: grid;
            place-items: center;
        }

        .ContenedorDatos {
            display: grid;
            place-items: center;
            border: 2px solid rgba(128,128,128,.9);
            width: 100%;
            border-radius: 10px;
            background-color: rgba(115,115,115,.7);
            transition: background-color ease-in .5s, transform ease .5s;
            min-height: 430px;
            max-height: 430px;
        }

            .ContenedorDatos:hover {
                background-color: rgba(115,115,115,.8);
                transform: scale(1.05);
            }

        h2 {
            font-size: 32px;
            margin-bottom: 3px;
            margin-top: 8px;
            color: black;
        }

        .SPY {
            font-size: 20px;
            color: #FFF;
            font-weight: bold;
        }

        @media screen and (min-width: 768px) and (max-width: 1195px) {
            .MyImg {
                min-height: 380px;
                max-height: 380px;
                object-fit: cover;
            }

            .ContenedorDatos {
                min-height: 380px;
                max-height: 380px;
            }

            h2 {
                font-size: 25px;
                margin-bottom: 5px;
                margin-top: 6px;
            }

            .SPY {
                font-size: 18px;
            }
        }

        .Putton {
            all: unset;
            display: flex;
            align-items: center;
            position: relative;
            padding: 0.6em 2em;
            border: mediumspringgreen solid 0.15em;
            border-radius: 0.25em;
            color: mediumspringgreen;
            font-size: 1.5em;
            font-weight: 600;
            cursor: pointer;
            overflow: hidden;
            transition: border 300ms, color 300ms;
            user-select: none;
        }


            .Putton:hover {
                color: #212121;
            }

            .Putton:active {
                border-color: teal;
            }

            .Putton::after, .Putton::before {
                content: "";
                position: absolute;
                width: 9em;
                aspect-ratio: 1;
                background: mediumspringgreen;
                opacity: 50%;
                border-radius: 50%;
                transition: transform 500ms, background 300ms;
            }

            .Putton::before {
                left: 0;
                transform: translateX(-8em);
            }

            .Putton::after {
                right: 0;
                transform: translateX(8em);
            }

            .Putton:hover:before {
                transform: translateX(-1em);
            }

            .Putton:hover:after {
                transform: translateX(1em);
            }

            .Putton:active:before,
            .Putton:active:after {
                background: teal;
            }

        @media screen and (min-width: 768px) and (max-width: 991px) {
        }

        @media screen and (max-width: 769px) {
            .col-6 {
                width: 100%;
            }
        }
    </style>
    <div class="row">
        <div class="col-8 pt-3">
            <div class="mb-3 ContenedorImg">

                <asp:Image ID="ImagenProducto" runat="server" CssClass="MyImg"
                    ImageUrl="https://b375.com.ar/wp/wp-content/uploads/2023/08/renault11turbo_3-scaled.jpg" />

            </div>
            <div class="d-flex justify-content-between">
                <asp:Label CssClass="card-text Dinero mb-3" ID="CompraLabel" runat="server" Text="$ 999.999"></asp:Label>
                <asp:Label ID="ErrorCompra" runat="server" Style="color: red; font-size: 16px;" CssClass="mt-2"
                    Text="Saldo Insuficiente para realizar esta compra" Visible="false"></asp:Label>
                <asp:Button ID="Comprar" runat="server" Text="Comprar" OnClick="Comprar_Click"
                    CssClass="btn btn-outline-success mb-3 float-end" />
            </div>


        </div>
        <div class="col-4 pt-3">
            <div class="mb-3 ContenedorDatos align-items-start justify-content-center" style="display: grid; grid-template-columns: repeat(2, 1fr); gap: 0px; pt-3;">
                <div class="text-center">
                    <h2>Modelo</h2>
                    <asp:Label CssClass="card-text SPY mt-5" ID="ModeloLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Marca</h2>
                    <asp:Image ID="MarcaImagen" CssClass="MyMarca" runat="server" Width="48px" Height="48px" />
                </div>
                <div class="text-center">
                    <h2>Potencia</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="PotenciaLabel" runat="server" Text=""></asp:Label>

                </div>
                <div class="text-center">
                    <h2>Peso</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="PesoLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Kg/Hp</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="PPLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Tracción</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="TraccionLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Aspiración</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="ASPLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Kilómetros</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="KMLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Torque</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="TorqueLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="text-center">
                    <h2>Año</h2>
                    <asp:Label CssClass="m-0 card-text SPY" ID="YearLabel" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <asp:Button ID="VolverBoton" runat="server" Text="Volver" OnClick="VolverBoton_Click"
                CssClass="btn btn-dark mb-4 float-end" />
        </div>

    </div>
</asp:Content>
