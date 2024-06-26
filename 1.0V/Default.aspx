<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarDealer._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card {
            border: 0px;
            background-color: #222;
            border-radius: 0;
            width: 21.5rem;
            transition: transform 0.5s;
        }

            .card:hover {
                transform: translateY(-15px);
            }

        .Tit {
            font-size: 22px;
            font-family: 'Pathway Gothic One', sans-serif;
            margin-top: 0.2rem;
        }

        .Tit2 {
            font-size: 19px;
            font-family: 'Pathway Gothic One', sans-serif;
            margin-top: 0.2rem;
        }

        .Tit3 {
            font-size: 16px;
            font-family: 'Pathway Gothic One', sans-serif;
            margin-top: 0.2rem;
        }

        .card-body {
            padding: .7rem .85rem
        }

        .card img {
            transition: 0.7s; /* Añade una transición suave para el efecto hover */
        }

        .card:hover img {
            filter: brightness(60%); /* Ajusta el brillo para lograr el efecto gris semi transparente */
        }

        .MyButton {
            padding: 5px 10px;
            text-transform: uppercase;
            border-radius: 8px;
            font-size: 14px;
            font-weight: 500;
            color: #ffffff80;
            text-shadow: none;
            background: transparent;
            cursor: pointer;
            box-shadow: transparent;
            border: 1px solid #ffffff80;
            transition: 0.5s ease;
            user-select: none;
        }

            .MyButton:hover {
                color: #ffffff;
                background: #008cff;
                border: 1px solid #008cff;
                text-shadow: 0 0 5px #ffffff, 0 0 10px #ffffff, 0 0 20px #ffffff;
                box-shadow: 0 0 5px #008cff, 0 0 20px #008cff, 0 0 50px #008cff, 0 0 100px #008cff;
            }

        @media screen and (min-width: 768px) and (max-width: 1195px) {
            .card {
                width: 19.2rem;
                transition: transform 0.5s;
            }

            .Tit {
                font-size: 18px;
                font-family: 'Pathway Gothic One', sans-serif;
                margin-top: 0.2rem;
            }

            .Tit2 {
                font-size: 15px;
                font-family: 'Pathway Gothic One', sans-serif;
                margin-top: 0.2rem;
            }

            .Tit3 {
                font-size: 13px;
                font-family: 'Pathway Gothic One', sans-serif;
                margin-top: 0.2rem;
            }
        }
    </style>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var repeaterItems = document.querySelectorAll('[id^="NombreAuto"]');

            repeaterItems.forEach(function (item) {
                var length = item.textContent.trim().length;

                if (length > 30) {
                    item.classList.add("Tit3");
                } else if (length > 24) {
                    item.classList.add("Tit2");
                }
            });
        });
    </script>
    <div class="row row-cols-1 row-cols-md-3 g-4 mt-3">
        <asp:Repeater ID="Repetidor" runat="server">
            <ItemTemplate>
                <div class="col-12 col-lg-4 col-sm-6 d-flex justify-content-center align-items-center">
                    <div class="card h-100">                    
                        <img src="<%#Eval("ImagenVenta") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 id="NombreAuto" class="card-title text-white p-0 float-lg-start ms-2 d-inline Tit"><%#Eval("NombreModelo") %></h5>
                            <asp:Button ID="MasDetalles" runat="server" Text="Mas Detalles" class="MyButton float-end" OnClick="MasDetalles_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   <br />
</asp:Content>
