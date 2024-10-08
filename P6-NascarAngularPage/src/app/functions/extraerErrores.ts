export function extraerErrores(obj: any) : string[]{
    const err = obj.error.errors;
    let mensajesDeError : string[] = [];
    for (const key in err) {
        let campo = key;
        const mensajesConCampos = err[key].map((msg:string) => `${campo}: ${msg}`);
        mensajesDeError = mensajesDeError.concat(mensajesConCampos);
    }
    return mensajesDeError;
}
