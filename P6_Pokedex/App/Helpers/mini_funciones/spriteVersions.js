export function spriteVersion(e){
    let img = e.target.closest("div").previousElementSibling.previousElementSibling.previousElementSibling
    img.setAttribute("src", e.target.getAttribute("data-sprite"))
}