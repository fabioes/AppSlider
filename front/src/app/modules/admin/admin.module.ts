import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRoutes } from './admin.routing';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserComponent } from './components/user/user.component';
import { UserFormComponent } from './components/user/user-form/user-form.component';
import { UserResetPasswordComponent } from './components/user/user-reset-password/user-reset-password.component';
import { CategoryComponent } from './components/category/category.component';
import { CategoryFormComponent } from './components/category/category-form/category-form.component';
import { BusinessTypeComponent } from './components/business-type/business-type.component';
import { BusinessTypeFormComponent } from './components/business-type/business-type-form/business-type-form.component';
import { FranchiseComponent } from './components/franchise/franchise.component';
import { FranchiseFormComponent } from './components/franchise/franchise-form/franchise-form.component';
import { AdvertiserComponent } from './components/advertiser/advertiser.component';
import { AdvertiserFormComponent } from './components/advertiser/advertiser-form/advertiser-form.component';
import { EstablishmentComponent } from './components/establishment/establishment.component';
import { EstablishmentFormComponent } from './components/establishment/establishment-form/establishment-form.component';
import { PlaylistComponent } from './components/playlist/playlist.component';
import { PlaylistFormComponent } from './components/playlist/playlist-form/playlist-form.component';
import { PlaylistFilesComponent } from './components/playlist/playlist-files/playlist-files.component';
import { EquipamentComponent } from './components/equipament/equipament.component';
import { EquipamentFormComponent } from './components/equipament/equipament-form/equipament-form.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { IconsComponent } from './components/icons/icons.component';
import { ChartsModule } from 'ng2-charts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';



//primeng
import { AccordionModule } from 'primeng/accordion';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { FileUploadModule } from 'primeng/fileupload';
import { CheckboxModule } from 'primeng/checkbox';
import { DialogModule } from 'primeng/dialog'
import { ConfirmDialogModule } from 'primeng/confirmdialog'
import { CalendarModule } from 'primeng/calendar';
import { MultiSelectModule } from 'primeng/multiselect';
import {PasswordModule} from 'primeng/password';
//pipes
import { PhonePipe } from './shared/pipes/phone.pipe';
import { DateFormat } from './shared/pipes/date-format.pipe'

//directives
import { PhoneMaskDirective } from './directives/masks/phone-mask.directive';
import { CuriositiesComponent } from './components/curiosities/curiosities.component';
import { CuriositiesFormComponent } from './components/curiosities/curiosities-form/curiosities-form.component';
import { MidiafoneFormComponent } from './components/midiafone/midiafone-form/midiafone-form.component';
import { MidiafoneComponent } from './components/midiafone/midiafone.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminRoutes),
    FormsModule,
    ReactiveFormsModule,
    ChartsModule,
    NgbModule,
    ToastrModule.forRoot(),
    //primeng
    AccordionModule,
    TableModule,
    DropdownModule,
    CheckboxModule,
    FileUploadModule,
    DialogModule,
    ConfirmDialogModule,
    CalendarModule,
    MultiSelectModule,
    PasswordModule,
  ],
  declarations: [
    DashboardComponent,
    UserComponent,
    UserFormComponent,
    UserResetPasswordComponent,
    WelcomeComponent,
    CategoryComponent,
    CategoryFormComponent,
    BusinessTypeComponent,
    BusinessTypeFormComponent,
    FranchiseComponent,
    FranchiseFormComponent,
    AdvertiserComponent,
    AdvertiserFormComponent,
    EstablishmentComponent,
    EstablishmentFormComponent,
    CuriositiesComponent,
    CuriositiesFormComponent,
    PlaylistComponent,
    PlaylistFormComponent,
    PlaylistFilesComponent,
    EquipamentComponent,
    EquipamentFormComponent,
    MidiafoneFormComponent,
    MidiafoneComponent,
    IconsComponent,
    DateFormat,
    PhonePipe,
    PhoneMaskDirective
  ],
  // tslint:disable-next-line: max-line-length
  entryComponents: [UserFormComponent, UserResetPasswordComponent, CategoryFormComponent, BusinessTypeFormComponent, FranchiseFormComponent, AdvertiserFormComponent, EstablishmentFormComponent,
    PlaylistFormComponent, PlaylistFilesComponent, PlaylistComponent
    , EquipamentFormComponent, CuriositiesFormComponent, MidiafoneFormComponent]
})

export class AdminModule { }
