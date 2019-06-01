import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/user/user.service';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  @ViewChild(Table) attendantTable: Table;

  modalDialog: Model.App.User;
  users: Array<Model.App.User>;
  usersGrid: Array<Model.App.User>;
  searchTerm: string;
  showDialog: Boolean = false;

  constructor(private userService: UserService,
    private confirmationService: ConfirmationService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAttendants();
  }

  private getAttendants() {
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
      this.getAttendants();

    this.usersGrid = this.users.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.login || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  // showDialog(attendant: Model.App.User) {
  //   const modalRef = this.modalService.open(AttendantFormComponent, {
  //     backdrop: 'static'
  //   });

  //   modalRef.componentInstance.name = 'Attendant';

  //   modalRef.componentInstance.attendant = attendant;

  //   modalRef.result.then((res: Model.App.User) => {
  //     if (res == null) return;

  //     this.getAttendants();

  //   }).catch(err => {
  //     console.log(err);
  //   });
  // }

  deleteUser(user) {

    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o usuário ' + user.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.userService.deleteUser(user.id).subscribe(() => {
          this.getAttendants();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Atendente <b> ' + user.nome + ' </b> foi deletado com sucesso.', '', {
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

  public teste($event){
    this.showDialog = false;
  }

}
