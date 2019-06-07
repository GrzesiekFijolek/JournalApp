import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CustomValidators } from './custom-validators';
import { User } from 'src/app/models/user';
import { Location } from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  imagePath: any;
  imgURL: any;
  user: User;
  serverError: any;
  passwordHasNumberError: string;
  passwordHasSmallCaseError: string;
  passwordHasCapitalCaseError: string;
  passwordMinLengthError: string;
  usernameMinLengthError: string;
  usernameMaxLengthError: string;
  usernameForbiddenSignsError: string;
  passwordMatchError: string;

  constructor(private authService: AuthService, private formBulider: FormBuilder, private location: Location) { }

  ngOnInit() {
    this.user = new User();
   this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBulider.group(
      {
        username: new FormControl('', Validators.compose([ 
          Validators.minLength(3), 
          Validators.maxLength(30),
        CustomValidators.patternValidator(/^[a-zA-Z0-9]*$/, {specialCharacter: true})])),
        password: new FormControl('', Validators.compose([
          Validators.minLength(8),
          CustomValidators.patternValidator(/[0-9]/, { hasNumber: true }),
          CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true }),
          CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true })])),
        confirm: new FormControl('', [Validators.required])
      },
      {validator: CustomValidators.passwordMatchValidator});

  }

  register() {

    if(this.registerForm.valid) {
      var formData = new FormData();
      formData.append('Username', this.registerForm.controls['username'].value);
      formData.append('Password', this.registerForm.controls['password'].value);
      formData.append('File', this.user.File);

      this.authService.register(formData).subscribe(() => {
        this.location.back();
      }, error => {
        if(error){
        this.serverError = error[0].description || error;
          console.log(error);
        }
        else
          this.serverError = null;

        this.registerForm.reset();
      });
  }
  }

  checkPassword() {
    if(this.registerForm.get('password').hasError('hasNumber')) {
      this.passwordHasNumberError = "Hasło musi zawierać minimum jedną cyfrę";
    }
    else this.passwordHasNumberError = null;

    if(this.registerForm.get('password').hasError('hasSmallCase')) {
      this.passwordHasSmallCaseError = "Hasło musi zawierać minimum jedną małą literę";
    }
    else this.passwordHasSmallCaseError = null;

    if(this.registerForm.get('password').hasError('hasCapitalCase')) {
      this.passwordHasNumberError = "Hasło musi zawierać minimum jedną dużą literę"
    }
    else this.passwordHasCapitalCaseError = null;

    if(this.registerForm.get('password').hasError('minlength')) {
      this.passwordMinLengthError = "Hasło musi mieć minimum 8 znaków"
    }
    else this.passwordMinLengthError = null;


    if(this.registerForm.get('password').touched)
      return this.passwordMinLengthError || this.passwordHasSmallCaseError || this.passwordHasCapitalCaseError || this.passwordHasNumberError || '' ;
    else
      return '';
  }

  checkUsername() {
    if(this.registerForm.get('username').hasError('minlength')) {
      this.usernameMinLengthError = "Nazwa musi zawierać minimum 3 znaki"
    }
    else this.usernameMinLengthError = null;

    if(this.registerForm.get('username').hasError('maxlength')) {
      this.usernameMaxLengthError = "Nazwa może zawierac maksymalnie 30 znaków"
    }
    else this.usernameMaxLengthError = null;
    
    if(this.registerForm.get('username').hasError('specialCharacter')) {
      this.usernameForbiddenSignsError = "Nazwa posiada niedozwolone znaki";
    }
    else this.usernameForbiddenSignsError = null;

    if(this.registerForm.get('username').touched)
      return this.usernameMinLengthError || this.usernameMaxLengthError || this.usernameForbiddenSignsError || '' ;
    else
      return '';
  }

  checkConfirmPassword() {
    if(this.registerForm.get('confirm').hasError('noPasswordMatch')) {
      this.passwordMatchError = "wpisane hasła nie są ze sobą zgodne"
    }
    else
      this.passwordMatchError = null;


    if(this.registerForm.get('confirm').touched) {
      return this.passwordMatchError || '' ;
    }
    else 
      return '';
  }

  checkServerError() {
    if(this.serverError) {
      return this.serverError;
    }

    else
    return null;
  }

  imgPreview($event) {
    var file = $event.target.files[0];
    if (file.length === 0)
      return;

    this.user.File = file;
    var reader = new FileReader();
    this.imagePath = this.user.File;
    reader.readAsDataURL(this.user.File); 
    reader.onload = (_event) => { 
      this.imgURL = reader.result; 
    }
  }

  reset() {
    this.imgURL = null;
  }

}
