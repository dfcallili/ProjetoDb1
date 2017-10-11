import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Entrevista, EntrevistaCriar } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

@Injectable()
export class EntrevistaService {

    private _apiController = "api/entrevista";
    constructor(private http: Http) { }

    //Get Todas Entrevistas
    get() {
        var headers = new Headers();
        headers.append("If-Modified-Since", "Tue, 24 July 2017 00:00:00 GMT");
        return this.http.get(this._apiController, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Get Uma Entrevista
    getById(id: number) {
        var headers = new Headers();
        var getByIdUrl = this._apiController + '/' + id
        return this.http.get(getByIdUrl, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

    //Salvar uma nova Entrevista
    save(dtoCriar: EntrevistaCriar): Observable<string> {
        let body = JSON.stringify(dtoCriar);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this._apiController, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Houve um erro ao processar sua requisição. Tente novamente mais tarde.');
    }

}