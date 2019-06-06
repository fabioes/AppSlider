import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root' 
})
export class BusinessService {

    constructor(private httpHelper: HttpHelper) { }

    public getAllBusinesss(): Observable<Array<Model.App.Business>> {
        return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default)
            .pipe(map(res => res.items));
    }

    public getBusiness(id: string) {
        return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public createBusiness(Business: Model.App.Business) {
        return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default, Business)
            .pipe(map(res => res.item));
    }

    public updateBusiness(Business: Model.App.Business) {
        return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.default, Business)
            .pipe(map(res => res.item));
    }

    public deleteBusiness(id: string) : Observable<Boolean>{
        return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.business.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public switchActive(id: string): any {
        return this.httpHelper.HttpPatch<Model.Core.ApiResultItem<Model.App.Business>>(environment.apiConfig.apiRoutes.business.switchActive + '/' + id)
            .pipe(map(res => res.item));
      }
     
}