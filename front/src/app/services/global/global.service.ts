import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
})
export class GlobalService {

    constructor(private router: Router, private activedRoute: ActivatedRoute) { }

    public isFieldInvalid(field: string, form: FormGroup, formSubmitAttempt?: boolean): boolean {

        var formValue = form.get(field);

        if (!formValue) return false;

        return (
            (!formValue.valid && formValue.touched) ||
            (formValue.untouched && (formSubmitAttempt == null ? false : formSubmitAttempt)));
    }

    public getQueryParameter(name: string, hasChild: boolean): Observable<any> {
        return <Observable<any>><any>(hasChild === true
            ? this.activedRoute.firstChild.params.pipe(map(params => params[name]))
            : this.activedRoute.params.pipe(map(params => params[name])));
    }
}