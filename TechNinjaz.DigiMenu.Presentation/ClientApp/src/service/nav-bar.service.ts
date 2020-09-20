import { Injectable } from '@angular/core';
import {MatSidenav} from '@angular/material/sidenav';

@Injectable({
  providedIn: 'root'
})
export class NavBarService {
  private sidenav: MatSidenav;

  public setSidenav(sidenav: MatSidenav): void {
    this.sidenav = sidenav;
  }

  public open(): any {
    return this.sidenav.open();
  }


  public close(): any {
    return this.sidenav.close();
  }

  public toggle(): any {
    console.log(this.sidenav);
    return this.sidenav.toggle();
  }
}
