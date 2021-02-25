import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {Router} from '@angular/router';
import {NotificationService} from '../config/notification.service';
import {AppConstUtils} from '../../util/AppConstUtils';
import {IUser} from '../../model/user';
import {IUserProfile} from '../../model/user-profile';
import {LocalStorageService} from '../config/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private readonly BaseUrl: string;

  constructor(private router: Router,
              private http: HttpClient,
              private localStorageService: LocalStorageService,
              private notificationService: NotificationService) {

    this.BaseUrl = AppConstUtils.BASE_API_URL + 'Account/';
  }

  getCurrentUser(): Observable<IUser> {
    const returnUser = this.http.get<IUser>(this.BaseUrl + 'GetCurrentUser');
    returnUser.pipe(map((user: IUser) => {
      if (user) {
        this.localStorageService.addItem(AppConstUtils.CURRENT_USER_KEY, user);
      }
    }));

    return returnUser;
  }

  login(loginUser: any): Observable<any> {
    const user = this.http.post<IUser>(this.BaseUrl + 'Login', loginUser);
    this.setLocalStorage(user);
    return user;
  }

  register(registerUser: any): Observable<IUser> {
    const user = this.http.post<IUser>(this.BaseUrl + 'RegisterUser', registerUser);
    this.setLocalStorage(user);
    return user;
  }

  getUserProfile(email: any): Observable<IUserProfile> {
    return this.http.get<IUserProfile>(this.BaseUrl + `GetUserProfile/${email}`);
  }

  setLocalStorage(user$: Observable<IUser>): void {
    console.log(user$);
    user$.subscribe((user: IUser) => {
      console.log(user);
      if (user) {
        this.localStorageService.addItem(AppConstUtils.CURRENT_USER_TOKEN, user.token);
        this.localStorageService.addItem(AppConstUtils.CURRENT_USER_KEY, user);
      }
    });
  }

  logout(): void {
    this.router.navigateByUrl('/').then(() => {
      this.localStorageService.removeItem(AppConstUtils.CURRENT_USER_KEY);
      this.localStorageService.removeItem(AppConstUtils.CURRENT_USER_TOKEN);
      this.localStorageService.removeItem(AppConstUtils.CART_KEY);
      this.localStorageService.clearStorage();
      this.notificationService.showSuccess('you have successfully logged out');
    });
  }

}
