import { Observable } from "rxjs";

export interface IServicioCrud<TDTO, TCreacionDTO, TUpdateDTO>{
    get() : Observable<TDTO[]>
    create(TCreate: TCreacionDTO): Observable<any>
    update(id: number, TUpdate: TUpdateDTO) : Observable<any>
    delete(id: number): Observable<any>  
}