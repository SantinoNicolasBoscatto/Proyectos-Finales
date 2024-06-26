const d = document;
const home = "./App/Assets/html/home.html";
export default async function loadHtml(href, title){
    try {
        let res = await fetch(href, {
            method: "GET",
            headers: {
                "content-type": "text/html"
            }
        })
        if(!res.ok) throw new Error("Error En la Carga de la Generacion")
        let html = await res.text()
        d.querySelector("main").innerHTML = html;
        if (href !== home) {
            d.querySelector(".homeB").classList.remove("notvisible");
            d.querySelector("main").insertAdjacentHTML("afterbegin",`<h2 id="titleGen">${title}</h2>`)
        }
        else d.querySelector(".homeB").classList.add("notvisible");
    } 
    catch(err){
        alert(err)
    }
};