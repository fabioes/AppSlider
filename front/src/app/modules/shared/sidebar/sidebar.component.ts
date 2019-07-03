import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    charName: string
}
export const ROUTES: RouteInfo[] = [
    { path: '/adm/dashboard', title: 'Dashboard',  icon: 'design_app', class: '', charName: 'dashboard'},
    { path: '/adm/usuarios', title: 'Usuários',  icon: 'users_single-02', class: '', charName: 'usuarios' },
    { path: '/adm/categorias', title: 'Categorias',  icon: 'design_bullet-list-67', class: '', charName: 'categorias' },
    { path: '/adm/tipos-negocio', title: 'Tipos de Negócio',  icon: 'files_single-copy-04', class: '', charName: 'tipos-negocio' },
    { path: '/adm/franquias', title: 'Franquias',  icon: 'travel_istanbul', class: '', charName: 'franquias' },
    { path: '/adm/estabelecimentos', title: 'Estabelecimentos',  icon: 'business_bank', class: '', charName: 'estabelecimentos' },
    { path: '/adm/anunciantes', title: 'Anunciantes',  icon: 'users_circle-08', class: '', charName: 'anunciantes' },
    { path: '/adm/playlists', title: 'Playlists',  icon: 'media-1_button-play', class: '', charName: 'playlists' },
    { path: '/adm/equipamentos', title: 'Equipamentos',  icon: 'tech_tablet', class: '', charName: 'equipamentos' },
    
    // { path: '/adm/icons', title: 'Icons',  icon:'education_atom', class: '', charName: 'icons' },
    // { path: '/maps', title: 'Maps',  icon:'location_map-big', class: '' },
    // { path: '/notifications', title: 'Notifications',  icon:'ui-1_bell-53', class: '' },

    // { path: '/user-profile', title: 'User Profile',  icon:'users_single-02', class: '' },
    // { path: '/table-list', title: 'Table List',  icon:'design_bullet-list-67', class: '' },
    // { path: '/typography', title: 'Typography',  icon:'text_caps-small', class: '' },
    // { path: '/upgrade', title: 'Upgrade to PRO',  icon:'objects_spaceship', class: 'active active-pro' }

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ( window.innerWidth > 991) {
          return false;
      }
      return true;
  };
}
