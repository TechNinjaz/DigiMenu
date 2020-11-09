import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {Observable} from 'rxjs';
import {IMenuCategory} from '../model/menu-category';

@Injectable({
  providedIn: 'root'
})
export class MenuCategoryService {

  private readonly BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppConstUtils.BASE_API_URL + 'MenuCategory/';
  }

  getCategory(id: number): Observable<IMenuCategory> {
    return this.http.get<IMenuCategory>(this.BaseUrl + `GetById/${id}`);
  }

  getCategoryList(): Observable<IMenuCategory[]> {
    return this.http.get<IMenuCategory[]>(this.BaseUrl + 'GetAll');
  }
}
