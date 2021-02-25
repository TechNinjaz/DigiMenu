import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {AccountService} from '../../shared/service/auth/account.service';
import {NotificationService} from '../../shared/service/config/notification.service';
import {AuthService} from '../../shared/service/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  hide: boolean;
  LoginForm: FormGroup;
  LoginFormControls: { [p: string]: AbstractControl };

  constructor(private router: Router,
              private auth: AuthService,
              private accountService: AccountService,
              private notificationService: NotificationService) {
    console.log(this.router.url);
  }

  ngOnInit(): void {
    this.hide = true;
    this.createLoginForm();
  }

  createLoginForm(): void {
    this.LoginForm = new FormGroup({
      email: new FormControl('',
        [Validators.required,
          Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', [Validators.required]),
    });
    this.LoginFormControls = this.LoginForm.controls;
  }

  onSubmit(): void {
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
