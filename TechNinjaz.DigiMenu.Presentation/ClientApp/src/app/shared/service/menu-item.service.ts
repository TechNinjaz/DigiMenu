import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {Observable} from 'rxjs';
import {IMenuItem} from '../model/menu-item';
import {LocalStorageService} from './config/local-storage.service';
import {map} from 'rxjs/operators';

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
    return  this.http.get<IMenuItem>(this.BaseUrl + `GetById/${id}`);
  }
  getAllMenuItem(): Observable<IMenuItem> {
    return  this.http.get<IMenuItem>(this.BaseUrl + `GetAll`);
  }
  // getCartOrders(): IMenuItem[] {
  //   const currentOrder = this.localStorageService.getItem(AppConstUtils.CART_KEY);
  //
  //   currentOrder.orderDetails.forEach((value: { menuItemId: number; }) => {
  //
  //     this.getMenuItemId(value.menuItemId)
  //       .subscribe((menuItem: IMenuItem) => {
  //         console.log('inside subscribe', menuItem);
  //         this.dataSource.push(menuItem);
  //       });
  //   });
  //   return this.dataSource;
  // }

}
