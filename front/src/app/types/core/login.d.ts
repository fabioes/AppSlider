declare namespace Model.Core{
    export interface Login{
        sucesso: boolean,
        data_criacao: string,
        data_expiracao: string,
        token: string,
        usuario: string,
        perfil_usuario: string
    }

    export interface LoginClaims{
        unique_name: string,
        roles: Array<string>
    }
}