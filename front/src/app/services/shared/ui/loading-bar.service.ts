import { Injectable, EventEmitter } from '@angular/core';


@Injectable({
    providedIn: 'root'
})
export class LoadingBarService {

    public initialized: boolean = false
    public showBarChange : EventEmitter<Boolean>;
    private showBar : boolean = false;

    constructor() { 
        this.showBarChange = new EventEmitter();
    }

    public showLoadingBar(){
        this.showBar = true;
        this.showBarChange.emit(this.showBar);
    }

    public hideLoadingBar(){
        this.showBar = false;
        this.showBarChange.emit(this.showBar);
    }
}