import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/user/user.service';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { UserFormComponent } from './user-form/user-form.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserResetPasswordComponent } from './user-reset-password/user-reset-password.component';
import { AuthService } from '../../../../services/auth/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  users: Array<Model.App.User>;
  usersGrid: Array<Model.App.User>;
  searchTerm: string;
  roles: Array<Model.App.Role>;
  franchises: Array<Model.App.UserFranchise>;

  constructor(private userService: UserService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService,
    private authService: AuthService) { }

  ngOnInit() {

    this.userService.getAllRoles().subscribe(resR => {
      this.roles = resR;
      this.authService.getFranchisesToken().subscribe(resT => {
        this.franchises = resT;
        this.getUsers();
      });
    });
  }

  private getUsers() {
    //TODO: make retrive routines for Attendant by API request

    return this.userService.getAllUsers().subscribe(res => {

      this.users = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.usersGrid = this.users;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getUsers();

    this.usersGrid = this.users.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.login || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  showDialog(user: Model.App.User) {
    const modalRef = this.modalService.open(UserFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Usuário';

    modalRef.componentInstance.user = user;
    modalRef.componentInstance.roles = this.roles;
    modalRef.componentInstance.franchises = this.franchises;

    modalRef.result.then((res: Model.App.User) => {
      if (res == null) return;

      this.getUsers();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteUser(user) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o usuário ' + user.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.userService.deleteUser(user.id).subscribe(() => {
          this.getUsers();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O usuário <b> ' + user.nome + ' </b> foi deletado com sucesso.', '', {
            timeOut: 3500,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-success alert-with-icon",
            positionClass: 'toast-top-right'
          });
        });
      }
    });
  }

  switchActive(user) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (user.ativo ? 'desativar' : 'ativar') + ' o usuário ' + user.nome + '?',
      header: 'Confirma a ' + (user.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.userService.switchActive(user.id).subscribe(() => {
          this.getUsers();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O usuário <b> ' + user.nome + ' </b> foi ' + (user.ativo ? 'desativado' : 'ativado') + ' com sucesso.', '', {
            timeOut: 3500,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-success alert-with-icon",
            positionClass: 'toast-top-right'
          });
        });
      }
    });
  }

  resetPassword(user) {
    const modalRef = this.modalService.open(UserResetPasswordComponent, {
      backdrop: 'static',
      //size: 'lg'
    });

    modalRef.componentInstance.name = 'Usuário';

    modalRef.componentInstance.user = user;

    modalRef.result.then((res: Model.App.User) => {
      if (res == null) return;

      this.getUsers();

    }).catch(err => {
      console.log(err);
    });
  }
}
