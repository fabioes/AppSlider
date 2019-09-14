import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { CuriositiesFormComponent } from './curiosities-form/curiosities-form.component';
import { PlaylistFilesComponent } from '../playlist/playlist-files/playlist-files.component';


@Component({
  selector: 'app-curiosities',
  templateUrl: './curiosities.component.html',
  styleUrls: ['./curiosities.component.scss']
})
export class CuriositiesComponent implements OnInit {

  curiosities: Array<Model.App.Business>;
  curiositiesGrid: Array<Model.App.Business>;
  searchTerm: string;

  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getcuriosities();
  }

  private getcuriosities() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getByFranchiseAndType("Curiosidades").subscribe(res => {

      this.curiosities = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.curiositiesGrid = this.curiosities;

        console.log(this.curiositiesGrid);
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getcuriosities();

    this.curiositiesGrid = this.curiosities.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 );
  }

  showDialog(curiosities: Model.App.Business) {
    const modalRef = this.modalService.open(CuriositiesFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Anunciante';

    modalRef.componentInstance.curiosities = curiosities;

    modalRef.result.then((res: Model.App.Business) => {
      if (res == null) return;

      this.getcuriosities();

    }).catch(err => {
      console.log(err);
    });
  }
  filesDialog(curiosities: Model.App.Business){
    const modalRef = this.modalService.open(PlaylistFilesComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist Itens';

    modalRef.componentInstance.business = curiosities;

    modalRef.result.then((res: Model.App.Playlist) => {
      if (res == null) return;

      //this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
  }
  deleteFranchise(curiosities) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o Anunciante ' + curiosities.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.deleteBusiness(curiosities.id).subscribe(() => {
          this.getcuriosities();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Anunciante <b> ' + curiosities.nome + ' </b> foi deletado com sucesso.', '', {
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

  switchActive(curiosities){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (curiosities.ativo ? 'desativar' : 'ativar') + ' o estabelecimento ' + curiosities.nome + '?',
      header: 'Confirma a ' + (curiosities.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.switchActive(curiosities.id).subscribe(() => {
          this.getcuriosities();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Anunciante <b> ' + curiosities.nome + ' </b> foi ' + (curiosities.ativo ? 'desativado' : 'ativado') + ' com sucesso.', '', {
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

}
