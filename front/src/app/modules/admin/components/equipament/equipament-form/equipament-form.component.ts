import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EquipamentService } from '../../../services/equipament/equipament.service';
import { FranchiseService } from '../../../services/franchise/franchise.service';
import { forkJoin } from 'rxjs';
import { BusinessService } from '../../../services/business/business.service';
import { PlaylistService } from '../../../services/playlist/playlist.service';
//import { forkJoin } from 'rxjs/observable/forkJoin';

@Component({
  selector: 'equipament-form',
  templateUrl: './equipament-form.component.html',
  styleUrls: ['./equipament-form.component.scss']
})
export class EquipamentFormComponent implements OnInit {

  @Input() equipament: Model.App.Equipament;
  equipamentForm: FormGroup;
  franchise: Model.App.UserFranchise;
  establishments: Array<Model.App.Business> = [];
  playlists: Array<Model.App.Playlist> = [];

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessTypeService: EquipamentService,
    private toastrService: ToastrService,
    private franchiseService: FranchiseService,
    private businessServices: BusinessService,
    private playlistService: PlaylistService) {
    this.franchise = this.franchiseService.Franchise;
  }

  ngOnInit() {

    forkJoin([this.businessServices.getByFranchiseAndType("Estabelecimento"),
    this.playlistService.getByFranchise()], res => {

      this.establishments = res[0];
      this.playlists = res[1];

      this.equipamentForm = this.fb.group({
        id: [''],
        nome: ['', Validators.required],
        descricao: [''],
        mac_address: ['', Validators.required],
        id_franquia: [this.franchise.id, Validators.required],
        id_estabelecimento: [''],
        id_playlist: [''],
        ativo: [true]
      });

      this.equipamentForm.patchValue(this.equipament || {});
    });
  }

  public save() {

    if (this.equipamentForm.invalid) return;

    this.equipament = this.equipamentForm.value;

    if (this.equipament.id) {
      this.businessTypeService.updateEquipament(this.equipament).subscribe(res => this.callbackAction('alterado', res));
    }
    else {
      this.businessTypeService.createEquipament(this.equipament).subscribe(res => this.callbackAction('criado', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.equipamentForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span> O Equipamento <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.activeModal.close(res);
  }

}