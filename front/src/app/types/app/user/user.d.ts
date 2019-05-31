declare namespace Model.App {
    export interface User {
        id: string,
        login: string,
        senha: string,
        perfil: string,
        ativo: boolean,
        nome: string,
        email: string,
        franquias: string,
        roles: string
    }

    export interface UserResetPassword {
        id: string,
        senha: string
    }
}