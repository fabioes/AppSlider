import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { EstablishmentFormComponent } from './establishment-form/establishment-form.component';


@Component({
  selector: 'app-establishment',
  templateUrl: './establishment.component.html',
  styleUrls: ['./establishment.component.scss']
})
export class EstablishmentComponent implements OnInit {

  establishments: Array<Model.App.Business>;
  establishmentsGrid: Array<Model.App.Business>;
  searchTerm: string;

  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getEstablishments();
  }

  private getEstablishments() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getAllBusinesss().subscribe(res => {

      this.establishments = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.establishmentsGrid = this.establishments;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getEstablishments();

    this.establishmentsGrid = this.establishments.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.descricao || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
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
