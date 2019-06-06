import { Pipe, PipeTransform, Injectable } from '@angular/core';
import * as moment from 'moment';

@Pipe({ name: 'dateFormat' })
export class DateFormat implements PipeTransform {

    constructor() {
        moment.locale('pt-BR');
    }

    transform(value: Date, format: string): string {

        if (!value) return '';

        switch (format) {
            case 'full':
                return moment(value).format('dddd, LL, HH:mm:ss');
            case 'customShortDate':
                return moment(value).format('L LTS');
            default:
                return moment(value).format('L');
        }
    }
}