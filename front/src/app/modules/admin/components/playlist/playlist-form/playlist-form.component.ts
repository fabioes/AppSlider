import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { FranchiseService } from '../../../services/franchise/franchise.service';
import { PlaylistService } from '../../../services/playlist/playlist.service';

@Component({
  selector: 'playlist-form',
  templateUrl: './playlist-form.component.html',
  styleUrls: ['./playlist-form.component.scss']
})
export class PlaylistFormComponent implements OnInit {

  @Input() playlist: Model.App.Playlist;
  playlistForm: FormGroup;
  pt = this.globalService.getPrimeCalendarPtConfig();
  franchise: Model.App.UserFranchise;
  
  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private playlistService: PlaylistService,
    private toastrService: ToastrService,
    private franchiseService: FranchiseService    
  ) {
    moment.locale('pt-BR');
    this.franchise = this.franchiseService.Franchise;
  }

  ngOnInit() {

    this.playlistForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      id_franquia: [this.franchise.id],
      ativa: [true],
      data_expiracao: [''],
      dateTemp: [null]
    });

    this.playlistForm.patchValue(this.playlist || {});

    if ((this.playlist || <Model.App.Business>{}).data_expiracao)
      this.playlistForm.get('dateTemp').setValue(new Date(this.playlist.data_expiracao));

  }

  public save() {

    if (this.playlistForm.invalid) return;

    this.playlist = this.playlistForm.value;

    if (this.playlist.id) {
      this.playlistService.updatePlaylist(this.playlist).subscribe(res => this.callbackAction('alterada', res));
    }
    else {
      this.playlistService.createPlaylist(this.playlist).subscribe(res => this.callbackAction('criada', res));
    }
  }

  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.playlistForm);
  }

  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Playlist <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
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
    this.playlistForm.get('data_expiracao').setValue(date);
  }

}