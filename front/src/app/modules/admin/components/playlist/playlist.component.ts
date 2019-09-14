import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PlaylistFormComponent } from './playlist-form/playlist-form.component';
import { PlaylistService } from '../../services/playlist/playlist.service';
import { PlaylistFilesComponent } from './playlist-files/playlist-files.component';
import { environment } from '../../../../../environments/environment';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-playlist',
  templateUrl: './playlist.component.html',
  styleUrls: ['./playlist.component.scss']
})
export class PlaylistComponent implements OnInit {
  @Input() equipament: Model.App.Equipament;
  @Input() business: Model.App.Business;
  playlists: Model.App.Playlist;
  playlistsGrid: Model.App.Playlist;
  searchTerm: string;
  franchise: Model.App.UserFranchise;
  getFileUrl = environment.apiConfig.baseUrl + environment.apiConfig.apiRoutes.files.default + '/';
  playlistForm: any;

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private playlistService: PlaylistService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.playlistForm = this.fb.group({
      business_id: [''],
      business_type: [],
      tipo: ['', Validators.required],
      tempo_duracao: [5, Validators.required]
    });
    this.getPlaylist(this.equipament.mac_address);
  }

  private getPlaylist(macAdress: string) {

    return this.playlistService.getByMacAddress(macAdress).subscribe(res => {
      this.playlists = res;
        this.playlistsGrid = this.playlists;
    });
  }

}
