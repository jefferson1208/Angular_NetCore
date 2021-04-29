import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { PlanosDisponiveis } from "src/app/models/planosDisponiveis";
import { CustoPlano } from "src/app/models/custoPlano";
import { BaseService } from "../api/base.service";
import { CalculoPlano } from "src/app/models/calculoPlano";

@Injectable({
    providedIn: 'root'
})
export class CotacaoService extends BaseService {

    constructor(private http: HttpClient) { super() }

    buscarPlanosDisponiveis(): Observable<PlanosDisponiveis[]> {
        return this.http.get<PlanosDisponiveis[]>(`${super.apiUrl()}/planos/planos-disponiveis`)
            .pipe(catchError(super.serviceError));
    }


    buscarCustoPlanos(): Observable<CustoPlano[]> {
        return this.http.get<CustoPlano[]>(`${super.apiUrl()}/planos/custo-planos`)
            .pipe(catchError(super.serviceError));
    }


    calcularPrecoPlano(entity: CalculoPlano): Observable<any> {

        return this.http
            .post(`${super.apiUrl()}/planos/calcular-custo-plano`, entity)
            .pipe(map(super.extractData), catchError(super.serviceError));
    }
}