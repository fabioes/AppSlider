export const environment = {
  production: true,
  apiConfig: {
    baseUrl: "https://www.midiafone.com.br/midiafoneapi/api",
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
        advertiser: "/business/advertiser",
        franchise: "/business/franchise",
        switchActive: "/business/switch_active",
        get_by_type: "/business/GetByType",
        advertisers: "/business/advertisers",
        count: "/business/count",
        get_for_logged_user: "/business/GetForLoggedUser"
      },
      playlist: {
        default: "/playlist",
        switchActive: "/playlist/switch_active",
        getByFranchise: "/playlist/GetByFranchise",
        getbyMacAddress: "/playlist/GetByMacAddressEquipament",
        getByBusiness: "/playlist/business",
        playlistItem: "/playlist_file"
      },
      files: {
        default: "/files"
      },
      equipament: {
        default: "/equipament",
        get_by_franchise: "/equipament/GetByFranchise",
        getByEstablishments: "/equipament/GetByEstablishments",
        get_by_mac_address: "/equipament/GetByMacAddress",
        switchActive: "/equipament/switch_active"
      }
    }
  }
};
