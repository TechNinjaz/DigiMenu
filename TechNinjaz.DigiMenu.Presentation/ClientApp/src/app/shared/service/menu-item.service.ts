import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {Observable} from 'rxjs';
import {IMenuCategory} from '../model/menu-category';
import {IMenuItem} from '../model/menu-item';

@Injectable({
  providedIn: 'root'
})
export class MenuItemService {

  private readonly BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppConstUtils.BASE_API_URL + 'MenuItem/';
  }

  getItemsByCategoryId(categoryId: number): Observable<IMenuItem[]> {
    return this.http.get<IMenuItem[]>(this.BaseUrl + `GetByCategoryId/${categoryId}`);
  }

  getMenuItemId(id: number): Observable<IMenuItem> {
    return this.http.get<IMenuItem>(this.BaseUrl + `GetById/${id}`);
  }

}
