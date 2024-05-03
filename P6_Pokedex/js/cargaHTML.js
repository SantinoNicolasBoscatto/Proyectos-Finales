const d = document;
const home = "./html/home.html";
export default async function loadHtml(href){
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
        if (href !== home) d.querySelector(".homeB").classList.remove("notvisible");
        else d.querySelector(".homeB").classList.add("notvisible");
    } 
    catch(err){
        alert(err)
    }
};