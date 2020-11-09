import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {Observable} from 'rxjs';
import {IUser} from '../model/user';
import {map} from 'rxjs/operators';
import {LocalStorageService} from './local-storage.service';
import {Router} from '@angular/router';
import {IUserProfile} from '../model/user-profile';
import {NotificationService} from "./notification.service";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private readonly BaseUrl: string;

  constructor(private http: HttpClient,
              private router: Router,
              private localStorage: LocalStorageService,
              private notificationService: NotificationService) {
    this.BaseUrl = AppConstUtils.BASE_API_URL + 'Account/';
  }

  getCurrentUser(): Observable<IUser> {
    return this.http.get<IUser>(this.BaseUrl + 'GetCurrentUser')
      .pipe(map((user: IUser) => {
        if (user) {
          this.localStorage.addItem(AppConstUtils.CURRENT_USER_KEY, user);
        }
        return user;
      }));
  }

  login(loginUser: any): Observable<any> {
    return this.http.post<IUser>(this.BaseUrl + 'Login', loginUser)
      .pipe(map((user: IUser) => {
        if (user) {
          this.localStorage.addItem(AppConstUtils.CURRENT_USER_KEY, user);
        }
        return user;
      }));
  }

  register(registerUser: any): Observable<IUser> {
    return this.http.post<IUser>(this.BaseUrl + 'RegisterUser', registerUser)
      .pipe(map((user: IUser) => {
        if (user) {
          this.localStorage.addItem(AppConstUtils.CURRENT_USER_KEY, user);
        }
        return user;
      }));
  }

  getUserProfile(email: any): Observable<IUserProfile> {
    return this.http.get<IUserProfile>(this.BaseUrl + `GetUserProfile/${email}`);
  }

  logout(): void {
    this.router.navigateByUrl('/').then(r => {
      this.localStorage.removeItem(AppConstUtils.CURRENT_USER_KEY);
      this.localStorage.removeItem(AppConstUtils.CART_KEY);
      this.localStorage.clearStorage();
      this.notificationService.showSuccess('you have successfully logged out');
    });
  }

}
