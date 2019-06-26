import { Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { TableListComponent } from './components/table-list/table-list.component';
import { TypographyComponent } from './components/typography/typography.component';
import { IconsComponent } from './components/icons/icons.component';
import { MapsComponent } from './components/maps/maps.component';
import { NotificationsComponent } from './components/notifications/notifications.component';
import { UpgradeComponent } from './components/upgrade/upgrade.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { UserComponent } from './components/user/user.component';
import { CategoryComponent } from './components/category/category.component';
import { BusinessTypeComponent } from './components/business-type/business-type.component';
import { FranchiseComponent } from './components/franchise/franchise.component';
import { EstablishmentComponent } from './components/establishment/establishment.component';
import { AdvertiserComponent } from './components/advertiser/advertiser.component';

export const AdminRoutes: Routes = [
    { path: 'dashboard',        component: DashboardComponent },
    { path: 'welcome',          component: WelcomeComponent },
    { path: 'usuarios',         component: UserComponent },
    { path: 'categorias',       component: CategoryComponent },
    { path: 'tipos-negocio',    component: BusinessTypeComponent },
    { path: 'franquias',        component: FranchiseComponent },
    { path: 'estabelecimentos', component: EstablishmentComponent },
    { path: 'anunciantes',      component: AdvertiserComponent },

    // { path: 'user-profile',   component: UserProfileComponent },
    // { path: 'table-list',     component: TableListComponent },
    // { path: 'typography',     component: TypographyComponent },
     { path: 'icons',          component: IconsComponent },
    // { path: 'maps',           component: MapsComponent },
    // { path: 'notifications',  component: NotificationsComponent },
    // { path: 'upgrade',        component: UpgradeComponent }
];
