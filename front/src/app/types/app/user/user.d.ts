declare namespace Model.App {
    export interface User {
        id: string,
        login: string,
        senha: string,
        perfil: string,
        ativo: boolean,
        bloqueado: boolean,
        nome: string,
        email: string,
        franquias: Array<string>,
        roles: Array<string>
    }

    export interface UserResetPassword {
        id: string,
        senha: string
    }

    export interface Role {
        id: string,
        nome: string,
        descricao: string
    }
}