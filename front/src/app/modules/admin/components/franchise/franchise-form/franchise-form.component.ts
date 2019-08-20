import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';
import * as moment from 'moment';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';
import { FileUpload } from 'primeng/fileupload';

@Component({
  selector: 'franchise-form',
  templateUrl: './franchise-form.component.html',
  styleUrls: ['./franchise-form.component.scss']
})
export class FranchiseFormComponent implements OnInit {

  @Input() franchise: Model.App.Business;
  franchiseForm: FormGroup;
  pt = this.globalService.getPrimeCalendarPtConfig();
  file: any;
  @ViewChild('fileUpload') private fileUpload: ElementRef;

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessService: BusinessService,
    private toastrService: ToastrService,
    private businessTypeService: BusinessTypeService) {
    moment.locale('pt-BR');
  }

  ngOnInit() {
    if (!this.franchise) {
      this.file = '/assets/img/noimage-portfolio-2000x1125.png';
    } else {
      if (!this.franchise.file) {
        this.file = '/assets/img/noimage-portfolio-2000x1125.png';
      }
      else {
        this.file = 'data:image/jpeg;base64,' + this.franchise.file;
      }
    }


    this.franchiseForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      CNPJ: [''],
      //id_pai: string,
      id_tipo: ['', Validators.required],
      //id_categoria: string,
      contato_nome: ['', Validators.required],
      contato_email: ['', Validators.required],
      contato_telefone: [''],
      contato_endereco: [''],
      data_expiracao: [''],
      ativo: [true],
      dateTemp: [null]
    });

    this.franchiseForm.patchValue(this.franchise || {});

    this.businessTypeService.getAllBusinessTypes().subscribe(res => {
      debugger;
      this.franchiseForm.get('id_tipo').setValue((res.filter(item => item.nome === 'Franquia')[0]).id);
    });

    if ((this.franchise || <Model.App.Business>{}).data_expiracao)
      this.franchiseForm.get('dateTemp').setValue(new Date(this.franchise.data_expiracao));

  }

  public save() {

    if (this.franchiseForm.invalid) return;

    this.franchise = this.franchiseForm.value;
    let file: File = this.fileUpload.nativeElement.files[0];
    if (this.franchise.id) {
      this.businessService.updateFranchise(this.franchise, file).subscribe(res => this.callbackAction('alterada', res));
    }
    else {
      this.businessService.createFranchise(this.franchise, file).subscribe(res => this.callbackAction('criada', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.franchiseForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Franquia <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
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
    this.franchiseForm.get('data_expiracao').setValue(date);
  }

}
