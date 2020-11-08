import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {AccountService} from '../../shared/service/account.service';
import {Router} from '@angular/router';
import {NotificationService} from "../../shared/service/notification.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  hide: boolean;
  LoginForm: FormGroup;
  LoginFormControls: { [p: string]: AbstractControl };

  constructor(private notificationService: NotificationService,
              private accountService: AccountService,
              private  router: Router) {
  }

  ngOnInit(): void {
    this.hide = true;
    this.createLoginForm();
  }

  createLoginForm(): void {
    this.LoginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
    this.LoginFormControls = this.LoginForm.controls;
  }

  onSubmit(): void {

    console.log(this.LoginForm.valid);
    if (this.LoginForm.valid) {
      this.accountService.login(this.LoginForm.value).subscribe(() => {
        this.router.navigateByUrl('/').then(r => {
            this.notificationService.showSuccess('Successfully logged In');
          });
      });
    }
  }


  onCancel(): void {
    this.LoginForm.reset();
    this.router.navigateByUrl('/');
  }
}
