import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router} from '@angular/router';
import {AuthService} from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuardService implements CanActivate {

  constructor(private auth: AuthService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;
    const tokenPayload = this.auth.decodeToken();
    if (!this.auth.isAuthenticated() || tokenPayload?.role !== expectedRole) {
      this.router.navigateByUrl('/login').then();
      return false;
    }
    return true;
  }
}
