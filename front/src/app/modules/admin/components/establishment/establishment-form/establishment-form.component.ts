import { Component, OnInit, Input, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { GlobalService } from '../../../../../services/global/global.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessService } from '../../../services/business/business.service';
import * as moment from 'moment';
import { BusinessTypeService } from '../../../services/business-type/business-type.service';
import { FranchiseService } from '../../../services/franchise/franchise.service';
import { CategoryService } from '../../../services/category/category.service';
import { PlaylistFilesComponent } from '../../playlist/playlist-files/playlist-files.component';
import { PlaylistService } from '../../../services/playlist/playlist.service';

@Component({
  selector: 'establishment-form',
  templateUrl: './establishment-form.component.html',
  styleUrls: ['./establishment-form.component.scss']
})
export class EstablishmentFormComponent implements OnInit {

  @Input() establishment: Model.App.Business;
  establishmentForm: FormGroup;
  pt = this.globalService.getPrimeCalendarPtConfig();
  franchise: Model.App.UserFranchise;
  categories: Array<Model.App.Category>;
  playlists: Array<Model.App.Playlist>;
  playlistsGrid: Array<Model.App.Playlist>;
  searchTerm: string;
  imageSrc: string;
  file: any;
  @ViewChild('fileUpload') private fileUpload: ElementRef;

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private globalService: GlobalService,
    private businessService: BusinessService,
    private toastrService: ToastrService,
    private businessTypeService: BusinessTypeService,
    private franchiseService: FranchiseService,
    private categoryService: CategoryService,
    private playlistService: PlaylistService,
    private modalService: NgbModal,
  ) {
    moment.locale('pt-BR');
    this.franchise = this.franchiseService.Franchise;

    this.categoryService.getAllCategories().subscribe(res => { this.categories = res });
  }

  ngOnInit() {

    if (!this.establishment) {
      this.file = './assets/img/noimage-portfolio-2000x1125.png';
    } else {
      if (!this.establishment.file) {
        this.file = './assets/img/noimage-portfolio-2000x1125.png';
      } else {
        this.file = 'data:image/jpeg;base64,' + this.establishment.file;
      }
    }


    this.establishmentForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      CNPJ: [''],
      id_pai: [this.franchise.id],
      id_tipo: ['', Validators.required],
      id_categoria: [''],
      //id_logo: string,
      contato_nome: ['', Validators.required],
      contato_email: ['', Validators.required],
      contato_telefone: [''],
      contato_endereco: [''],
      data_expiracao: [''],
      ativo: [true],
      dateTemp: [null]
    });

    setTimeout(() => {
      if ((this.establishment || <any>{}).id_categoria)
        this.establishment.id_categoria = <any>(this.categories || []).filter(f => f.id == this.establishment.id_categoria)[0];

      this.establishmentForm.patchValue(this.establishment || {});
    }, 1000);

    this.businessTypeService.getAllBusinessTypes().subscribe(res => {
      this.establishmentForm.get('id_tipo').setValue((res.filter(item => item.nome === 'Estabelecimento')[0]).id);
    });

    if ((this.establishment || <Model.App.Business>{}).data_expiracao)
      this.establishmentForm.get('dateTemp').setValue(new Date(this.establishment.data_expiracao));

  }

  public save() {

    if (this.establishmentForm.invalid) return;

    this.establishment = this.establishmentForm.value;

    this.establishment.id_categoria = '1';

    let file: File = this.fileUpload.nativeElement.files[0];
    if (this.establishment.id) {
      this.businessService.updateFranchise(this.establishment, file).subscribe(res => this.callbackAction('alterada', res));
    }
    else {
      this.businessService.createFranchise(this.establishment, file).subscribe(res => this.callbackAction('criada', res));
    }
  }


  public isFieldInvalid(field: string) {
    return this.globalService.isFieldInvalid(field, this.establishmentForm);
  }


  public callbackAction(action, res) {

    this.toastrService.success('<span class="now-ui-icons ui-1_bell-53"></span>O Estabelecimento <b> ' + res.nome + ' </b> foi ' + action + ' com sucesso.', '', {
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
    this.establishmentForm.get('data_expiracao').setValue(date);
  }

  searchSubmit($event) {

    if (!this.searchTerm)
      this.getPlaylists();

    this.playlistsGrid = this.playlists.filter((item) => (item.nome || '').toLowerCase().indexOf(this.searchTerm.toLowerCase()) >= 0);
  }

  filesDialog(){
    const modalRef = this.modalService.open(PlaylistFilesComponent, {
      backdrop: 'static',
      size: 'lg'
    });

    modalRef.componentInstance.name = 'Playlist Itens';



    modalRef.result.then((res: Model.App.Playlist) => {
      if (res == null) return;

      this.getPlaylists();

    }).catch(err => {
      console.log(err);
    });
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
  readURL(event): void {
    if (event.target.files && event.target.files[0]) {
        const file = event.target.files[0];

        const reader = new FileReader();
        reader.onload = e => this.imageSrc = reader.result.toString();

        reader.readAsDataURL(file);
    }
}
}
