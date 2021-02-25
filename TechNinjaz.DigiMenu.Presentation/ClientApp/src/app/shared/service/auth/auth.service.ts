import {Injectable} from '@angular/core';
import {IUser} from '../../model/user';
import {JwtHelperService} from '@auth0/angular-jwt';
import {LocalStorageService} from '../config/local-storage.service';
import {AppConstUtils} from '../../util/AppConstUtils';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private token!: string;
  private jwtHelper: JwtHelperService;

  constructor(private localStorageService: LocalStorageService) {
    this.jwtHelper = new JwtHelperService();
    this.getToken();
  }

  getToken(): void {
    this.localStorageService.storageChange.subscribe(store => {
      if (store?.key === AppConstUtils.CURRENT_USER_TOKEN) {
        const isRemoveType: boolean = store?.type === AppConstUtils.STORAGE_REMOVE_TYPE_KEY;
        this.token = isRemoveType ? null : store?.value;
      }
    });
    if (!this.token){
      this.token = this.localStorageService.getItem(AppConstUtils.CURRENT_USER_TOKEN);
    }
  }

  isAuthenticated(): boolean {
    console.log(this.token);
    const isTokenExpired: boolean = this.jwtHelper.isTokenExpired(this.token);
    console.log(this.jwtHelper.decodeToken(this.token));
    console.log(isTokenExpired);
    return this.token != null && !isTokenExpired;
  }

  decodeToken(): any {
    return this.jwtHelper.decodeToken(this.token);
  }
}
