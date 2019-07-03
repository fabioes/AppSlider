import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {

    constructor(private httpHelper: HttpHelper) { }

    public getAllCategories(): Observable<Array<Model.App.Category>> {
        return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Category>>(environment.apiConfig.apiRoutes.category.default)
            .pipe(map(res => res.items));
    }

    public getCategory(id: string) {
        return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Category>>(environment.apiConfig.apiRoutes.category.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public createCategory(Category: Model.App.Category) {
        return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.Category>>(environment.apiConfig.apiRoutes.category.default, Category)
            .pipe(map(res => res.item));
    }

    public updateCategory(Category: Model.App.Category) {
        return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Category>>(environment.apiConfig.apiRoutes.category.default, Category)
            .pipe(map(res => res.item));
    }

    public deleteCategory(id: string) : Observable<Boolean>{
        return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.category.default + '/' + id)
            .pipe(map(res => res.item));
    }
}