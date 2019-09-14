import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    charName: string;
    menuRole: string;
}

// public const String ReadUser = "AppSlider.Read.User";
//         public const String WriteUser = "AppSlider.Write.User";
//         public const String ReadBusiness = "AppSlider.Read.Business";
//         public const String WriteBusiness = "AppSlider.Write.Business";
//         public const String ReadBusinessType = "AppSlider.Read.BusinessType";
//         public const String WriteBusinessType = "AppSlider.Write.BusinessType";
//         public const String ReadCategory = "AppSlider.Read.Category";
//         public const String WriteCategory = "AppSlider.Write.Category";
//         public const String ReadPlaylist = "AppSlider.Read.Playlist";
//         public const String WritePlaylist = "AppSlider.Write.Playlist";
//         public const String ReadEquipament = "AppSlider.Read.Equipament";
//         public const String WriteEquipament = "AppSlider.Write.Equipament";

export const ROUTES: RouteInfo[] = [
    //{ path: '/adm/dashboard', title: 'Dashboard',  icon: 'design_app', class: '', charName: 'dashboard'},
    { path: '/adm/usuarios', title: 'Usuários',  icon: 'users_single-02', class: '', charName: 'usuarios', menuRole: 'AppSlider.Read.x' },
    // { path: '/adm/categorias', title: 'Categorias',  icon: 'design_bullet-list-67', class: '', charName: 'categorias', menuRole: 'AppSlider.Read.Category' },
    // { path: '/adm/tipos-negocio', title: 'Tipos de Negócio',  icon: 'files_single-copy-04', class: '', charName: 'tipos-negocio', menuRole: 'AppSlider.Read.BusinessType' },
    { path: '/adm/franquias', title: 'Franquias',  icon: 'travel_istanbul', class: '', charName: 'franquias', menuRole: 'AppSlider.Write.y' },
    { path: '/adm/estabelecimentos', title: 'Estabelecimentos',  icon: 'business_bank', class: '', charName: 'estabelecimentos', menuRole: 'AppSlider.Read.Business' },
    { path: '/adm/anunciantes', title: 'Anunciantes',  icon: 'users_circle-08', class: '', charName: 'anunciantes', menuRole: 'AppSlider.Read.Business' },
    { path: '/adm/equipamentos', title: 'Equipamentos',  icon: 'tech_tablet', class: '', charName: 'equipamentos', menuRole: 'AppSlider.Read.Business' },
    { path: '/adm/curiosidades', title: 'Curiosidades Midiafone',  icon: 'education_atom', class: '', charName: 'curiosidades', menuRole: 'AppSlider.Read.Business' },
    { path: '/adm/midiafone', title: 'Midiafone',  icon: 'objects_spaceship', class: '', charName: 'midiafone', menuRole: 'AppSlider.Read.Business' },

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
