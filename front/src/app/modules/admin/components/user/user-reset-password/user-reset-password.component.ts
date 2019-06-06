import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user/user.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'user-reset-password',
  templateUrl: './user-reset-password.component.html',
  styleUrls: ['./user-reset-password.component.scss']
})
export class UserResetPasswordComponent implements OnInit {

  @Input() user: Model.App.User;
  resetPasswordForm: FormGroup;
  

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private userService: UserService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.resetPasswordForm = this.fb.group({
      id: [this.user.id],
      senha: ['', Validators.required]
     
    });
  }

  public resetPassword() {

    if (this.resetPasswordForm.invalid) return;

    let model = this.resetPasswordForm.value;
    
      this.userService.resetUserPassword(model).subscribe(res => this.callbackAction(res));
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.resetPasswordForm);
  }


  public callbackAction(res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> A senha do usuario <b> ' + res.nome + ' </b> foi resetada com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

}
