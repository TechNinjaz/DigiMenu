import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppUtils} from '../util/AppUtils';
import {Observable} from 'rxjs';
import {IMenuCategory} from '../model/menu-category';
import {catchError, retry} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MenuItemService {

  private BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppUtils.BASE_API_URL + 'MenuItem/';
  }

  getByItemsCategoryId(categoryId: number): Observable<any> {
    return this.http.get<IMenuCategory>(this.BaseUrl + `GetByCategoryId/${categoryId}`, AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }

}
