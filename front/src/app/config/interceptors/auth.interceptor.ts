import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth/auth.service";
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router, private authService: AuthService) { }

    intercept(req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        if (req.url.indexOf(environment.apiConfig.apiRoutes.login.default) >= 0) {
            return next.handle(req);
        }
debugger;
        let token = this.authService.getOAuthToken();

        if (token) {
            const cloned = req.clone({
                headers: req.headers.set("Authorization",
                    "Bearer " + token)
            });

            return next.handle(cloned);
        }
        else {
            this.router.navigate(['/login']);
        }        
    }
}