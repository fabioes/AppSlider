declare namespace Model.App {
    export interface Playlist {
        id: string,
        nome: string,
        ativa: boolean,
        bloqueada: boolean,
        data_expiracao: Date,
        id_franquia: string,
        business: Model.App.Business,
        playlist_itens: Array<Model.App.PlaylistItem>        
    }

    export interface PlaylistItem{
        id: string,
        id_playlist: string,
        tipo: string,
        id_arquivo: string,
        tempo_duracao: number
    }

    export interface PlaylistItemRequest{
        id_playlist: string,
        business_id:string,
        business_type:number,
        tipo: string,
        tempo_duracao: number
    }
}