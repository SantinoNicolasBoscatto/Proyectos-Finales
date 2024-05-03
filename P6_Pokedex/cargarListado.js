const d = document;
let maxID;


function desactivarActivarBotones(bd){
    if(bd){
        d.querySelector(".back").setAttribute("disabled","");
        d.querySelector(".next").setAttribute("disabled","");
    }
    else{
        d.querySelector(".back").removeAttribute("disabled");
        d.querySelector(".next").removeAttribute("disabled");
    }
}
function ocultarMostrar(back, next){     
    if(back===null) d.querySelector(".back").classList.add("none")
    else d.querySelector(".back").classList.remove("none")
    if(next===null) d.querySelector(".next").classList.add("none")
    else d.querySelector(".next").classList.remove("none")
}


export default async function loadList(version,url,back,next, object){
    try{
        desactivarActivarBotones(true);
        d.querySelector(".loader").style.display = "block";
        let $fragHTML="";
        console.log(url)
        let res = await fetch(url);
        if(!res.ok) throw new Error("Error En carga de Pokemones");
        let json = await res.json();
        back = json.previous
        next = json.next 
        object[0] = back;
        object[1] = next;
        ocultarMostrar(back, next);
        switch (version) {
            case "generation-i":
                maxID = 151;
            break;

            case "generation-ii":
                maxID = 251;
            break;

            case "generation-iii":
                maxID = 386;
            break;

            case "generation-iv":
                maxID = 493;
            break;

            case "generation-v":
                maxID = 649;
            break;

            case "generation-vi":
                maxID = 721;
            break;

            case "generation-vii":
                maxID = 809;
            break;
        
            default:
                break;
        }
        for (const el of json.results) {
            let res = await fetch(el.url);
            if(!res.ok) throw new Error("Error En carga de Pokemones");
            let json = await res.json();
            if(maxID<json.id) {
                d.querySelector(".next").classList.add("none")
                break;
            }
            let ver = "";
            for (const key in json.sprites.versions[version]) {
                ver = key;
                break;
            }
            let types = "";
            let count = 0;
            for (const key in json.types) {
                types += `<img src="./img/types/${json.types[key].type.name}.png"/>`
                count = key;
            }
            let v= "";
            for (const key in json.sprites.versions[version]) {
                v += `<button  style="background: var(--${key});" 
                        class="btn-sprite" data-sprite="${json.sprites.versions[version][key].front_default}">
                      </button>`
            }
            let number = "";
            if(json.id<10) number = `<p class="ndex">#00${json.id}</p>`
            else if(json.id<100) number = `<p class="ndex">#0${json.id}</p>`
            else number = `<p class="ndex">#${json.id}</p>`
            let name = json.name[0].toUpperCase() + json.name.slice(1)
            let pokeimg = version !== "generation-vii"?
            `<img class="pokeImage pixel" src="${json.sprites.versions[version][ver].front_default}" data-id="${json.id}"/>` : 
            `<img class="pokeImage pixel" src="${json.sprites.versions[version]["ultra-sun-ultra-moon"]
            .front_default}" data-id="${json.id}"/>`; 
            $fragHTML += 
            `<div class="carta" style="background: linear-gradient(to bottom right, 
                var(--${json.types[0].type.name}), var(--${json.types[count].type.name}));">
                ${number}
                ${pokeimg}
                <h5>${name}</h5>
                <div class="flex-type" style="margin-bottom: .8rem;">
                    ${types}
                </div>
                <div class="flex-type" style="margin-top: auto;">
                ${v}
                </div>
            </div>`
        }
        d.querySelector(".container").innerHTML = $fragHTML
        if(version === "generation-vi" || version === "generation-vii") {
            d.querySelectorAll(".pokeImage").forEach(el=>{
                el.classList.remove("pixel");
                el.style.minWidth = "100%"
            })
        }
        d.querySelector(".loader").style.display = "none";
        desactivarActivarBotones(false);
    }
    catch(err){
        console.log(err)
    }
}

