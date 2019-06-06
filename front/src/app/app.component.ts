import { Component, NgZone } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { Router } from '@angular/router';
import { LoadingBarService } from './services/shared/ui/loading-bar.service';
import { BehaviorSubject } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  showLoadingBar: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);

  constructor(authService: AuthService,
    ngZone: NgZone,
    router: Router,
    private loadingBarService: LoadingBarService) {
    authService.isLoggedIn.subscribe(res => {
      if (!res)
        ngZone.run(() => { router.navigate(['']); });
    });

    this.loadingBarService.showBarChange.subscribe(res => {
      setTimeout(() => this.showLoadingBar.next(res));
    });
  }
}
