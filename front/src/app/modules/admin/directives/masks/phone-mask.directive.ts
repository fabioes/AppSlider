import { Directive, AfterViewChecked } from "@angular/core";
import { NgControl } from "@angular/forms";

@Directive({
    selector: '[phone]',
    host: {
        '(ngModelChange)': 'onInputChange($event)',
        '(keydown.backspace)': 'onInputChange($event.target.value, true)'
    }
})
export class PhoneMaskDirective implements AfterViewChecked {
    countMask: number = 0;
    ngAfterViewChecked(): void {
        if (this.model && this.model.value && this.countMask < 2) {
            this.onInputChange(this.model.value, false);
            this.countMask++;
        }
    }

    constructor(public model: NgControl) { }

    onInputChange(event, backspace) {

        if (!event) return false;

        let nextValue = event.replace(/\D/g, '');

        if (backspace) {
            nextValue = nextValue.substring(0, nextValue.length - 1);
        }
        if (nextValue.length == 0) {
            nextValue = '';
        } else if (nextValue.length <= 2) {
            nextValue = nextValue.replace(/([0-9]{1,2})?/, '+$1');
        } else if (nextValue.length > 2 && nextValue.length <= 4) {
            nextValue = nextValue.replace(/([0-9]{1,2})([0-9]{1,2})?/, '+$1 ($2');
            nextValue = nextValue.substring(0, 7);
        }//+55 (00) 90000-0000
        else if (nextValue.length == 5) {
            nextValue = nextValue.replace(/([0-9]{1,2})([0-9]{1,2})([0-9]{1,5})?/, '+$1 ($2) $3');
            nextValue = nextValue.substring(0, 10);
        } else if (nextValue.length > 5 && nextValue[4] === '9') {
            if (nextValue.length < 10) {
                nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{5})?/, '+$1 ($2) $3');
            } else if (nextValue.length >= 10 && nextValue.length < 11) {
                nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{5})([0-9]{4})?/, '+$1 ($2) $3-$4');
            } else if (nextValue.length >= 11) {
                nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{5})([0-9]{4})?/, '+$1 ($2) $3-$4');
            }
            nextValue = nextValue.substring(0, 19);
        } else {
            if (nextValue.length >= 5 && nextValue.length < 9) {
                nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{4})?/, '+$1 ($2) $3');
            } else if (nextValue.length >= 9) {
                nextValue = nextValue.replace(/([0-9]{2})([0-9]{2})([0-9]{4})([0-9]{4})?/, '+$1 ($2) $3-$4');
            }
            nextValue = nextValue.substring(0, 18);
        }

        this.model.valueAccessor.writeValue(nextValue);

        if (!nextValue)
            this.model.control.setErrors({
                key: "required"
            });

        return false;
    }
}