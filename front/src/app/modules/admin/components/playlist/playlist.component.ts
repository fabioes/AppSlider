import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PlaylistFormComponent } from './playlist-form/playlist-form.component';
import { PlaylistService } from '../../services/playlist/playlist.service';
import { PlaylistFilesComponent } from './playlist-files/playlist-files.component';


@Component({
  selector: 'app-playlist',
  templateUrl: './playlist.component.html',
  styleUrls: ['./playlist.component.scss']
})
export class PlaylistComponent implements OnInit {

  playlists: Array<Model.App.Playlist>;
  playlistsGrid: Array<Model.App.Playlist>;
  searchTerm: string;

  constructor(private playlistService: PlaylistService,
    private confirmationService: ConfirmationService,
    private modalService: NgbModal,
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.getPlaylists();
  }

  private getPlaylists() {
    //TODO: make retrive routines for Attendant by API request

    return this.playlistService.getByFranchise().subscribe(res => {

      this.playlists = res;

      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.playlistsGrid = this.playlists;
    });
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getPlaylists();

    this.playlistsGrid = this.playlists.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  filesDialog(playlist: Model.App.Playlist){
    const modalRef = this.modalService.open(PlaylistFilesComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist Itens';

    modalRef.componentInstance.playlist = playlist;

    modalRef.result.then((res: Model.App.Playlist) => {
      if (res == null) return;

      this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
  }

  showDialog(playlist: Model.App.Playlist) {
    const modalRef = this.modalService.open(PlaylistFormComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist';

    modalRef.componentInstance.playlist = playlist;

    modalRef.result.then((res: Model.App.Playlist) => {
      if (res == null) return;

      this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
  }

  deleteFranchise(playlist) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja deletar a Playlist ' + playlist.nome + '?',
      header: 'Confirma a deleção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.playlistService.deletePlaylist(playlist.id).subscribe(() => {
          this.getPlaylists();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Playlist <b> ' + playlist.nome + ' </b> foi deletada com sucesso.', '', {
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

  switchActive(playlist){
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja ' + (playlist.ativo ? 'desativar' : 'ativar') + ' a playlist ' + playlist.nome + '?',
      header: 'Confirma a ' + (playlist.ativo ? 'desativação' : 'ativação') + '?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.playlistService.switchActive(playlist.id).subscribe(() => {
          this.getPlaylists();
          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>A Playlist <b> ' + playlist.nome + ' </b> foi ' + (playlist.ativo ? 'desativada' : 'ativada') + ' com sucesso.', '', {
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
