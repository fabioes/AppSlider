import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';


@Component({
  selector: 'business-type-form',
  templateUrl: './business-type-form.component.html',
  styleUrls: ['./business-type-form.component.scss']
})
export class BusinessTypeFormComponent implements OnInit {

  @Input() businessType: Model.App.BusinessType;
  businessTypeForm: FormGroup;
 

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessTypeService: BusinessTypeService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.businessTypeForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      descricao: ['']
    });

    this.businessTypeForm.patchValue(this.businessType || {});    
  }

  public save() {

    if (this.businessTypeForm.invalid) return;

    this.businessType = this.businessTypeForm.value;
    
    if (this.businessType.id) {
      this.businessTypeService.updateBusinessType(this.businessType).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.businessTypeService.createBusinessType(this.businessType).subscribe(res => this.callbackAction('criado', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.businessTypeForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O tipo de negócio <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

}