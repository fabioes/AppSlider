import { Component, NgZone } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(authService: AuthService, ngZone: NgZone, router: Router) {
    authService.isLoggedIn.subscribe(res => {
      if (!res)
        ngZone.run(() => { router.navigate(['']); });
    })
  }
}
