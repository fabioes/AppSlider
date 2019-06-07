export const environment = {
  production: true,
  apiConfig: {
    baseUrl: "http://www.odoias.com.br/midiafoneapi/api",
    apiRoutes: {
      login: {
        default: "/login"
      },
      user: {
        default: "/users",
        switchActive: "/users/switch_active",
        resetPassword: "/users/reset_password"
      },
      category: {
        default: "/categories"
      },
      business_type: {
        default: "/business_type"
      },
      business: {
        default: "/business",
        switchActive: "/business/switch_active"
      }
    }
  }
};
