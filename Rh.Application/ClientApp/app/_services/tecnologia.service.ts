import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Tecnologia } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

@Injectable()
export class TecnologiaService {

    private _apiController = "api/tecnologia";
    constructor(private http: Http) { }

    //Get Todas Tecnologias
    get() {
        var headers = new Headers();
        headers.append("If-Modified-Since", "Tue, 24 July 2017 00:00:00 GMT");
        return this.http.get(this._apiController, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Get Uma Tecnologia
    getById(id: number) {
        var headers = new Headers();
        var getByIdUrl = this._apiController + '/' + id
        return this.http.get(getByIdUrl, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Salvar um novo Tecnologia
    save(tecnologia: Tecnologia): Observable<string> {
        let body = JSON.stringify(tecnologia);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Atualizar um tecnologia específico
    update(tecnologia: Tecnologia): Observable<string> {
        let body = JSON.stringify(tecnologia);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    //Remover uma tecnologia
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