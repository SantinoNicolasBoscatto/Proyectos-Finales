

export async function route(cbHome,home,bd=true){
        let {hash} = location;
        let obj = null;
        if(!hash || hash === "#/") {
            await cbHome(home);
            return;
        }
        let format = hash.slice(2)
        let posicion = format.indexOf("/");
        if(posicion != -1){
            format = format.substring(0, posicion);
        }
        
        const title = document.querySelector(`[data-gen="${format}"]`).getAttribute("data-title")
        obj = {format,title}
        localStorage.setItem("gen", format);
        return obj;
}

