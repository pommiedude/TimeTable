import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import * as moment from "moment";

// import { FormControl } from "@angular/forms";

// export function DateValidator(format = ): any {
//   return (control: FormControl): { [key: string]: any } => {
//     
//     console.log('date validate');
//     if (!val.isValid()) {
//       return { invalidDate: true };
//     }
//     return null;
//   };

export class AppCustomDirective extends Validators{

  static validDate(fdValue: FormControl) {
    const val = moment(fdValue.value);
    if (!val.isValid()) 
      return { validDate: true };
  
  }

   static fromDateValidator(fdValue: FormControl) {
    const date = fdValue.value;

    if (date ===null || date==='')
      return { requiredFromDate: true };
  }

   static ToDateValidator(todValue: FormControl) {
    const date = todValue.value;
   
    if (date ===null || date==='') return { requiredToDate: true };
  
  }

}