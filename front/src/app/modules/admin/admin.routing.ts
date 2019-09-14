import { Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { IconsComponent } from './components/icons/icons.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { UserComponent } from './components/user/user.component';
import { CategoryComponent } from './components/category/category.component';
import { BusinessTypeComponent } from './components/business-type/business-type.component';
import { FranchiseComponent } from './components/franchise/franchise.component';
import { EstablishmentComponent } from './components/establishment/establishment.component';
import { AdvertiserComponent } from './components/advertiser/advertiser.component';
import { EquipamentComponent } from './components/equipament/equipament.component';
import { PlaylistFilesComponent } from './components/playlist/playlist-files/playlist-files.component';
import { CuriositiesComponent } from './components/curiosities/curiosities.component';
import { MidiafoneComponent } from './components/midiafone/midiafone.component';

export const AdminRoutes: Routes = [
    { path: 'dashboard', component: DashboardComponent },
    { path: 'welcome', component: WelcomeComponent },
    { path: 'usuarios', component: UserComponent },
    { path: 'categorias', component: CategoryComponent },
    { path: 'tipos-negocio', component: BusinessTypeComponent },
    { path: 'franquias', component: FranchiseComponent },
    { path: 'estabelecimentos', component: EstablishmentComponent },
    { path: 'anunciantes', component: AdvertiserComponent },
    { path: 'curiosidades', component: CuriositiesComponent },
    { path: 'midiafone', component: MidiafoneComponent },
    { path: 'equipamentos', component: EquipamentComponent },
    { path: 'icons', component: IconsComponent }
];
