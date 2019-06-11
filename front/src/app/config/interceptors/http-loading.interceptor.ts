import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { LoadingBarService } from '../../services/shared/ui/loading-bar.service';

@Injectable({
    providedIn: 'root'
})
export class HttpLoadingInterceptor implements HttpInterceptor {

    private cont: number = 0;
    constructor(private loadingBarService: LoadingBarService) { }

    intercept(req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
        debugger;
        this.cont++;
        if (this.cont == 1)
            this.loadingBarService.showLoadingBar();

        let handleReq = next.handle(req);

        if (!handleReq)
            return;

        return handleReq.pipe(map(event => {
            debugger;
            if (event instanceof HttpResponse) { //<--only when event is a HttpRespose
                this.cont--;
                if (this.cont == 0)
                    this.loadingBarService.hideLoadingBar();
            }
            return event;
        }),
            catchError((err: any) => { //If an error happens, this.contador-- too
                this.cont--;
                this.loadingBarService.hideLoadingBar();
                throw err;
            })
        );
    }
}