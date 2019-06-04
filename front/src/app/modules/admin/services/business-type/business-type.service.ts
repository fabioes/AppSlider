import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class BusinessTypeService {

    constructor(private httpHelper: HttpHelper) { }

    public getAllBusinessTypes(): Observable<Array<Model.App.BusinessType>> {
        return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.BusinessType>>(environment.apiConfig.apiRoutes.business_type.default)
            .pipe(map(res => res.items));
    }

    public getBusinessType(id: string) {
        return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.BusinessType>>(environment.apiConfig.apiRoutes.business_type.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public createBusinessType(BusinessType: Model.App.BusinessType) {
        return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.BusinessType>>(environment.apiConfig.apiRoutes.business_type.default, BusinessType)
            .pipe(map(res => res.item));
    }

    public updateBusinessType(BusinessType: Model.App.BusinessType) {
        return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.BusinessType>>(environment.apiConfig.apiRoutes.business_type.default, BusinessType)
            .pipe(map(res => res.item));
    }

    public deleteBusinessType(id: string) : Observable<Boolean>{
        return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.business_type.default + '/' + id)
            .pipe(map(res => res.item));
    }
}