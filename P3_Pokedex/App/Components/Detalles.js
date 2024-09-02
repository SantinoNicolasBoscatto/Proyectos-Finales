export default async function GenerarDetalles(main,id, api){
    
    try {
        let res = await fetch(api+"/"+id)
        if(!res.ok) throw new Error("Error En carga de Pokemones");
        let json = await res.json();
        let version = localStorage.getItem("gen");
        let v= "";
        let ds;
        let bd = true;
        for (const key in json.sprites.versions[version]) {
            if(version !== "generation-i" && version !== "generation-ii"){
                v += `<button  style="background: var(--${key});" 
                class="btn-sprite" data-sprite="${json.sprites.versions[version][key].front_default}">
                </button>`
                if(bd){
                    ds = json.sprites.versions[version][key].front_default;
                    bd = false
                }
            }
            else{
                v += `<button  style="background: var(--${key});" 
                class="btn-sprite" data-sprite="${json.sprites.versions[version][key].front_transparent}">
                </button>`
                if(bd){
                    ds = json.sprites.versions[version][key].front_transparent;
                    bd = false
                }
            }
        }

        main.innerHTML = `
        <div class="details-container">
            <div class="details-item ds">
                <img src=
                "${ds}" 
                class="ImgDetails">
            </div>
            <div class="details-item">
                <div class="center-flex">
                    ${v}
                </div>
            </div>
        </div>
        `;
    } 
    catch(err){
        console.log(err)
    }
}