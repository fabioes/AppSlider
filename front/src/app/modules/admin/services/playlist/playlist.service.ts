import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FranchiseService } from '../franchise/franchise.service';


@Injectable({
  providedIn: 'root'
})
export class PlaylistService {

  constructor(private httpHelper: HttpHelper, private franchiseService: FranchiseService) { }

  public getAllPlaylists(): Observable<Array<Model.App.Playlist>> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.default)
      .pipe(map(res => res.items));
  }

  public getByFranchise(): Observable<Array<Model.App.Playlist>> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.getByFranchise + '/' + this.franchiseService.Franchise.id)
      .pipe(map(res => res.items));
  }
  public getByBusiness(id: string): Observable<Model.App.Playlist> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.getByBusiness + '/' + id)
      .pipe(map(res => res.item));
  }
  public getPlaylist(id: string): Observable<Model.App.Playlist> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.default + '/' + id)
      .pipe(map(res => res.item));
  }

  public createPlaylist(playlist: Model.App.Playlist): Observable<Model.App.Playlist> {
    return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.default, playlist)
      .pipe(map(res => res.item));
  }

  public updatePlaylist(playlist: Model.App.Playlist): Observable<Model.App.Playlist> {
    return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.default, playlist)
      .pipe(map(res => res.item));
  }

  public deletePlaylist(id: string): Observable<Boolean> {
    return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.playlist.default + '/' + id)
      .pipe(map(res => res.item));
  }

  public switchActive(id: string): Observable<Model.App.Playlist> {
    return this.httpHelper.HttpPatch<Model.Core.ApiResultItem<Model.App.Playlist>>(environment.apiConfig.apiRoutes.playlist.switchActive + '/' + id)
      .pipe(map(res => res.item));
  }

  public addItem(playlistItem: Model.App.PlaylistItemRequest, file: File): Observable<Model.App.PlaylistItem> {
    let form: FormData = new FormData();
    form.append('value', JSON.stringify(playlistItem));
    form.append('files', file, file.name);
    return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.PlaylistItem>>(environment.apiConfig.apiRoutes.playlist.playlistItem, form)
      .pipe(map(res => res.item));
  }

  public removeItem(idBusiness: string, id: string): Observable<Boolean> {
    return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.playlist.playlistItem + '/' + idBusiness + '/' + id)
      .pipe(map(res => res.item));
  }
}
