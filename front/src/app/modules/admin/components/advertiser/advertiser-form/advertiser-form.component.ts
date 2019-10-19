import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';
import * as moment from 'moment';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';
import { FranchiseService } from '../../../services/franchise/franchise.service';
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

  establishmentsDdlItems: Array<Model.Util.DropdownModelItem> = [];
  selectedEstablishmentsDdlItems: Array<Model.Util.DropdownModelItem> = [];
  equipmentsDdlItems: Array<Model.Util.DropdownModelItem> = [];
  selectedEquipmentsDdlItems: Array<Model.Util.DropdownModelItem> = [];

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

    this.advertiserForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      descricao: [''],
      id_pai: [this.franchise.id],
      id_tipo: ['', Validators.required],
      contato_nome: [''],
      contato_email: [''],
      contato_telefone: [''],
      contato_endereco: [''],
      data_expiracao: [''],
      ativo: [true],
      dateTemp: [null],
      x: [null],
      y: [null],
      z: ['']
    });

    this.getEstablishments();
    this.getEquipaments();

  }

  async ngOnInit() {
    this.advertiserForm.patchValue(this.advertiser || {});

    if (this.advertiser) {
      this.advertiserForm.get('x').setValue(this.selectedEstablishmentsDdlItems);
      this.advertiserForm.get('y').setValue(this.selectedEquipmentsDdlItems);
    }

    const res = await this.businessTypeService.getAllBusinessTypes().toPromise();
      this.advertiserForm.get('id_tipo').setValue((res.filter(item => item.nome === 'Anunciante')[0]).id);

    if ((this.advertiser || <Model.App.Business>{}).data_expiracao) {
      this.advertiserForm.get('dateTemp').setValue(new Date(this.advertiser.data_expiracao));
    }

  }

  public save() {

    if (this.advertiserForm.invalid) { return; }

    this.advertiser = this.advertiserForm.value;

    if (this.advertiser.id) {

      this.advertiser.filhos = (this.advertiserForm.get('x').value || []).map(m => this.establishments.find(f => f.id === m.value.id));
      this.advertiser.equipaments = (this.advertiserForm.get('y').value || []).map(m => this.equipaments.find(f => f.id === m.value.id));

      this.businessService.updateAdvertiser(this.advertiser).subscribe(res => this.callbackAction('alterado', res));
    } else {
      this.businessService.createBusiness(this.advertiser).subscribe(res => this.callbackAction('criado', res));
    }
  }

  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.advertiserForm);
  }
  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Anunciante <b> ' +
     res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: 'alert alert-success alert-with-icon',
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

  setDateValue(event) {
    const date = moment(event).format();
    this.advertiserForm.get('data_expiracao').setValue(date);
  }

  async getEstablishments() {

    this.establishments = await this.businessService.getByFranchiseAndType('Estabelecimento').toPromise();

    this.establishmentsDdlItems = (this.establishments || []).map(m => {
      const newItem = {
        label: m.nome,
        value: {
          id: m.id,
          name: m.nome
        }
      };

      if ((this.advertiser.filhos || []).filter(f => f.id === m.id).length > 0
      && this.selectedEstablishmentsDdlItems.filter(f => f.value.id === m.id).length === 0) {
        this.selectedEstablishmentsDdlItems.push(newItem);
      }

      return newItem;
    });
  }
  async getEquipaments() {
    const equipaments = await this.equipamentService.getByFranchise().toPromise();
    this.equipaments = equipaments.map(m => {
      m.advertiser_name = m.nome + '|' + m.establishment.nome;
      return m;
    });

    this.equipmentsDdlItems = this.equipaments.map(m => {
      const newItem = {
        label: m.advertiser_name,
        value: {
          id: m.id,
          name: m.advertiser_name
        }
      };

      if ((this.advertiser.equipaments || []).filter(f => f.id === m.id).length > 0
      && this.selectedEquipmentsDdlItems.filter(f => f.value.id === m.id).length === 0) {
        this.selectedEquipmentsDdlItems.push(newItem);
      }

      return newItem;
    });
  }
}
