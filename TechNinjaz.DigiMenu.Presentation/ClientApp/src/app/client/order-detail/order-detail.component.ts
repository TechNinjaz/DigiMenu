import {Component, OnInit} from '@angular/core';
import {LocalStorageService} from '../../shared/service/local-storage.service';
import {IOrderDetail} from '../../shared/model/order-detail';
import {AppUtils} from '../../shared/util/AppUtils';
import {IOrder} from '../../shared/model/order';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {

  orderDetails: IOrderDetail[];
  displayedColumns: string[] = ['name', 'price', 'action'];

  constructor(private localStorageService: LocalStorageService) {

  }

  ngOnInit(): void {
    this.getOrderDetails();
  }

  getOrderDetails(): void {
    const storageValue = this.localStorageService.getItem(AppUtils.CART_KEY);
    if (storageValue != null) {
      const currentOrder: IOrder = storageValue.value;
      this.orderDetails = currentOrder.orderDetails;
    } else {
      this.orderDetails = [];
    }
  }
}

