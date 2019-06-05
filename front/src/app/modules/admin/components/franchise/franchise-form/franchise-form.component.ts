import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';


@Component({
  selector: 'franchise-form',
  templateUrl: './franchise-form.component.html',
  styleUrls: ['./franchise-form.component.scss']
})
export class FranchiseFormComponent implements OnInit {

  @Input() franchise: Model.App.Business;
  franchiseForm: FormGroup;
 

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessService: BusinessService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.franchiseForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      descricao: [''],
      //id_pai: string,
      id_tipo: ['', Validators.required],
      //id_categoria: string,
      //id_logo: string,
      contato_nome: ['', Validators.required],
      contato_email: ['', Validators.required],
      contato_telefone: [''],
      contato_endereco: [''],
      data_expiracao: [''],
      ativo: [true]
    });

    this.franchiseForm.patchValue(this.franchise || {});    
  }

  public save() {

    if (this.franchiseForm.invalid) return;

    this.franchise = this.franchiseForm.value;
    
    if (this.franchise.id) {
      this.businessService.updateBusiness(this.franchise).subscribe(res => this.callbackAction('alterada', res));
    }
    else {
      this.businessService.createBusiness(this.franchise).subscribe(res => this.callbackAction('criada', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.franchiseForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Franquia <b> ' + res.name + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

}