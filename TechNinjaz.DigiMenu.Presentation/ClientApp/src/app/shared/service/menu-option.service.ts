import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {Observable} from 'rxjs';
import {IMenuItemOption} from '../model/menu-item-option';

@Injectable({
  providedIn: 'root'
})
export class MenuOptionService {

  private readonly BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppConstUtils.BASE_API_URL + 'MenuItemOption/';
  }

  getMenuOptionsByItemId(temId: number): Observable<IMenuItemOption[]> {
    return this.http.get<IMenuItemOption[]>(this.BaseUrl + `GetOptionsByItemId/${temId}`);
  }
}
