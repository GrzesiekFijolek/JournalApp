import { ValidationErrors, ValidatorFn, AbstractControl } from "@angular/forms";

export class CustomValidators {

  static patternValidator(regex: RegExp, error: ValidationErrors): ValidatorFn {

    return (control: AbstractControl): { [key: string] : any} => {
      if(!control.value) {
        return null;
      }

    const valid = regex.test(control.value);

    return valid ? null : error;
    }
  }

  static passwordMatchValidator(control: AbstractControl) {
    const password: string = control.get('password').value;
    const confirm: string = control.get('confirm').value;

    if(password !== confirm){
      control.get('confirm').setErrors({noPasswordMatch: true});
    }
  }

}