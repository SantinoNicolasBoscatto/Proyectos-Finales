export function desactivarActivarBotones(bd, d){
    if(bd){
        d.querySelector(".back").setAttribute("disabled","");
        d.querySelector(".next").setAttribute("disabled","");
    }
    else{
        d.querySelector(".back").removeAttribute("disabled");
        d.querySelector(".next").removeAttribute("disabled");
    }
}