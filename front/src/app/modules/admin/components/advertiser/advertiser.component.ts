import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { AdvertiserFormComponent } from './advertiser-form/advertiser-form.component';
import { PlaylistFilesComponent } from '../playlist/playlist-files/playlist-files.component';
import { Table } from 'primeng/table';
import { LazyLoadEvent } from 'primeng/api';

@Component({
  selector: 'app-advertiser',
  templateUrl: './advertiser.component.html',
  styleUrls: ['./advertiser.component.scss']
})
export class AdvertiserComponent implements OnInit {
  @ViewChild(Table) dt: Table;
  advertisers: Array<Model.App.Business>;
  advertisersGrid: Array<Model.App.Business>;
  searchTerm: string;
  totalRecords: number;
  loading: boolean;
  $event: LazyLoadEvent;

  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    //this.loadAdvertisers(null);

  }

  private getAdvertisers() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getByFranchiseAndType("Anunciante").subscribe(res => {

      this.advertisers = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.advertisersGrid = this.advertisers;
    });
  }
  loadAdvertisers(event: LazyLoadEvent) {
    this.businessService.getAdvertiserCount("Anunciante").subscribe(res => {
      this.totalRecords = res;
    });
    
    setTimeout(() => {
      this.businessService.getByFranchiseAndTypeEvent("Anunciante",event.first).subscribe(res => {
        this.advertisers = res;
          this.$event = event;
          this.loading = false;
          if (this.searchTerm)
          this.searchSubmit(null);
        else
          this.advertisersGrid = this.advertisers;
      })
  }, 1000);
}
  searchSubmit($event) {

    if (!this.searchTerm)
      this.loadAdvertisers($event);

    this.advertisersGrid = [...this.advertisers.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0)];
    
  }



  showDialog(advertiser: Model.App.Business) {
    const modalRef = this.modalService.open(AdvertiserFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Anunciante';

    modalRef.componentInstance.advertiser = advertiser;

    modalRef.result.then((res: Model.App.Business) => {
      if (res == null) return;
      
      this.loadAdvertisers(this.$event);

    }).catch(err => {
      console.log(err);
    });
  }
  filesDialog(advertiser: Model.App.Business) {
    const modalRef = this.modalService.open(PlaylistFilesComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist Itens';

    modalRef.componentInstance.business = advertiser;

    modalRef.result.then((res: Model.App.Playlist) => {
      if (res == null) return;

      //this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
  }
  deleteFranchise(advertiser) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o Anunciante ' + advertiser.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.deleteBusiness(advertiser.id).subscribe(() => {
         
          this.dt.reset();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Anunciante <b> ' + advertiser.nome + ' </b> foi deletado com sucesso.', '', {
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

  switchActive(advertiser) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (advertiser.ativo ? 'desativar' : 'ativar') + ' o Anunciante ' + advertiser.nome + '?',
      header: 'Confirma a ' + (advertiser.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.switchActive(advertiser.id).subscribe(() => {
          this.dt.reset();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Anunciante <b> ' + advertiser.nome + ' </b> foi ' + (advertiser.ativo ? 'desativado' : 'ativado') + ' com sucesso.', '', {
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
