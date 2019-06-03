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
  @Output() dialogCallback = new EventEmitter();
  userForm: FormGroup;
  formAttempt: Boolean

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
      senha: ['', Validators.required],
      perfil: ['', Validators.required],
      ativo: [true],
      email: ['', Validators.required],
      franquias: [''],
      roles: ['']
    });

    this.userForm.patchValue(this.user || {});
  }

  public save() {

    if (this.userForm.invalid) return;

    this.user = this.userForm.value;

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

    this.dialogCallback.emit("");
  }



}
