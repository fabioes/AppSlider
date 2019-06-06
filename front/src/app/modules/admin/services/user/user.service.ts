import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class UserService {

    constructor(private httpHelper: HttpHelper) { }

    public getAllUsers(): Observable<Array<Model.App.User>> {
        return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.User>>(environment.apiConfig.apiRoutes.user.default)
            .pipe(map(res => res.items));
    }

    public getUser(id: string) {
        return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.User>>(environment.apiConfig.apiRoutes.user.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public createUser(user: Model.App.User) {
        return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.User>>(environment.apiConfig.apiRoutes.user.default, user)
            .pipe(map(res => res.item));
    }

    public updateUser(user: Model.App.User) {
        return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.User>>(environment.apiConfig.apiRoutes.user.default, user)
            .pipe(map(res => res.item));
    }

    public deleteUser(id: string) : Observable<Boolean>{
        return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.user.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public switchActive(id: string): any {
        return this.httpHelper.HttpPatch<Model.Core.ApiResultItem<Model.App.User>>(environment.apiConfig.apiRoutes.user.switchActive + '/' + id)
            .pipe(map(res => res.item));
      }

      public resetUserPassword(userReq: Model.App.UserResetPassword): any {
        return this.httpHelper.HttpPatch<Model.Core.ApiResultItem<Model.App.User>>(environment.apiConfig.apiRoutes.user.resetPassword, userReq)
            .pipe(map(res => res.item));
      }
}