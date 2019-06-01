import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user/user.service';


@Component({
  selector: 'user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  @Input()  modalDialog: Model.App.User;
  @Output() dialogCallback = new EventEmitter();
  userForm: FormGroup;
  formAttempt: Boolean

  constructor(private fb: FormBuilder,
    private globalService: GlobalService,
    private userService: UserService,
    private toastrService: ToastrService) { }

  ngOnInit() {
   
    this.userForm = this.fb.group({
      id: [this.modalDialog ? this.modalDialog.id : ''],
      nome: [this.modalDialog ? this.modalDialog.nome : '', Validators.required],
      login: [this.modalDialog ? this.modalDialog.login : '', Validators.required]
    });

  }

  public save() {

    if (this.userForm.invalid) return;

    this.modalDialog = this.userForm.value;

    if (this.modalDialog.id) {
      this.userService.updateUser(this.modalDialog).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.userService.createUser(this.modalDialog).subscribe(res => this.callbackAction('criado', res));
    }

    this.formAttempt = true;
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.userForm,);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O atendente <b> ' + res.name + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.dialogCallback.emit("");
  }



}
