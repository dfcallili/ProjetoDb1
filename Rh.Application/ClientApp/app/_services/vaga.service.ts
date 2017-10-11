import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Vaga } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

@Injectable()
export class VagaService {

    private _apiController = "api/vaga";
    constructor(private http: Http) { }

    //Get Todas Vagas
    get() {
        var headers = new Headers();
        headers.append("If-Modified-Since", "Tue, 24 July 2017 00:00:00 GMT");
        return this.http.get(this._apiController, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Get Uma Vaga
    getById(id: number) {
        var headers = new Headers();
        var getByIdUrl = this._apiController + '/' + id
        return this.http.get(getByIdUrl, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    getTecnologiaByVagaId(id: number) {
        var headers = new Headers();
        var getByIdUrl = this._apiController + '/GetTecnologiaByVagaId/' + id
        return this.http.get(getByIdUrl, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Salvar uma nova Vaga
    save(dtoCriar: Vaga): Observable<string> {
        let body = JSON.stringify(dtoCriar);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Atualizar uma Vaga específica
    update(dtoAtualizar: Vaga): Observable<string> {
        let body = JSON.stringify(dtoAtualizar);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Remover uma Vaga
    delete(id: number): Observable<string> {
        var deleteUrl = this._apiController + '/' + id

        return this.http.delete(deleteUrl)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Atualizar uma Vaga específica
    calcularClassificao(dtoAtualizar: Vaga): Observable<any> {
        let body = JSON.stringify(dtoAtualizar);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        var calcularClassificaoUrl = this._apiController + '/calcularClassificacao';
        return this.http.post(calcularClassificaoUrl, body, options)
            .map(response => <any>(<Response>response).json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Houve um erro ao processar sua requisição. Tente novamente mais tarde.');
    }

}