import GenerarDetalles from "./Components/Detalles.js";
import { route } from "./Helpers/Route.js";
import loadHtml from "./Helpers/loadHTML.js";
import loadList from "./Helpers/loadList.js";
import loadTypes from "./Helpers/loadTypes.js";
import { shiny } from "./Helpers/mini_funciones/shinySprite.js";
import { spriteVersion } from "./Helpers/mini_funciones/spriteVersions.js";


const d = document;
const home = "./App/Assets/html/home.html";
const gen = "./App/Assets/html/gen.html";
const api = `https://pokeapi.co/api/v2/pokemon`;
let version = localStorage.getItem("gen");
const $audio = d.querySelector(".audio");
const backNext = ["",""]
let $type;
let $buscarName;
const scrollAuto = () => window.scrollTo({top: -1,behavior: 'smooth'});
let banderaHash = true;



d.addEventListener("DOMContentLoaded", async e=>{
   let obj = await route(loadHtml, home);
   if(obj!==null) loadGen(obj.title, obj.format)
   $audio.volume = 0.2;
})

d.addEventListener("click", async e=>{
    if(e.target.matches(".gen-list li a")) {
        let title = e.target.closest("li").getAttribute("data-title");  
        version = e.target.closest("li").getAttribute("data-gen");
        loadGen(title, version);
    }
    else if(e.target.matches(".gen-list li")) {
       let title = e.target.getAttribute("data-title");
       version = e.target.getAttribute("data-gen");
       let hash = e.target.querySelector("a").href;
       loadGen(title, version,hash);
    }

    if(e.target.matches(".homeB") ||e.target.matches(".homeB *")) {
        await loadHtml(home);
        location.hash = "#/";
        route();
    }
    if((e.target.matches(".back") || e.target.matches(".back *")) && e.target.value!==null){
        scrollAuto() 
        await loadList(version, backNext[0], backNext[0], backNext[1], backNext, null, null);
        if(backNext[0] === null) e.target.classList.add("none");  
    }
    if((e.target.matches(".next") || e.target.matches(".next *")) && e.target.value!==null){
        scrollAuto() 
        await loadList(version, backNext[1], backNext[0], backNext[1], backNext, null, null);
        if(backNext[1] === null) e.target.classList.add("none"); 
    }

    if(e.target.matches(".btn-sprite")) spriteVersion(e);

    if(e.target.matches(".buscar")){
        if($buscarName.value === "" && $type.value === "0"){
            $buscarName.classList.add("borderRed")
            $type.classList.add("borderRed")
            return;
        }
        else if($buscarName.value !== "" && $type.value === "0") await loadList(version,api,backNext[0], backNext[1],{},null, $buscarName.value);
        else if($buscarName.value === "" && $type.value !== "0") await loadList(version,api,backNext[0], backNext[1],{},$type.value, null);
        else await loadList(version,api,backNext[0], backNext[1],{}, $type.value, $buscarName.value);

        d.querySelector(".limpiar").style.display = "block"
        $buscarName.classList.remove("borderRed")
        $type.classList.remove("borderRed")
    }

    if(e.target.matches(".limpiar")){
        await loadList(version, api, backNext[0], backNext[1], backNext);
        d.querySelector(".limpiar").style.display = "none"
        d.querySelector(".back").removeAttribute("disabled");
        d.querySelector(".next").removeAttribute("disabled");
        $buscarName.value = "";
        $type.selectedIndex  = 0;
    }

    if(e.target.matches(".shiny") || e.target.matches(".sh") ) shiny(e)
    
    if(e.target.matches(".cry")){
        $audio.setAttribute("src", e.target.getAttribute("data-cry"))
        $audio.play()
    }

    if(e.target.matches(".carta") || e.target.matches(".info")){
        banderaHash = false;
        let id = e.target.closest(".carta").getAttribute("data-id");
        let aux = location.hash;       
        location.href = location.href+"/"+id
        GenerarDetalles(d.querySelector("main"), id, api)
    }
});

window.addEventListener("hashchange", async e=>{
    if(banderaHash){
        let obj = await route(loadHtml, home, banderaHash);
        if(obj!==null) loadGen(obj.title, obj.format)
    }
    banderaHash = true;
})


async function loadGen(title, version,hash=null){
    if(hash) location.href = hash;
    await loadHtml(gen,title);
    $type = d.getElementById("tipo");
    $buscarName = d.getElementById("buscarName");
    await loadList(version, api, backNext[0], backNext[1], backNext, null,null);
    await loadTypes($type);
}
