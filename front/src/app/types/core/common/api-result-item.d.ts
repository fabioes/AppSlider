declare namespace Model.Core {
    export interface ApiResultItem<T> {
        sucesso: boolean,
        item: T,
        mensagem: Model.App.ApiReturnMessage
    }
}