import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './modules/shared/components.module';

import { AppComponent } from './app.component';

import { AdminComponent } from './modules/admin/admin.component';
import { LoginComponent } from './components/login/login.component';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { ExpiredSessionComponent } from './components/expired-session/expired-session.component';
import { LogoutComponent } from './components/logout/logout.component';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { HttpLoadingInterceptor } from './config/interceptors/http-loading.interceptor';
import { AuthInterceptor } from './config/interceptors/auth.interceptor';

/** prime ng modules */
import { ProgressBarModule } from 'primeng/progressbar';
/** prime ng modules end */
import { NgxPasswordToggleModule } from 'ngx-password-toggle';
import { PasswordModule } from 'primeng/password';

import {InputTextModule} from 'primeng/inputtext';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,
    ToastrModule.forRoot(),
    //prime ng
    ProgressBarModule,
    NgxPasswordToggleModule,
    PasswordModule,
    InputTextModule
  ],
  declarations: [
    AppComponent,
    AdminComponent,
    LoginComponent,
    LogoutComponent,
    AccessDeniedComponent,
    ExpiredSessionComponent
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: HttpLoadingInterceptor,
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }, ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
