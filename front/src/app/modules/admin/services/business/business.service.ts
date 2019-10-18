import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FranchiseService } from '../franchise/franchise.service';
import { HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BusinessService {

  constructor(private httpHelper: HttpHelper, private franchiseService: FranchiseService) { }

  public getAllBusinesss(): Observable<Array<Model.App.Business>> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default)
      .pipe(map(res => res.items));
  }

  public getByType(type: string): Observable<Array<Model.App.Business>> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Business>>(environment.apiConfig.apiRoutes.business.get_by_type + '/' + type)
      .pipe(map(res => res.items));
  }

  public getByFranchiseAndType(type: string): Observable<Array<Model.App.Business>> {
    return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Business>>(environment.apiConfig.apiRoutes.business.get_by_type + '/' + this.franchiseService.Franchise.id + '/' + type)
      .pipe(map(res => res.items));
  }

  public getBusiness(id: string) {
    return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default + '/' + id)
      .pipe(map(res => res.item));
  }

  public getForLoggedUser() {
    return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Business>>(environment.apiConfig.apiRoutes.business.get_for_logged_user)
      .pipe(map(res => res.items));
  }

  public createBusiness(Business: Model.App.Business) {
    return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default, Business)
      .pipe(map(res => res.item));
  }

  public updateBusiness(Business: Model.App.Business) {
    return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default, Business)
      .pipe(map(res => res.item));
  }
  public updateAdvertiser(Business: Model.App.Business) {
    return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.advertiser, Business)
      .pipe(map(res => res.item));
  }
  public createFranchise(Business: Model.App.Business, file: File) {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');
    let form: FormData = new FormData();
    form.append('value', JSON.stringify(Business));
    if(file){
    form.append('files', file, file.name);
    }
    return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.franchise, form)
      .pipe(map(res => res.item));
  }

  public updateFranchise(Business: Model.App.Business, file: File): Observable<any> {
    let form: FormData = new FormData();

    form.append('value', JSON.stringify(Business));

    if(file) {
    form.append('files', file,file.name);
    }
    return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.franchise, form,)
      .pipe(map(res => res.item));
  }

  public deleteBusiness(id: string): Observable<Boolean> {
    return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.business.default + '/' + id)
      .pipe(map(res => res.item));
  }

  public switchActive(id: string): any {
    return this.httpHelper.HttpPatch<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.switchActive + '/' + id)
      .pipe(map(res => res.item));
  }
}
