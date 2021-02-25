import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {AccountService} from '../../shared/service/auth/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  hide: boolean;
  registerForm: FormGroup;
  registerFormControls: { [p: string]: AbstractControl };

  constructor(private  router: Router,
              private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.hide = true;
    this.createRegisterForm();
  }

  createRegisterForm(): void {
    this.registerForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required])
    });
    this.registerFormControls = this.registerForm.controls;
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      this.accountService.login(this.registerForm.value).subscribe(() => {
        console.log('Register form works');
      }, error => {
        console.log(error);
      });
    }
  }

  onCancel(): void {
    this.registerForm.reset();
    this.router.navigateByUrl('/');
  }

  // private password(formGroup: FormGroup): any {
  //   const {value: password} = formGroup.get('password');
  //   const {value: confirmPassword} = formGroup.get('confirmPassword');
  //   return password === confirmPassword ? null : {passwordNotMatch: true};
  // }
}
