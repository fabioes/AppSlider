import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessTypeService } from '../../services/business-type/business-type.service';
import { BusinessTypeFormComponent } from './business-type-form/business-type-form.component';


@Component({
  selector: 'app-business-type',
  templateUrl: './business-type.component.html',
  styleUrls: ['./business-type.component.scss']
})
export class BusinessTypeComponent implements OnInit {

  businessTypes: Array<Model.App.BusinessType>;
  businessTypesGrid: Array<Model.App.BusinessType>;
  searchTerm: string;

  constructor(private businessTypeService: BusinessTypeService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getBusinessTypes();
  }

  private getBusinessTypes() {
    //TODO: make retrive routines for Attendant by API request

    return this.businessTypeService.getAllBusinessTypes().subscribe(res => {

      this.businessTypes = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.businessTypesGrid = this.businessTypes;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getBusinessTypes();

    this.businessTypesGrid = this.businessTypes.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.descricao || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  showDialog(businessType: Model.App.BusinessType) {
    const modalRef = this.modalService.open(BusinessTypeFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Tipo de Negócio';

    modalRef.componentInstance.businessType = businessType;

    modalRef.result.then((res: Model.App.BusinessType) => {
      if (res == null) return;

      this.getBusinessTypes();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteBusinessType(businessType) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o tipo de negócio ' + businessType.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.businessTypeService.deleteBusinessType(businessType.id).subscribe(() => {
          this.getBusinessTypes();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Tipo de Negócio <b> ' + businessType.nome + ' </b> foi deletado com sucesso.', '', {
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
