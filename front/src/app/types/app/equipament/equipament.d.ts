
declare namespace Model.App {
    export interface Equipament {
        id: string,
        nome: string,
        descricao: string,
        mac_address: string
        id_franquia: string,
        id_estabelecimento: string,
        id_playlist: string,
        ativo: boolean
    }
}

