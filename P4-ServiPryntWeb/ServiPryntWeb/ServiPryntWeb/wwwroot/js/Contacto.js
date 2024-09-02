function ValidarNombre() {
    let nombre = d.getElementById('Nombre_Campo').value;
    if (d.getElementById('Nombre_Campo') === null) return;
    if (nombre === '') {
        d.getElementById("Nombre-error").innerText = "Por favor Coloque un nombre";
        bd = false;
    }
    else {
        let regex = /^[a-zA-ZñÑ\s]+$/;
        if (!regex.test(nombre)) {
            d.getElementById("Nombre-error").innerText = "Por favor, ingresa caracteres validos en tu nombre";
            bd = false;
        }
        else d.getElementById("Nombre-error").innerText = "";
    }
}
function ValidarEmail() {
    let email = d.getElementById('Mail_Campo').value;
    if (email === null) return;
    if (email === '') {
        d.getElementById("Mail-error").innerText = "Por favor, ingresa un correo electrónico.";
        bd = false;
    }
    else {
        let regex = /^[\w-]+(\.[\w-]+)*@([\w -] +\.)+[a-zA-Z]{2,7}$/;
        if (!regex.test(email)) {
            d.getElementById("Mail-error").innerText = "Por favor, ingresa un correo electrónico válido.";
            bd = false;
        }
        else d.getElementById("Mail-error").innerText = "";
    }
}
function ValidarTelefono() {
    let telefono = d.getElementById('Telefono_Campo').value;
    if (telefono === null) return;
    if (telefono === '') {
        d.getElementById("Telefono-error").innerText = "Por favor, ingresa tu número de teléfono.";
        bd = false;
    }
    else {
        let regex = /^\d{10}$/;
        if (!regex.test(telefono)) {
            d.getElementById("Telefono-error").innerText = "Por favor, ingresa un número de teléfono válido.";
            bd = false;
        }
        else d.getElementById("Telefono-error").innerText = "";
    }
}
function ValidarMensaje() {
    let mensaje = d.getElementById('Mensaje_Campo').value;
    if (mensaje === null) return;
    if (mensaje === '') {
        d.getElementById("Mensaje-error").innerText = "Por favor, ingresa un mensaje.";
        bd = false;
    }
    else d.getElementById("Mensaje-error").innerText = "";
}
function ValidarInputs() {
    ValidarNombre();
    ValidarEmail();
    ValidarTelefono();
    ValidarMensaje();
    if (bd) alert('Formulario enviado exitosamente!');
    bd = true;
}
function CargarMapa() {
    let map = L.map('MiMapa').setView([-31.40821, -64.18211], 15);

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    var redIcon = new L.Icon({
        iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-red.png',
        shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41]
    });

    L.marker([-31.40821, -64.18211], { icon: redIcon }).addTo(map).bindPopup("Rivera Indarte 630").openPopup();
    map.scrollWheelZoom.disable();
}

d.addEventListener("submit", e => {
    e.preventDefault();
    if (e.target.matches(".formu")) ValidarInputs();
})
d.getElementById('Nombre_Campo').addEventListener("blur", ValidarNombre);
d.getElementById('Mail_Campo').addEventListener("blur", ValidarEmail);
d.getElementById('Telefono_Campo').addEventListener("blur", ValidarTelefono);
d.getElementById('Mensaje_Campo').addEventListener("blur", ValidarMensaje);
d.addEventListener("DOMContentLoaded", CargarMapa)