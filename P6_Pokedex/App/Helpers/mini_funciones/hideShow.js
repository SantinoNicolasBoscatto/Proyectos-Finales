export function ocultarMostrar(back, next, d){     
    if(back===null) d.querySelector(".back").classList.add("none")
    else d.querySelector(".back").classList.remove("none")
    if(next===null) d.querySelector(".next").classList.add("none")
    else d.querySelector(".next").classList.remove("none")
}