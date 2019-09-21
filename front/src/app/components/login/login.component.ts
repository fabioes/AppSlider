import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../services/global/global.service';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  private formSubmitAttempt: boolean;
  public notLogged: boolean;
  toggled = false;

  constructor(private fb: FormBuilder,
    private globalService: GlobalService,
    private authService: AuthService,
    private router: Router) {

    authService.isLoggedIn.subscribe(item => {
      if (item)
        this.router.navigate(['/adm/welcome']);
      else
        this.notLogged = true;
    });
  }

  ngOnInit() {
    this.loginForm = this.fb.group({
      login: ['', Validators.required],
      senha: ['', Validators.required]
    });
  }
toggle(){

}
  loginSubmit($event) {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value);
    }

    this.formSubmitAttempt = true;
  }

  isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.loginForm, this.formSubmitAttempt);
  }
}
