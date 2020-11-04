import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AppUtils} from '../util/AppUtils';
import {IOrder} from '../model/order';
import {catchError, retry} from 'rxjs/operators';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private BaseUrl: string;

  constructor(private http: HttpClient) {
    this.BaseUrl = AppUtils.BASE_API_URL + 'Order/';
  }

  addOrder(order: IOrder): Observable<any> {
    return this.http.post<IOrder>(this.BaseUrl + 'Create', order, AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }

  updateOrder(order: IOrder): Observable<any> {
    return this.http.post<IOrder>(this.BaseUrl + 'Update', order, AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }

  getOrderById(id: number): Observable<any> {
    return this.http.get<IOrder>(this.BaseUrl + `GetById/${id}`, AppUtils.httpOptions)
      .pipe(retry(1), catchError(AppUtils.errorHandler));
  }
}
