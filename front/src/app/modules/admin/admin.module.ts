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
import { WelcomeComponent } from './components/welcome/welcome.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { TableListComponent } from './components/table-list/table-list.component';
import { TypographyComponent } from './components/typography/typography.component';
import { IconsComponent } from './components/icons/icons.component';
import { MapsComponent } from './components/maps/maps.component';
import { NotificationsComponent } from './components/notifications/notifications.component';
import { ChartsModule } from 'ng2-charts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { UpgradeComponent } from './components/upgrade/upgrade.component';

//primeng
import { AccordionModule } from 'primeng/accordion';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { FileUploadModule } from 'primeng/fileupload';
import { CheckboxModule } from 'primeng/checkbox';
import { DialogModule } from 'primeng/dialog'
import { ConfirmDialogModule } from 'primeng/confirmdialog'
import { CalendarModule } from 'primeng/calendar';

//pipes
import { PhonePipe } from './shared/pipes/phone.pipe';
import { DateFormat} from './shared/pipes/date-format.pipe'


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
    CalendarModule
  ],
  declarations: [
    DashboardComponent,
    UserComponent,
    UserFormComponent,
    UserResetPasswordComponent,
    WelcomeComponent,
    UserProfileComponent,
    CategoryComponent,
    CategoryFormComponent,
    BusinessTypeComponent,
    BusinessTypeFormComponent,
    FranchiseComponent,
    FranchiseFormComponent,
    TableListComponent,
    UpgradeComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    DateFormat,
    PhonePipe
  ],
  entryComponents: [UserFormComponent, UserResetPasswordComponent, CategoryFormComponent, BusinessTypeFormComponent, FranchiseFormComponent]
})

export class AdminModule { }
