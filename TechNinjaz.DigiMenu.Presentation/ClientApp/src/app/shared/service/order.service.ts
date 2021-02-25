import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {IOrder} from '../model/order';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private readonly BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppConstUtils.BASE_API_URL + 'Order/';
  }

  addOrder(order: IOrder): Observable<IOrder> {
    return this.http.post<IOrder>(this.BaseUrl + 'Create', order);
  }

  updateOrder(order: IOrder): Observable<IOrder> {
    return this.http.post<IOrder>(this.BaseUrl + 'Update', order);
  }

  getOrderById(id: number): Observable<IOrder> {
    return this.http.get<IOrder>(this.BaseUrl + `GetById/${id}`);
  }
  getAllUserOrders(userId: number): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.BaseUrl + `GetAllUserOrders/${userId}`);
  }

  getActiveOrder(userId: number): Observable<IOrder> {
    return this.http.get<IOrder>(this.BaseUrl + `GetActiveOrder/${userId}`);
  }
}
