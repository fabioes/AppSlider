// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  apiConfig: {
    baseUrl: "http://localhost:65334/api",
    apiRoutes: {
      login: {
        default: "/login"
      },
      user: {
        default: "/users",
        switchActive: "/users/switch_active",
        resetPassword: "/users/reset_password",
        roles: "/users/roles"
      },
      category: {
        default: "/categories"
      },
      business_type: {
        default: "/business_type"
      },
      business: {
        default: "/business",
        franchise: "/business/franchise",
        switchActive: "/business/switch_active",
        get_by_type: "/business/GetByType",
        get_for_logged_user: "/business/GetForLoggedUser"
      },
      playlist: {
        default: "/playlist",
        switchActive: "/playlist/switch_active",
        getByFranchise: "/playlist/GetByFranchise",
        getByBusiness: "/playlist/business",
        getbyMacAddress: "/playlist/GetByMacAddressEquipament",
        playlistItem: "/playlist_file"
      },
      files:{
        default: "/files"
      },
      equipament:{
        default: "/equipament",
        get_by_franchise: "/equipament/GetByFranchise",
        getByEstablishments: "/equipament/GetByEstablishments",
        get_by_mac_address: "/equipament/GetByMacAddress",
        switchActive: "/equipament/switch_active"
      }
    }
  }
};
