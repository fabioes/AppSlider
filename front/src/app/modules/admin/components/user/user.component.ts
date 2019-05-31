import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { AttendantFormComponent } from './attendant-form/attendant-form.component';
import { Table } from 'primeng/table';
import { ConfirmModalService } from '../ui-shared/confirm-modal/confirm-modal.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-attendant',
  templateUrl: './attendant.component.html',
  styleUrls: ['./attendant.component.scss']
})
export class AttendantComponent implements OnInit {

  @ViewChild(Table) attendantTable: Table;

  user: Model.App.User;
  users: Array<Model.App.User>;
  userssGrid:Array<Model.App.User>;
  searchTerm: string;

  constructor(private userService: UserService,
    private confirmModalService: ConfirmModalService,
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
        this.userssGrid = this.users;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getAttendants();

    this.userssGrid = this.users.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.userName || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  showDialog(attendant: Model.App.User) {
    const modalRef = this.modalService.open(AttendantFormComponent, {
      backdrop: 'static'
    });

    modalRef.componentInstance.name = 'Attendant';

    modalRef.componentInstance.attendant = attendant;

    modalRef.result.then((res: Model.App.User) => {
      if (res == null) return;

      this.getAttendants();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteUser(user) {
    this.confirmModalService.confirm(
      'Confirma a deleção?',
      'Tem certeza que deseja deletar o usuário ' + user.nome + '?'
    ).then((res) => {
      if (res) {
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
    }, () => {
      return false;
    }).catch(() => {
      return false;
    });
  }

}
