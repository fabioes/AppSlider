import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../services/business/business.service';
import { FranchiseFormComponent } from './franchise-form/franchise-form.component';


@Component({
  selector: 'app-franchise',
  templateUrl: './franchise.component.html',
  styleUrls: ['./franchise.component.scss']
})
export class FranchiseComponent implements OnInit {

  franchises: Array<Model.App.Business>;
  franchisesGrid: Array<Model.App.Business>;
  searchTerm: string;


  constructor(private businessService: BusinessService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getFranchises();



  }

  private getFranchises() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessService.getForLoggedUser().subscribe(res => {

      this.franchises = res;
      for (let franchise of this.franchises) {
        var base64 = 'data:image/jpeg;base64,' + franchise.file;
        franchise.file = base64;
    }
      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.franchisesGrid = this.franchises;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getFranchises();

    this.franchisesGrid = this.franchises.filter((item) => (item.contato_cidade || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 );
  }

  showDialog(franchise: Model.App.Business) {
    const modalRef = this.modalService.open(FranchiseFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Franquia';

    modalRef.componentInstance.franchise = franchise;

    modalRef.result.then((res: Model.App.Business) => {
      if (res == null) return;

      this.getFranchises();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteFranchise(franchise) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar a Franquia ' + franchise.contato_cidade + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.deleteBusiness(franchise.id).subscribe(() => {
          this.getFranchises();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Franquia <b> ' + franchise.contato_cidade + ' </b> foi deletada com sucesso.', '', {
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

  switchActive(franchise){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (franchise.ativo ? 'desativar' : 'ativar') + ' a franquia ' + franchise.contato_cidade + '?',
      header: 'Confirma a ' + (franchise.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessService.switchActive(franchise.id).subscribe(() => {
          this.getFranchises();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> A Franquia <b> ' + franchise.contato_cidade + ' </b> foi ' + (franchise.ativo ? 'desativada' : 'ativada') + ' com sucesso.', '', {
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
