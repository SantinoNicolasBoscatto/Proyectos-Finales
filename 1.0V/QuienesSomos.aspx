<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuienesSomos.aspx.cs" Inherits="CarDealer.QuienesSomos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
    background-image: url("https://media.moddb.com/cache/images/games/1/65/64207/thumb_620x2000/Screenshot5IndieDB.png");
    position: relative;
}

body::after {
    content: "";
    background: rgba(25, 25, 25, .5); /* Capa gris semi-transparente */
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100vh;
    z-index: 1; /* Asegura que la capa esté detrás del contenido */
}

p, div {
    position: relative;
    z-index: 2; /* Asegura que el contenido esté por encima de la capa */
}

nav {
    position: relative;
    z-index: 3; /* Asegura que el nav esté por encima de todo */
}


    </style>
    <div class="row">
        <div class="col-1"></div>
        <div class="col text-white">
            <h1 class="text-center mb-4 mt-3 fs-1">CarDealer TougeGear</h1>
            <p style="font-size: 1.1rem;">Bienvenido a CarDealer TougeGear, tu destino definitivo para adentrarte en el apasionante mundo de los autos deportivos usados. Nos especializamos en la intermediación de vehículos para aquellos que buscan la emoción pura de las carreras clandestinas de touge.</p>
            <p style="font-size: 1.1rem;">Somos más que simples intermediarios; somos entusiastas apasionados que comprendemos la adrenalina que se siente al conducir en las sinuosas carreteras de montaña, compitiendo contra rivales y superando límites.</p>
            <p style="font-size: 1.1rem;">Nuestra misión es simple pero poderosa: extender y fortalecer el amor por los autos deportivos a gasoil, llevando la emoción de las carreras clandestinas a nuevos horizontes. Con una selección cuidadosamente curada de vehículos usados, garantizamos que cada cliente encuentre la máquina perfecta para desatar su pasión en las carreteras nocturnas.</p>
            <p style="font-size: 1.1rem;">En TougeGear, no solo te ofrecemos un automóvil, te ofrecemos una entrada al emocionante mundo del touge, donde la velocidad, la destreza y la adrenalina se fusionan en una experiencia inolvidable. ¡Únete a nosotros y descubre el verdadero significado de la velocidad!</p>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
