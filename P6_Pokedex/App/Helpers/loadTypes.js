
export default async function loadTypes(select){
    try{
        let res = await fetch("https://pokeapi.co/api/v2/type");
        if(!res.ok) throw new Error("Error Carga Tipos");
        let json = await res.json();
        let $fragHTML = `<option value="0">Filtro Por tipo</option>`;
        json.results.forEach((el, index) => {
            let name = el.name[0].toUpperCase() + el.name.slice(1);
            $fragHTML += `<option value="${name.toLowerCase()}">${name}</option>`;
        });
        select.innerHTML = $fragHTML;
    } 
    catch(err) {
        alert(err)
    }
}