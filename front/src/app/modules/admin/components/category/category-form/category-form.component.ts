import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoryService } from '../../../services/category/category.service';


@Component({
  selector: 'category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.scss']
})
export class CategoryFormComponent implements OnInit {

  @Input() category: Model.App.Category;
  categoryForm: FormGroup;
 

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private categoryService: CategoryService,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.categoryForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      descricao: ['']
    });

    this.categoryForm.patchValue(this.category || {});    
  }

  public save() {

    if (this.categoryForm.invalid) return;

    this.category = this.categoryForm.value;
    
    if (this.category.id) {
      this.categoryService.updateCategory(this.category).subscribe(res => this.callbackAction('alterada', res));
    }
    else {
      this.categoryService.createCategory(this.category).subscribe(res => this.callbackAction('criada', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.categoryForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> A categoria <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }



}
