import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';

/** prime ng */
import {DropdownModule} from 'primeng/dropdown'
import { FormsModule } from '@angular/forms';

//directives
import { PermissionMenuCheckDirective } from '../admin/directives/auth/permission-check.directive';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgbModule,
    FormsModule,
    //primeng
    DropdownModule
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,

    //directives
    PermissionMenuCheckDirective
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,

    //directives
    PermissionMenuCheckDirective
  ]
})
export class ComponentsModule { }
