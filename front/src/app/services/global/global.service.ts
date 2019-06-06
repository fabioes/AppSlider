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

    public getPrimeCalendarPtConfig() {
        return {
            firstDayOfWeek: 0,
            dayNames: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado"],
            dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
            dayNamesMin: ["D", "S", "T", "Q", "Q", "S", "S"],
            monthNames: ["Janeiro", "Fevereiro", "Marco", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
            monthNamesShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
            today: 'Hoje',
            clear: 'Apagar'
        };
    }
}