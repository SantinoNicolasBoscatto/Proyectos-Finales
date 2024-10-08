export function actualizarPuntos(lista: any) {
	let pointsDescending = 35;
  	lista.forEach((elemento: any) => {
		const Posicion = parseInt(elemento.Finish)
		let nuevosPuntos = 1;	
		if(Posicion === 1) nuevosPuntos = 40	
		else if(Posicion<36) 
		{
			nuevosPuntos = pointsDescending;
			pointsDescending -= 1;
		}
		elemento.Puntos = nuevosPuntos.toString();
	});
		return lista;
}

export function reemplazarCaracteresEspeciales(json: string) {
	return JSON.parse(json, (key, value) => {
		if (typeof value === 'string') {
		return value.replace(/\n/g, '').replace(/\t/g, '').replace(/↵/g, '');
		}
		return value;
	});
}