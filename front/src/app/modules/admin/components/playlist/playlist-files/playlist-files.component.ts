import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { FranchiseService } from '../../../services/franchise/franchise.service';
import { PlaylistService } from '../../../services/playlist/playlist.service';
import { environment } from '../../../../../../environments/environment';
import { FileUpload } from 'primeng/fileupload';
import { areIterablesEqual } from '@angular/core/src/change_detection/change_detection_util';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';


@Component({
  selector: 'playlists-files',
  templateUrl: './playlist-files.component.html',
  styleUrls: ['./playlist-files.component.scss']
})
export class PlaylistFilesComponent implements OnInit {

  @Input() playlist: Model.App.Playlist;
  @Input() business: Model.App.Business;
  @ViewChild('fileUpload') private fileUpload: FileUpload;
  playlistFilesForm: FormGroup;
  pt = this.globalService.getPrimeCalendarPtConfig();
  franchise: Model.App.UserFranchise;
  getFileUrl = environment.apiConfig.baseUrl + environment.apiConfig.apiRoutes.files.default + '/';
  showFileError: boolean = false;
  playlists: Model.App.Playlist;
  playlistsGrid: Model.App.Playlist;
  searchTerm: string;
  types = [{
    name: 'Imagem',
    value: 'imagem'
  }
  // {
  //   name: 'Vídeo',
  //   value: 'video'
  // }
];


  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private playlistService: PlaylistService,
    private toastrService: ToastrService,
    private franchiseService: FranchiseService,
    private confirmationService: ConfirmationService,
  ) {
    moment.locale('pt-BR');
    this.franchise = this.franchiseService.Franchise;

  }

  ngOnInit() {

    this.playlistFilesForm = this.fb.group({
      business_id: [this.business.id],
      business_type: [this.business.id_tipo],
      tipo: ['', Validators.required],
      tempo_duracao: [5, Validators.required]
    });
    this.getPlaylists();

  }


  public save() {

    if (this.playlistFilesForm.invalid) return;

    if (!this.fileUpload.files || this.fileUpload.files.length == 0 || !this.fileUpload.files[0]) {
      this.showFileError = false;
      return;
    }
    else
      this.showFileError = false;

    let file: File = this.fileUpload.files[0];
    let playlistItem = this.playlistFilesForm.value;
    playlistItem.tipo = (typeof playlistItem.tipo) == "string" ? playlistItem.tipo : playlistItem.tipo.value;

    this.playlistService.addItem(playlistItem, file).subscribe(res => this.callbackAction('criado', res));

  }

  deleteItem(playListItem) {
    this.confirmationService.confirm({
      message: 'Tem certeza que deseja remover o item da Playlist?',
      header: 'Confirma a remoção?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.playlistService.removeItem(this.business.id, playListItem.id).subscribe(() => {

          this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Item da Playlist <b> </b> foi removido com sucesso.', '', {
            timeOut: 3500,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-success alert-with-icon",
            positionClass: 'toast-top-right'
          });
          this.getPlaylists();
        });
      }
    });
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.playlistFilesForm);
  }
  private getPlaylists() {
    return this.playlistService.getByBusiness(this.business.id).subscribe(res => {
      this.playlists = res;
      if (this.searchTerm)
        this.searchSubmit(null);
      else
        this.playlistsGrid = this.playlists;
    });
  }
  validateFile(event, uploader: FileUpload) {
      console.log(event);
        let reader = new FileReader();
     if (event.files && event.files.length > 0) {
       let file = event.files[0];

       const img = new Image();
       img.src = window.URL.createObjectURL( file );

       reader.readAsDataURL(file);
       reader.onload = () => {

         const width = img.naturalWidth;
         const height = img.naturalHeight;

         window.URL.revokeObjectURL( img.src );
          debugger; 
         if( width !== 1270 && height !== 720 ) {
              this.playlistFilesForm.setErrors({ 'invalid': true });
         }  
         var extn = file.name.split(".").pop();
         switch (extn.toLowerCase()) {
            case 'gif':
            case 'jpg':
            case 'jpeg':
            case 'gif':   
             this.playlistFilesForm.setErrors({ 'invalid': null });
             break;         
           default:
             this.playlistFilesForm.setErrors({ 'invalid': true });
             break;
         }  
         if(extn !== 'gif' || extn !== 'png' || extn !== 'jpg' || extn !== 'jpeg' )  {
            this.playlistFilesForm.setErrors({ 'invalid': true });
         }
         
     };
    }
      }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getPlaylists();

   // this.playlistsGrid = this.playlists.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Item da Playlist foi ' + action + ' com sucesso.', '', {
      timeOut: 3500,
      closeButton: true,
      enableHtml: true,
      toastClass: "alert alert-success alert-with-icon",
      positionClass: 'toast-top-right'
    });

    this.playlist = res;

    this.playlistFilesForm.get('tipo').setValue(null);
    this.playlistFilesForm.get('tempo_duracao').setValue(5);
    this.fileUpload.clear();

    if (!this.playlist.playlist_itens)
    this.playlist.playlist_itens = [];

    this.getPlaylists();
  }

}
