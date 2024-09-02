export function shiny(e){
    let img = e.target.closest("div").previousElementSibling.previousElementSibling
    .previousElementSibling.previousElementSibling.previousElementSibling
    img.src = img.src !== e.target.getAttribute("data-shiny")? 
                          e.target.getAttribute("data-shiny"):
                          e.target.getAttribute("data-sprite");
}