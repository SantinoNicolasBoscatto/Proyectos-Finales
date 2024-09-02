
const d = document;
const $nav = d.querySelector("nav");
const $logo = d.getElementById("Logo");
const $a = d.querySelectorAll(".nav-item a");
let bd = true;

function CargarService(firstSplit = "Home/", redirect = "Home/Productos", sizing = true) {
    var urlLimpia = window.location.href.split(firstSplit)[0];
    if (sizing) {
        let esMayor = (window.innerWidth > 590) ? 1 : 0;
        window.location.href = urlLimpia + redirect + '?size=' + esMayor.toString() + "#index=" + 1;
    }
    else {
        window.location.href = urlLimpia + redirect + "#index=" + 1;
    }
    
}
$('#carouselExampleCaptions').on('slid.bs.carousel', function () {
    VisibleObjets([".carousel-item.active"]);
});



d.addEventListener("click", e => {
    if (e.target.matches(".page-link.num")) {
        e.preventDefault();
        if (!(location.href.includes("Home"))) {
            let count = parseInt(e.target.textContent);
            let queryString = location.hash.replace("#", "");
            const params = new URLSearchParams(queryString);

            // Accede a los valores de los parámetros
            const valueType = params.get('valueType');
            const valueStock = params.get('valueStock');
            const valueOferta = params.get('valueOferta');
            let url = "";

            if (location.href.includes("DgvMarcas")) {
                url = "DgvMarcasPartial";
                $.ajax({
                    type: 'GET',
                    url: '/Admin/' + url,
                    data: { index: count },
                    success: function (data) {
                        $('#DgvMarcas').html(data);
                    }
                });
                location.hash = `#index=${count}`
            }
            if (location.href.includes("DgvProductos")) {
                url = "DgvProductosPartial";
                $.ajax({
                    type: 'GET',
                    url: '/Admin/' + url,
                    data: { index: count, valueOferta: valueOferta, valueStock: valueStock, valueType: valueType },
                    success: function (data) {
                        $('#DgvProductos').html(data);
                    }
                });
                if (!(valueType == null || valueStock == null || valueOferta == null))
                    location.hash = `#valueType=${valueType}&valueStock=${valueStock}&valueOferta=${valueOferta}&index=${count}`
                else
                    location.hash = `#index=${count}`
            }
            if (location.href.includes("DgvTypes")) {
                url = "DgvTypesPartial";
                $.ajax({
                    type: 'GET',
                    url: '/Admin/' + url,
                    data: { index: count },
                    success: function (data) {
                        $('#DgvTypes').html(data);
                    }
                });
                location.hash = `#index=${count}`
            }
        }
        else {
            let count = parseInt(e.target.textContent);
            let queryString = location.hash.replace("#", "");
            const params = new URLSearchParams(queryString);

            const valueType = params.get('valueType');
            const valueMarca = params.get('valueMarca');

            let size = location.href.split("size=")[1].split("#")[0];
            $.ajax({
                type: 'GET',
                url: '/Home/ProductosAJAX',
                data: { index: count, size: size, valueType: valueType, valueMarca: valueMarca},
                success: function (data) {
                    $('#Producto-Container').html(data);
                }
            });
            if (!(valueType == null || valueMarca == null))
                location.hash = `#valueType=${valueType}&valueMarca=${valueMarca}&index=${count}`
            else
                location.hash = `#index=${count}`
            document.getElementById('Producto-Container').scrollIntoView();
        }
    }
    else if (e.target.matches(".page-link")) {
        e.preventDefault();
        if (!location.href.includes("Home")) {
            let count = window.location.href.split('index=')[1];
            count = parseInt(count);
            if (e.target.matches(".next-pa")) count++;
            else count--;

            let queryString = location.hash.replace("#", "");
            const params = new URLSearchParams(queryString);
            // Accede a los valores de los parámetros
            const valueType = params.get('valueType');
            const valueStock = params.get('valueStock');
            const valueOferta = params.get('valueOferta');

            if (location.href.includes("DgvMarcas")) {
                url = "DgvMarcasPartial";
                $.ajax({
                    type: 'GET',
                    url: '/Admin/' + url,
                    data: { index: count },
                    success: function (data) {
                        $('#DgvMarcas').html(data);
                    }
                });
                location.hash = `#index=${count}`
            }
            if (location.href.includes("DgvTypes")) {
                url = "DgvTypesPartial";
                $.ajax({
                    type: 'GET',
                    url: '/Admin/' + url,
                    data: { index: count },
                    success: function (data) {
                        $('#DgvTypes').html(data);
                    }
                });
                location.hash = `#index=${count}`
            }
            if (location.href.includes("DgvProductos")) {
                url = "DgvProductosPartial";
                $.ajax({
                    type: 'GET',
                    url: '/Admin/' + url,
                    data: { index: count, valueOferta: valueOferta, valueStock: valueStock, valueType: valueType },
                    success: function (data) {
                        $('#DgvProductos').html(data);
                    }
                });
                if (!(valueType == null || valueStock == null || valueOferta == null))
                    location.hash = `#valueType=${valueType}&valueStock=${valueStock}&valueOferta=${valueOferta}&index=${count}`
                else
                    location.hash = `#index=${count}`
            }
        }
        else {
            let count = window.location.href.split('index=')[1];
            let size = location.href.split("size=")[1].split("#")[0];
            count = parseInt(count);
            if (e.target.matches(".next-pa")) count++;
            else count--;
            let queryString = location.hash.replace("#", "");
            const params = new URLSearchParams(queryString);
            const valueType = params.get('valueType');
            const valueMarca = params.get('valueMarca');

            $.ajax({
                type: 'GET',
                url: '/Home/ProductosAJAX',
                data: { index: count, size: size, valueType: valueType, valueMarca: valueMarca },
                success: function (data) {
                    $('#Producto-Container').html(data);
                }
            });
            if (!(valueType == null || valueMarca == null))
                location.hash = `#valueType=${valueType}&valueMarca=${valueMarca}&index=${count}`
            else
                location.hash = `#index=${count}`
            document.getElementById('Producto-Container').scrollIntoView();
        }
    }











    if (e.target.matches(".btn-filtro")) {
        if (d.getElementById("FiltrosBox").classList.contains("d-none")) {
            d.getElementById("FiltrosBox").classList.remove("d-none")
            d.querySelector(".btn-filtrado").classList.remove("d-none")
            e.target.textContent = "Ocultar Filtros"
            if (location.href.includes("valueType")) d.querySelector(".btn-desfiltrar").classList.remove("d-none")
        }
        else {
            d.getElementById("FiltrosBox").classList.add("d-none")
            d.querySelector(".btn-filtrado").classList.add("d-none")
            d.querySelector(".btn-desfiltrar").classList.add("d-none")
            e.target.textContent = "Mostrar Filtros"
        }
    }
    if (e.target.matches(".btn-desfiltrar")) {
        location.hash = "index=" + 1;
        d.querySelector(".btn-desfiltrar").classList.add("d-none")
    }

    if (e.target.matches("#filtrar-home")) {
        if (d.getElementById("FiltrosProductoBox").classList.contains("d-none")) {
            d.getElementById("FiltrosProductoBox").classList.remove("d-none")
            d.querySelector("#Buscar-home").classList.remove("d-none")
            e.target.textContent = "Ocultar Filtros"
            if (location.href.includes("valueType")) d.querySelector("#LimpiarFiltroboton").classList.remove("d-none")
        }
        else {
            d.getElementById("FiltrosProductoBox").classList.add("d-none")
            d.querySelector("#Buscar-home").classList.add("d-none")
            e.target.textContent = "Mostrar Filtros"
        }
    }

})