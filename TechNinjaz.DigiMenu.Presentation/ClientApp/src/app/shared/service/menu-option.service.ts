import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppUtils} from '../util/AppUtils';
import {Observable} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {IMenuItemOption} from '../model/menu-item-option';

@Injectable({
  providedIn: 'root'
})
export class MenuOptionService {

  private BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppUtils.BASE_API_URL + 'MenuItemOption/';
  }

  getMenuOptionsByItemId(temId: number): Observable<any> {
    return this.http.get<IMenuItemOption[]>(this.BaseUrl + `GetOptionsByItemId/${temId}`, AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }
}
