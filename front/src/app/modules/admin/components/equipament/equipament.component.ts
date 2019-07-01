import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EquipamentFormComponent } from './equipament-form/equipament-form.component';
import { EquipamentService } from '../../services/equipament/equipament.service';


@Component({
  selector: 'app-equipament',
  templateUrl: './equipament.component.html',
  styleUrls: ['./equipament.component.scss']
})
export class EquipamentComponent implements OnInit {

  equipaments: Array<Model.App.Equipament>;
  equipamentsGrid: Array<Model.App.Equipament>;
  searchTerm: string;

  constructor(private equipamentService: EquipamentService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getEquipaments();
  }

  private getEquipaments() {
    //TODO: make retrive routines for Attendant by API request

    return this.equipamentService.getByFranchise().subscribe(res => {

      this.equipaments = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.equipamentsGrid = this.equipaments;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getEquipaments();

    this.equipamentsGrid = this.equipaments.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.descricao || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0 || (item.mac_address || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  showDialog(equipament: Model.App.BusinessType) {
    const modalRef = this.modalService.open(EquipamentFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Equipamento';

    modalRef.componentInstance.equipament = equipament;

    modalRef.result.then((res: Model.App.BusinessType) => {
      if (res == null) return;

      this.getEquipaments();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteBusinessType(equipament) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar o equipamento ' + equipament.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.equipamentService.deleteEquipament(equipament.id).subscribe(() => {
          this.getEquipaments();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Equipamento <b> ' + equipament.nome + ' </b> foi deletado com sucesso.', '', {
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

  switchActive(equipament){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (equipament.ativo ? 'desativar' : 'ativar') + ' o equipamento ' + equipament.nome + '?',
      header: 'Confirma a ' + (equipament.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.equipamentService.switchActive(equipament.id).subscribe(() => {
          this.getEquipaments();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Equipamento <b> ' + equipament.nome + ' </b> foi ' + (equipament.ativo ? 'desativado' : 'ativado') + ' com sucesso.', '', {
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
