import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'phoneFormat' })
export class PhonePipe implements PipeTransform {
    transform(value: number): string {

        let nextValue = (value || 0).toString();

        if (nextValue.length > 5 && nextValue[4] === '9') {
            nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{5})([0-9]{4})?/, '+$1 ($2) $3-$4');
            nextValue = nextValue.substring(0, 19);
        } else {
            nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{4})([0-9]{4})?/, '+$1 ($2) $3-$4');
            nextValue = nextValue.substring(0, 18);
        }

        return nextValue
    }
}