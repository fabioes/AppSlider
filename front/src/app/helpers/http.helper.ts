import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, empty } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import * as _ from 'lodash';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root'
})
export class HttpHelper {

    constructor(protected http: HttpClient,
        public router: Router,
        private toastrService: ToastrService,
        //private authService : AuthService
    ) {
    }

    public HttpGet<TResult>(url: string,
        extraParams?: any,
        extraHeaders?: any): Observable<TResult> {

        let headers = new HttpHeaders({ 'Accept': 'application/json' });

        extraParams = extraParams || {};
        let params = _.pickBy(extraParams);

        let fullUrl = environment.apiConfig.baseUrl + url

        return this.http
            .get(fullUrl, {
                headers: headers,
                params: params
            }).pipe(
                map(res => this.httpMapResponse<TResult>(res)),
                catchError((res) => {
                    throw this.httpMapResponseError(res);
                    return empty();
                })
            );
    }

    public HttpPost<TResult>(url: string, payload?: any): Observable<TResult> {

        let headers = new HttpHeaders();

        if (payload instanceof FormData) {
            headers.append('Content-Type', 'multipart/form-data');
            headers.append('Accept', 'application/json');
        } else {
            headers.append('Content-Type', 'application/json');
        }

        let fullUrl = environment.apiConfig.baseUrl + url

        var payload = payload || {};

        return this.http
            .post(fullUrl, payload, { headers: headers })
            .pipe(
                map(res => this.httpMapResponse<TResult>(res)),
                catchError((res) => {
                    throw this.httpMapResponseError(res);
                    return empty();
                })
            );
    }

    public HttpPut<TResult>(url: string, payload?: any): Observable<TResult> {

        let headers = new HttpHeaders();
        if (payload instanceof FormData) {
          headers.append('Content-Type', 'multipart/form-data');
          headers.append('Accept', 'application/json');
      } else {
          headers.append('Content-Type', 'application/json');
      }


        let fullUrl = environment.apiConfig.baseUrl + url

        var payload = payload || {};

        return this.http
            .put(fullUrl, payload, { headers: headers })
            .pipe(
                map(res => this.httpMapResponse<TResult>(res)),
                catchError((res) => {

                    throw this.httpMapResponseError(res);
                    return empty();
                })
            );
    }

    public HttpPatch<TResult>(url: string, payload?: any): Observable<TResult> {

        let headers = new HttpHeaders({
            'Content-Type': 'application/json'
        });

        let fullUrl = environment.apiConfig.baseUrl + url

        var payload = payload || {};

        return this.http
            .patch(fullUrl, payload, { headers: headers })
            .pipe(
                map(res => this.httpMapResponse<TResult>(res)),
                catchError((res) => {
                    throw this.httpMapResponseError(res);
                    return empty();
                })
            );
    }

    public HttpDelete<TResult>(url: string,
        extraParams?: any[],
        extraHeaders?: any): Observable<TResult> {
        let headers = new HttpHeaders({ 'Accept': 'application/json' });

        var params = extraParams || {};
        let objParams = new HttpParams();

        _.forEach(_.keys(params), function (item: any) {
            objParams.append(item.toString(), params[item.toString()]);
        });

        let fullUrl = environment.apiConfig.baseUrl + url

        return this.http
            .delete(fullUrl, {
                headers: headers,
                params: objParams
            }).pipe(
                map((res: TResult) => {
                    return res;
                }),
                catchError((res) => {
                    throw this.httpMapResponseError(res);
                    return empty();
                })
            );
    }

    private httpMapResponse<TResult>(res: any) {
        if (!res.success) {
            let error = new HttpErrorResponse({
                error: res
            });

            this.handlingError(error);
            throw error;
        }
        return <TResult>(res)
    }

    private httpMapResponseError(error: any): any {
        console.log('Erro ao executar a operação ---> : ${error.message} ' + error.error)

        this.handlingAuth(error);

        return error;
    }
    private handlingAuth(error: HttpErrorResponse) {
        if (error.status == 401) {
            localStorage.removeItem('current_user');
            this.router.navigate(['/sessao-expirada']);
            return;
        }

    }

    private handlingError(error: HttpErrorResponse) {
        if (error.status == 401) {
            localStorage.removeItem('current_user');
            this.router.navigate(['/sessao-expirada']);
            return;
        }

        if (error != null && error.error != null && error.error.hasOwnProperty('message')) {
            let errorMessage = error.error.message.title;

            if (error.error.message.details.length > 0) {
                errorMessage = error.error.message.details.join('\r\n')
            }
            this.showError(errorMessage);
        } else {
            this.showError(error.message);
        }

    }

    private showError(errorMessage: string): any {
        errorMessage = errorMessage.replace('@', '<br /> <br />');
        this.toastrService.error('<span class="now-ui-icons ui-1_bell-53"></span> Erro ao executar a ação <br /><br />' + errorMessage, '', {
            timeOut: 4500,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-error alert-with-icon",
            positionClass: 'toast-top-right'
          });
    }

}
