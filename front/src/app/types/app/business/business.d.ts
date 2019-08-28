declare namespace Model.App {
    export interface Business {
        id: string,
        nome: string,
        CNPJ: number,
        id_pai: string,
        id_tipo: string,
        id_categoria: string,
        id_logo: string,
        contato_nome: string,
        contato_email: string,
        contato_telefone: string,
        contato_endereco: string,
        data_expiracao: Date,
        ativo: boolean,
        bloqueado: boolean,
        categoria:Model.App.Category,
        tipo: Model.App.BusinessType,
        file:any,
        pai: Model.App.Business,
        filhos: Array<Model.App.Business>,
        equipaments: Array<Model.App.Equipament>
    }

}
