import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppUtils} from '../util/AppUtils';
import {Observable} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {IMenuCategory} from '../model/menu-category';

@Injectable({
  providedIn: 'root'
})
export class MenuCategoryService {

  private BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppUtils.BASE_API_URL + 'MenuCategory/';
  }

  getCategory(id: number): Observable<any> {
    return this.http.get<IMenuCategory>(this.BaseUrl + `GetById/${id}`, AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }

  getCategoryList(): Observable<any> {
    return this.http.get<IMenuCategory[]>(this.BaseUrl + 'GetAll', AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }
}
