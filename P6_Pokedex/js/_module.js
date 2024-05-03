import loadHtml from "./cargaHTML.js";
import loadList from "./cargarListado.js";
import loadTypes from "./cargarTipos.js";


const d = document;
const home = "./html/home.html";
const api = `https://pokeapi.co/api/v2/pokemon`;
let version = "";
let bd = true;
const $audio = d.querySelector(".audio");
$audio.volume = 0.2;

const backNext = ["",""]

function scrollAuto(){
    window.scrollTo({top: -1,behavior: 'smooth'});
}

// CARGA LOS POKEMONES DE LA POKE-API DE CADA GEN


d.addEventListener("DOMContentLoaded", async e=>{
   await loadHtml(home, backNext[0], backNext[1])
})
d.addEventListener("click", async e=>{
    if(e.target.matches(".gen-list li a")) {
        e.preventDefault();
        let href = e.target.getAttribute("href");
        await loadHtml(href, backNext[0], backNext[1]);
        version = e.target.closest("li").getAttribute("data-gen");
        await loadList(version, api, backNext[0], backNext[1], backNext, null,null);
        await loadTypes(d.getElementById("tipo"))
    }
    else if(e.target.matches(".gen-list li")) {
       let href = e.target.querySelector("a").getAttribute("href");
       await loadHtml(href, backNext[0], backNext[1]);
       version = e.target.getAttribute("data-gen");
       await loadList(version, api, backNext[0], backNext[1], backNext, null, null);
       await loadTypes(d.getElementById("tipo"))
    }
    if(e.target.matches(".homeB") ||e.target.matches(".homeB *")) await loadHtml(home, backNext[0], backNext[1]);
    if((e.target.matches(".back") || e.target.matches(".back *")) && e.target.value!==null){
        
        await loadList(version, backNext[0], backNext[0], backNext[1], backNext, null, null);
        if(backNext[0] === null) e.target.classList.add("none");  
        scrollAuto() 
    }
    if((e.target.matches(".next") || e.target.matches(".next *")) && e.target.value!==null){
        scrollAuto() 
        await loadList(version, backNext[1], backNext[0], backNext[1], backNext, null, null);
        if(backNext[1] === null) e.target.classList.add("none"); 
        
    }
    if(e.target.matches(".btn-sprite")){
        bd = true
        let img = e.target.closest("div").previousElementSibling.previousElementSibling.previousElementSibling
        img.setAttribute("src", e.target.getAttribute("data-sprite"))
    }

    if(e.target.matches(".buscar")){
        if(d.getElementById("buscarName").value === "" && d.getElementById("tipo").value === "0"){
            d.getElementById("buscarName").classList.add("borderRed")
            d.getElementById("tipo").classList.add("borderRed")
            return;
        }
        else if(d.getElementById("buscarName").value !== "" && d.getElementById("tipo").value === "0"){
            await loadList(version,api,backNext[0], backNext[1],{},null, d.getElementById("buscarName").value);
            d.querySelector(".limpiar").style.display = "block"
        }
        else if(d.getElementById("buscarName").value === "" && d.getElementById("tipo").value !== "0"){
            await loadList(version,api,backNext[0], backNext[1],{},d.getElementById("tipo").value, null);
            d.querySelector(".limpiar").style.display = "block"
        }
        else{
            await loadList(version,api,backNext[0], backNext[1],{}, d.getElementById("tipo").value, 
                                    d.getElementById("buscarName").value)
            d.querySelector(".limpiar").style.display = "block"
        }
        d.getElementById("buscarName").classList.remove("borderRed")
        d.getElementById("tipo").classList.remove("borderRed")
    }

    if(e.target.matches(".limpiar")){
        await loadList(version, api, backNext[0], backNext[1], backNext);
        d.querySelector(".limpiar").style.display = "none"
        d.querySelector(".back").removeAttribute("disabled");
        d.querySelector(".next").removeAttribute("disabled");
        d.getElementById("buscarName").value = "";
        d.getElementById("tipo").selectedIndex  = 0;
    }

    if(e.target.matches(".shiny")){
        let img = e.target.closest("div").previousElementSibling.previousElementSibling
        .previousElementSibling.previousElementSibling.previousElementSibling
        if(bd) {
            img.setAttribute("src", e.target.getAttribute("data-shiny"))
            bd = false
        }
        else{
            img.setAttribute("src", e.target.getAttribute("data-sprite"))
            bd = true
        }
    }

    if(e.target.matches(".cry")){
        $audio.setAttribute("src", e.target.getAttribute("data-cry"))
        $audio.play()
        
    }

});

