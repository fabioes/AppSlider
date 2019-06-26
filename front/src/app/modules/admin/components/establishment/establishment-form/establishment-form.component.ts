import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';
import * as moment from 'moment';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';
import { FranchiseService } from '../../../services/franchise/franchise.service';
import { CategoryService } from '../../../services/category/category.service';

@Component({
  selector: 'establishment-form',
  templateUrl: './establishment-form.component.html',
  styleUrls: ['./establishment-form.component.scss']
})
export class EstablishmentFormComponent implements OnInit {

  @Input() establishment: Model.App.Business;
  establishmentForm: FormGroup;
  pt = this.globalService.getPrimeCalendarPtConfig();
  franchise: Model.App.UserFranchise;
  categories : Array<Model.App.Category>;

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessService: BusinessService,
    private toastrService: ToastrService,
    private businessTypeService: BusinessTypeService,
    private franchiseService : FranchiseService,
    private categoryService : CategoryService,
    ) {
    moment.locale('pt-BR');
    this.franchise = this.franchiseService.Franchise;

    this.categoryService.getAllCategorys().subscribe(res => this.categories = res);
  }

  ngOnInit() {

    this.establishmentForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      descricao: [''],
      id_pai: [this.franchise.id],
      id_tipo: ['', Validators.required],
      id_categoria: [''],
      //id_logo: string,
      contato_nome: ['', Validators.required],
      contato_email: ['', Validators.required],
      contato_telefone: [''],
      contato_endereco: [''],
      data_expiracao: [''],
      ativo: [true],
      dateTemp: [null]
    });

    this.establishmentForm.patchValue(this.establishment || {});

    this.businessTypeService.getAllBusinessTypes().subscribe(res => {
      this.establishmentForm.get('id_tipo').setValue((res.filter(item => item.nome === 'Estabelecimento')[0]).id);
    });

    if((this.establishment || <Model.App.Business>{}).data_expiracao)
    this.establishmentForm.get('dateTemp').setValue(new Date(this.establishment.data_expiracao));

  }

  public save() {

    if (this.establishmentForm.invalid) return;

    this.establishment = this.establishmentForm.value;

    if (this.establishment.id) {
      this.businessService.updateBusiness(this.establishment).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.businessService.createBusiness(this.establishment).subscribe(res => this.callbackAction('criado', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.establishmentForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Estabelecimento <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

  setDateValue(event) {
    let date = moment(event).format();
    this.establishmentForm.get('data_expiracao').setValue(date);
  }

}