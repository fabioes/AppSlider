
declare namespace Model.App {
    export interface Equipament {
        id: string,
        nome: string,
        descricao: string,
        mac_address: string
        id_franquia: string,
        id_estabelecimento: string,
        establishment: Model.App.Business,
        id_playlist: string,
        ativo: boolean,
        advertiser_name: string 
    }
}

