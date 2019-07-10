// import { Directive } from "@angular/core";
// import { NgControl } from "@angular/forms";

// @Directive({
//     selector: '[cpfcnpj]',
//     host: {
//         '(ngModelChange)': 'onInputChange($event)'
//     }
// })
// export class CpfCnpjMaskDirective {

//     constructor(public model: NgControl) { }

//     onInputChange(event) {

//         if (!event) return false;

//         let nextValue = event.replace(/\D/g, '');

//         if (nextValue.length == 0) {
//             nextValue = '';
//         } else if (nextValue.length <= 3) {
//             nextValue = nextValue.replace(/([0-9]{1,3})?/, '$1');
//         } else if (nextValue.length > 3 && nextValue.length <= 6) {
//             nextValue = nextValue.replace(/([0-9]{3})([0-9]{1,3})?/, '$1.$2');

//         }
//         else if (nextValue.length > 6 && nextValue.length <= 9) {
//             nextValue = nextValue.replace(/([0-9]{3})([0-9]{3})([0-9]{1,3})?/, '$1.$2.$3');

//         } else if (nextValue.length > 9 && nextValue.length <= 11) {
//             nextValue = nextValue.replace(/([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{1,2})?/, '$1.$2.$3-$4');
//             nextValue = nextValue.substring(0, 14);
//         } else {
//             //  CNPJ
//             if (nextValue.length <= 12) {
//                 nextValue = nextValue.replace(/([0-9]{2})([0-9]{3})([0-9]{3})([0-9]{1,4})?/, '$1.$2.$3/$4');
//             }
//             else {
//                 nextValue = nextValue.replace(/([0-9]{2})([0-9]{3})([0-9]{3})([0-9]{1,4})([0-9]{1,2})?/, '$1.$2.$3/$4-$5');
//             }
//         }

//         if (nextValue.length > 14) {
//             nextValue = nextValue.substring(0, 18);
//         }

//         this.model.valueAccessor.writeValue(nextValue);

//         if (this.model.control.untouched) {
//             this.model.control.markAsTouched();
//         }
//     }
// }