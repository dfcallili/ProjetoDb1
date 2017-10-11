import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Candidato } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

@Injectable()
export class CandidatoService {

    private _apiController = "api/candidato";
    constructor(private http: Http) { }

    //Get Todos Candidatos
    get() {
        var headers = new Headers();
        headers.append("If-Modified-Since", "Tue, 24 July 2017 00:00:00 GMT");
        var getCandidato = this._apiController;
        return this.http.get(getCandidato, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Get Um Candidato
    getById(id: number) {
        var headers = new Headers();
        var getByIdUrl = this._apiController + '/' + id
        return this.http.get(getByIdUrl, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Salvar um novo Candidato
    save(dtoCriar: Candidato): Observable<string> {
        let body = JSON.stringify(dtoCriar);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Atualizar um candidato específico
    update(dtoAtualizar: Candidato): Observable<string> {
        let body = JSON.stringify(dtoAtualizar);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Remover um candidato
    delete(id: number): Observable<string> {
        var deleteUrl = this._apiController + '/' + id

        return this.http.delete(deleteUrl)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Houve um erro ao processar sua requisição. Tente novamente mais tarde.');
    }

}