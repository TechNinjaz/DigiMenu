import {Component, Input, OnInit} from '@angular/core';
import {IMenuItem} from '../../shared/model/menu-item';
import {ItemOptionsComponent} from '../item-options/item-options.component';
import {MatDialog} from '@angular/material/dialog';
import {IOrder} from '../../shared/model/order';
import {IOrderDetail} from '../../shared/model/order-detail';
import {AppConstUtils} from '../../shared/util/AppConstUtils';
import {LocalStorageService} from '../../shared/service/config/local-storage.service';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {

  @Input()
  MenuItem: IMenuItem;
  order: IOrder;

  constructor(private dialog: MatDialog, private localStorageService: LocalStorageService) {
  }

  ngOnInit(): void {
    this.order = {} as IOrder;
    this.order.orderDetails = [];
    this.order.orderStatusId = 1;
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ItemOptionsComponent, {
      width: '60%',
      data: this.MenuItem,
    });

    dialogRef.afterClosed().subscribe((orderDetail: IOrderDetail) => {
      console.log(orderDetail);
      if (orderDetail != null && orderDetail?.menuItemId > 0) {
        this.updateOrder(orderDetail);
      }
    });
  }

  updateOrder(orderDetail: IOrderDetail): void {
    if (this.orderExist()) {
      this.order = this.localStorageService.getItem(AppConstUtils.CART_KEY);
    }
    this.order.orderDetails.push(orderDetail);
    this.localStorageService.addItem(AppConstUtils.CART_KEY, this.order);
  }

  orderExist(): boolean {
    return this.localStorageService.getItem(AppConstUtils.CART_KEY) != null;
  }
}
