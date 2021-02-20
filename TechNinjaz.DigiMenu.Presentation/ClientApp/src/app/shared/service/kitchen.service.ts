import { kitchenOrderModel } from './../model/kitchen-order';
import {HttpClient} from '@angular/common/http';
import {AppConstUtils} from '../util/AppConstUtils';
import {Observable} from 'rxjs';
import { Injectable } from '@angular/core';
import {LocalStorageService} from './local-storage.service';
import {Router} from '@angular/router';
import {NotificationService} from "./notification.service";
import {IOrder} from '../model/order';
import { KitchenOrderComponent} from '../../client/kitchen/kitchen-order/kitchen-order.component';

@Injectable({
  providedIn: 'root'
})

export class KitchenService {

 private readonly BaseUrl: string;
 kitchenOrder: KitchenOrderComponent;
 model: kitchenOrderModel

  constructor(private http: HttpClient,
              private router: Router,
              private localStorage: LocalStorageService,
              private notificationService: NotificationService) {
    this.BaseUrl = AppConstUtils.BASE_API_URL + 'kitchen/';
  }

populateForm(order){
  console.log('order: ', order)
  this.model = order;
  console.log(this.model);
  this.kitchenOrder.populateModel(order);
}
  getAllOrders(): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.BaseUrl + `getallorders`);
  }

}

