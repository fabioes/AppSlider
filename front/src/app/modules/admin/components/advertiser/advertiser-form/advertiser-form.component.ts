import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';
import * as moment from 'moment';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';
import { FranchiseService } from '../../../services/franchise/franchise.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { EquipamentComponent } from '../../equipament/equipament.component';
import { EquipamentService } from '../../../services/equipament/equipament.service';

@Component({
  selector: 'advertiser-form',
  templateUrl: './advertiser-form.component.html',
  styleUrls: ['./advertiser-form.component.scss']
})
export class AdvertiserFormComponent implements OnInit {

  @Input() advertiser: Model.App.Business;
  advertiserForm: FormGroup;
  pt = this.globalService.getPrimeCalendarPtConfig();
  franchise: Model.App.UserFranchise;
  establishments: Array<Model.App.Business>;
  equipaments: Array<Model.App.Equipament>;
  searchTerm: string;
  selectedScopes: any[] = [];
  selectedEstablishments:SelectItem[];
  selectedEquipaments:SelectItem[];

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessService: BusinessService,
    private toastrService: ToastrService,
    private businessTypeService: BusinessTypeService,
    private franchiseService: FranchiseService,
    private equipamentService: EquipamentService) {
    moment.locale('pt-BR');
    this.franchise = this.franchiseService.Franchise;

    this.getEstablishments();
    this.getEquipaments();
  }

  ngOnInit() {

    this.advertiserForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      descricao: [''],
      id_pai: [this.franchise.id],
      id_tipo: ['', Validators.required],
      contato_nome: ['', Validators.required],
      contato_email: ['', Validators.required],
      contato_telefone: [''],
      contato_endereco: [''],
      data_expiracao: [''],
      ativo: [true],
      dateTemp: [null],
      x: [this.advertiser != null ? this.advertiser.filhos : null],
      y: [this.advertiser != null ? this.advertiser.equipaments : null],
    });

    this.advertiserForm.patchValue(this.advertiser || {});

    this.businessTypeService.getAllBusinessTypes().subscribe(res => {
      this.advertiserForm.get('id_tipo').setValue((res.filter(item => item.nome === 'Anunciante')[0]).id);
    });

    if ((this.advertiser || <Model.App.Business>{}).data_expiracao)
      this.advertiserForm.get('dateTemp').setValue(new Date(this.advertiser.data_expiracao));

  }

  public save() {

    if (this.advertiserForm.invalid) return;

    this.advertiser = this.advertiserForm.value;

    if (this.advertiser.id) {

       this.advertiser.filhos = this.advertiserForm.value.x;
       this.advertiser.equipaments = this.advertiserForm.value.y;


      this.businessService.updateBusiness(this.advertiser).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.businessService.createBusiness(this.advertiser).subscribe(res => this.callbackAction('criado', res));
    }
  }

  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.advertiserForm);
  }
  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Anunciante <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
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
    this.advertiserForm.get('data_expiracao').setValue(date);
  }
  getCheckboxScope(event) {
    this.selectedScopes.push(event);

  }
  getEstablishments() {

    return this.businessService.getByFranchiseAndType('Estabelecimento').subscribe(res => {

      this.establishments = res;

    });
  }
  getEquipaments() {
    return this.equipamentService.getByFranchise().subscribe(
      res => this.equipaments = res
    );
  }
}
