import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { MidiafoneFormComponent } from './midiafone-form/midiafone-form.component';
import { PlaylistFilesComponent } from '../playlist/playlist-files/playlist-files.component';


@Component({
  selector: 'app-midiafone',
  templateUrl: './midiafone.component.html',
  styleUrls: ['./midiafone.component.scss']
})
export class MidiafoneComponent implements OnInit {

  midiafone: Array<Model.App.Business>;
  midiafoneGrid: Array<Model.App.Business>;
  searchTerm: string;

  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getMidiafone();
  }

  private getMidiafone() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getByFranchiseAndType("Midiafone").subscribe(res => {

      this.midiafone = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.midiafoneGrid = this.midiafone;

        console.log(this.midiafoneGrid);
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getMidiafone();

    this.midiafoneGrid = this.midiafone.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 );
  }

  showDialog(midiafone: Model.App.Business) {
    const modalRef = this.modalService.open(MidiafoneFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Midiafone';

    modalRef.componentInstance.midiafone = midiafone;

    modalRef.result.then((res: Model.App.Business) => {
      if (res == null) return;

      this.getMidiafone();

    }).catch(err => {
      console.log(err);
    });
  }
  filesDialog(midiafone: Model.App.Business){
    const modalRef = this.modalService.open(PlaylistFilesComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist Itens';

    modalRef.componentInstance.business = midiafone;

    modalRef.result.then((res: Model.App.Playlist) => {
      if (res == null) return;

      //this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
  }
  deleteFranchise(midiafone) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o Anunciante ' + midiafone.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.deleteBusiness(midiafone.id).subscribe(() => {
          this.getMidiafone();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Anunciante <b> ' + midiafone.nome + ' </b> foi deletado com sucesso.', '', {
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

  switchActive(midiafone){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (midiafone.ativo ? 'desativar' : 'ativar') + ' o estabelecimento ' + midiafone.nome + '?',
      header: 'Confirma a ' + (midiafone.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.switchActive(midiafone.id).subscribe(() => {
          this.getMidiafone();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Anunciante <b> ' + midiafone.nome + ' </b> foi ' + (midiafone.ativo ? 'desativado' : 'ativado') + ' com sucesso.', '', {
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
