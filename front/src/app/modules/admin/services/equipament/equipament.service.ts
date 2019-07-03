import { Injectable } from '@angular/core';
import { HttpHelper } from '../../../../helpers/http.helper';
import { environment } from '../../../../../environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FranchiseService } from '../franchise/franchise.service';


@Injectable({
    providedIn: 'root'
})
export class EquipamentService {

    constructor(private httpHelper: HttpHelper, private franchiseService: FranchiseService) { }

    public getAllEquipaments(): Observable<Array<Model.App.Equipament>> {
        return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.default)
            .pipe(map(res => res.items));
    }
    
    public getByFranchise(): Observable<Array<Model.App.Equipament>> {
        return this.httpHelper.HttpGet<Model.Core.ApiResultList<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.get_by_franchise + '/' + this.franchiseService.Franchise.id)
            .pipe(map(res => res.items));
    }

    public getEquipament(id: string) {
        return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public getByMacAddress(macAddress: string) {
        return this.httpHelper.HttpGet<Model.Core.ApiResultItem<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.get_by_mac_address + '/' + macAddress)
            .pipe(map(res => res.item));
    }

    public createEquipament(equipament: Model.App.Equipament) {
        return this.httpHelper.HttpPost<Model.Core.ApiResultItem<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.default, equipament)
            .pipe(map(res => res.item));
    }

    public updateEquipament(equipament: Model.App.Equipament) {
        return this.httpHelper.HttpPut<Model.Core.ApiResultItem<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.default, equipament)
            .pipe(map(res => res.item));
    }

    public deleteEquipament(id: string): Observable<Boolean> {
        return this.httpHelper.HttpDelete<Model.Core.ApiResultItem<Boolean>>(environment.apiConfig.apiRoutes.equipament.default + '/' + id)
            .pipe(map(res => res.item));
    }

    public switchActive(id: string): any {
        return this.httpHelper.HttpPatch<Model.Core.ApiResultItem<Model.App.Equipament>>(environment.apiConfig.apiRoutes.equipament.switchActive + '/' + id)
            .pipe(map(res => res.item));
    }
}