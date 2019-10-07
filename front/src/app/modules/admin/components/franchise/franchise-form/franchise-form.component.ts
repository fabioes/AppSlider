import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';
import * as moment from 'moment';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';
import { FileUpload } from 'primeng/fileupload';
import { DomSanitizer } from '@angular/platform-browser';

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
    private businessTypeService: BusinessTypeService,
    private sanitizer:DomSanitizer) {
    moment.locale('pt-BR');
  }

  ngOnInit() {
    if (!this.franchise) {
      this.file = './assets/img/noimage-portfolio-2000x1125.png';
    } else {
      if (!this.franchise.file) {
        this.file = './assets/img/noimage-portfolio-2000x1125.png';
      }
      else {

        this.file = this.franchise.file;
      }
    }


    this.franchiseForm = this.fb.group({
      id: [''],
     // nome: ['', Validators.required],
      CNPJ: [''],
      //id_pai: string,
      id_tipo: ['', Validators.required],
      //id_categoria: string,
      contato_nome: [''],
      contato_email: [''],
      contato_telefone: [''],
      contato_endereco: [''],
      contato_cidade: [''],
      data_expiracao: [''],
      ativo: [true],
      dateTemp: [null]
    });

    this.franchiseForm.patchValue(this.franchise || {});

    this.businessTypeService.getAllBusinessTypes().subscribe(res => {
      this.franchiseForm.get('id_tipo').setValue((res.filter(item => item.nome === 'Franquia')[0]).id);
    });

    if ((this.franchise || <Model.App.Business>{}).data_expiracao)
      this.franchiseForm.get('dateTemp').setValue(new Date(this.franchise.data_expiracao));

  }

  public async save() {

    if (this.franchiseForm.invalid) return;

    this.franchise = this.franchiseForm.value;
    let file: File = this.fileUpload.nativeElement.files[0];
    if (!file) {
      const b64toBlob = async () => {
        const url = this.file;
        const response = await fetch(url);
        const blob = await response.blob();
        const file = new File([blob], "franchise");
        return file;
      };
      let v = await b64toBlob();
      file = v;
    }
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

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Franquia <b> ' + res.contato_cidade + ' </b> foi ' + action + ' com sucesso.', '', {
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
  preview(files) {
    if (files.length === 0)
      return;
    var reader = new FileReader();

    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.file = reader.result;
    }
  }

}
