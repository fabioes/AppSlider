import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user/user.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import * as _ from 'lodash';


@Component({
  selector: 'user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  @Input() user: Model.App.User;
  @Input() roles: Array<Model.App.Role>;
  userForm: FormGroup;
  rolesList: Array<Model.App.Role>;

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

    let usingRoles = _.compact(_.reduce(this.roles, (result, role) => (result || []).concat((role || {}).roles),[]));
    let userRoles = ((this.user || <Model.App.User>{}).roles || '').split(',');
    this.rolesList = this.roles.filter(h => userRoles.filter(hsm => hsm == h.id).length > 0 || usingRoles.filter(eh => eh === h.id).length == 0);

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
  }

  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.userForm);
  }

  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O usuário <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

}