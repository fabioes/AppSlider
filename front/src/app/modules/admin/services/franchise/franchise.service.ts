import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class FranchiseService {

    private franchise: Model.App.UserFranchise = null;
    
    constructor() { }

    get Franchise(){
        return this.franchise;
    }

    set Franchise(franchise : Model.App.UserFranchise){
        this.franchise = franchise;
    }
}