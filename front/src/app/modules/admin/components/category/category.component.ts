import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { CategoryFormComponent } from './category-form/category-form.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CategoryService } from '../../services/category/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  categories: Array<Model.App.Category>;
  categoriesGrid: Array<Model.App.Category>;
  searchTerm: string;

  constructor(private categoryService: CategoryService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getCategories();
  }

  private getCategories() {
    //TODO: make retrive routines for Attendant by API request

    return this.categoryService.getAllCategories().subscribe(res => {

      this.categories = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.categoriesGrid = this.categories;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getCategories();

    this.categoriesGrid = this.categories.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.descricao || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  showDialog(category: Model.App.Category) {
    const modalRef = this.modalService.open(CategoryFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Categoria';

    modalRef.componentInstance.category = category;

    modalRef.result.then((res: Model.App.Category) => {
      if (res == null) return;

      this.getCategories();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteCategory(category) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar a categoria ' + category.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.categoryService.deleteCategory(category.id).subscribe(() => {
          this.getCategories();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> A categoria <b> ' + category.nome + ' </b> foi deletada com sucesso.', '', {
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
