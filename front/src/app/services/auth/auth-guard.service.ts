import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private router: Router,
        private authService: AuthService) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean> {

        return this.authService.isLoggedIn.pipe(take(1), map((isLoggedIn: boolean) => {
            if (!isLoggedIn) {
                this.router.navigate(['/login']);
                return false;
            } else {
                this.authService.getRolesPermissions().subscribe(roles => {
                    var role = (next.data || {}).role;
                    if (role && roles.indexOf(role || "") < 0) {
                        this.router.navigate(['/acesso-negado']); 
                        return;
                    }
                    else
                        return true;
                });
            }
            return true;
        }));
    }
}