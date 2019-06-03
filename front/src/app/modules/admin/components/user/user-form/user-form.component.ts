import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user/user.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  @Input() user: Model.App.User;
  userForm: FormGroup;
  formAttempt: Boolean;
  profiles = [{
    name: 'Administrador',
    value: 'admin'
  },
  {
    name: 'Usuário',
    value: 'user'
  }];

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private userService: UserService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.userForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      login: ['', Validators.required],
      senha: (this.user || <Model.App.User>{}).id ? [''] : ['', Validators.required],
      perfil: ['', Validators.required],
      ativo: [true],
      email: ['', Validators.required],
      franquias: [''],
      roles: ['']
    });

    this.userForm.patchValue(this.user || {});

    if ((this.user || <Model.App.User>{}).id)
      this.userForm.get('perfil').setValue(this.profiles.filter(f => f.value == this.user.perfil)[0]);
  }

  public save() {

    if (this.userForm.invalid) return;

    this.user = this.userForm.value;
    this.user.perfil = (<any>this.user.perfil).value;

    if (this.user.id) {
      this.userService.updateUser(this.user).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.userService.createUser(this.user).subscribe(res => this.callbackAction('criado', res));
    }

    this.formAttempt = true;
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.userForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O atendente <b> ' + res.name + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }



}
