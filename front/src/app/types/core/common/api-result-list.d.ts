declare namespace Model.Core {
    export interface ApiResultList<T> {
        sucesso: boolean,
        items: Array<T>,
        mensagem: Model.App.ApiReturnMessage
    }
}