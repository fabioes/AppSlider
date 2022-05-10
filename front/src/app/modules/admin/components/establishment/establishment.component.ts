import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { EstablishmentFormComponent } from './establishment-form/establishment-form.component';
import { PlaylistFilesComponent } from '../playlist/playlist-files/playlist-files.component';
import { PlaylistService } from '../../services/playlist/playlist.service';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-establishment',
  templateUrl: './establishment.component.html',
  styleUrls: ['./establishment.component.scss']
})
export class EstablishmentComponent implements OnInit {

  establishments: Array<Model.App.Business>;
  establishmentsGrid: Array<Model.App.Business>;
  searchTerm: string;
  playlists: Array<Model.App.Playlist>;
  playlistsGrid: Array<Model.App.Playlist>;
  file: any;
  @ViewChild('fileUpload') private fileUpload: ElementRef;
  @ViewChild(Table) dt: Table;

  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private playlistService: PlaylistService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getEstablishments();
  }

  private getEstablishments() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getByFranchiseAndType("Estabelecimento").subscribe(res => {

      this.establishments = res;
      for (let establishments of this.establishments) {
        var base64 = 'data:image/jpeg;base64,' + establishments.file;
        establishments.file = base64;
    }

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.establishmentsGrid = this.establishments;
    });
  }
  showDialog(establishment: Model.App.Business) {
    const modalRef = this.modalService.open(EstablishmentFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Estabelecimento';

    modalRef.componentInstance.establishment = establishment;

    modalRef.result.then((res: Model.App.Business) => {
      if (res == null) return;

      this.getEstablishments();

    }).catch(err => {
      console.log(err);
    });
  }

  filesDialog(business: Model.App.Business){
    const modalRef = this.modalService.open(PlaylistFilesComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist Itens';

    modalRef.componentInstance.business = business;

    modalRef.result.then((res: Model.App.Business) => {
      if (res == null) return;

      this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
  }
  private getPlaylists() {
    return this.playlistService.getAllPlaylists().subscribe(res => {
      this.playlists = res;
      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.playlistsGrid = this.playlists;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getEstablishments();

    this.establishmentsGrid = this.establishments.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
    this.dt.reset();
  }

  deleteFranchise(establishment) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o Estabelecimento ' + establishment.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.deleteBusiness(establishment.id).subscribe(() => {
          this.getEstablishments();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Estabelecimento <b> ' + establishment.nome + ' </b> foi deletado com sucesso.', '', {
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

  switchActive(establishment){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (establishment.ativo ? 'desativar' : 'ativar') + ' o estabelecimento ' + establishment.nome + '?',
      header: 'Confirma a ' + (establishment.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.switchActive(establishment.id).subscribe(() => {
          this.getEstablishments();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Estabelecimento <b> ' + establishment.nome + ' </b> foi ' + (establishment.ativo ? 'desativado' : 'ativado') + ' com sucesso.', '', {
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
