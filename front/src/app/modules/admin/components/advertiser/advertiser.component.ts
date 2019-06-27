import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { AdvertiserFormComponent } from './advertiser-form/advertiser-form.component';


@Component({
  selector: 'app-advertiser',
  templateUrl: './advertiser.component.html',
  styleUrls: ['./advertiser.component.scss']
})
export class AdvertiserComponent implements OnInit {

  advertisers: Array<Model.App.Business>;
  advertisersGrid: Array<Model.App.Business>;
  searchTerm: string;

  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAdvertisers();
  }

  private getAdvertisers() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getByType("Anunciante").subscribe(res => {

      this.advertisers = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.advertisersGrid = this.advertisers;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getAdvertisers();

    this.advertisersGrid = this.advertisers.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.descricao || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
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

      this.getAdvertisers();

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
          this.getAdvertisers();
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

  switchActive(advertiser){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (advertiser.ativo ? 'desativar' : 'ativar') + ' o estabelecimento ' + advertiser.nome + '?',
      header: 'Confirma a ' + (advertiser.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.switchActive(advertiser.id).subscribe(() => {
          this.getAdvertisers();
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
