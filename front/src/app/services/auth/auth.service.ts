import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import * as jwtHelper from 'jwt-decode';
import { HttpHelper } from '../../helpers/http.helper';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private loggedIn = new BehaviorSubject<boolean>(false);
    private roles = new BehaviorSubject<any>([]);

    get isLoggedIn() {
        let login = localStorage.getItem("current_user");
        if (login) {
            this.loggedIn.next(true);
        } else {
            this.loggedIn.next(false);
        }
        return this.loggedIn.asObservable();
    }

    constructor(
        private router: Router,
        private httpHelper: HttpHelper
    ) { }

    public login(loginRequest: Model.Core.LoginRequest) {
        this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.Core.Login>>(environment.apiConfig.urls.login, loginRequest).subscribe((res) => {
            if (res.item.perfil_usuario == 'admin') {
                localStorage.setItem('current_user', JSON.stringify(res.item));
                this.loggedIn.next(true);
                this.router.navigate(['/adm/welcome']);
            } else {
                this.router.navigate(['/acesso-negado']);
            }
        });
    }

    public logout() {
        localStorage.removeItem("current_user");
        setTimeout(() => {
            this.loggedIn.next(false);
            this.router.navigate(['']);
        });

    }

    public getOAuthToken(): any {
        let login = localStorage.getItem("current_user");
        return login ? (<Model.Core.Login>JSON.parse(login)).token : null;
    }

    public getLoginObject(): Model.Core.LoginClaims {
        let login = localStorage.getItem("current_user");
        return login ? (<Model.Core.LoginClaims>jwtHelper(login)) : null;
    }

    public getTokenUsername(): string {
        return (this.getLoginObject() || <Model.Core.LoginClaims>{}).unique_name;
    }

    get rolesPermissions() {
        var claims = this.getLoginObject();
        this.roles.next((<any>(claims || {})).roles || []);

        return this.roles.asObservable();
    }

    redirectToRouteAfterLoginInit() {
        let token = this.getOAuthToken();
        if (token) {
            let redirectUrl = localStorage.getItem('afterReloginRoute');
            localStorage.removeItem('afterReloginRoute');
            this.router.navigate([redirectUrl]);
            return;
        } else {
            this.router.navigate(['/sessao-expirada']);
        }
    }
}