import {Component, OnInit} from '@angular/core';
import {LocalStorageService} from '../../shared/service/local-storage.service';
import {AppConstUtils} from '../../shared/util/AppConstUtils';
import {IOrder} from '../../shared/model/order';
import {MenuItemService} from '../../shared/service/menu-item.service';
import {IMenuItem} from '../../shared/model/menu-item';
import {OrderService} from '../../shared/service/order.service';
import {AccountService} from '../../shared/service/account.service';
import {IUser} from '../../shared/model/user';
import {IUserProfile} from '../../shared/model/user-profile';
import {NotificationService} from '../../shared/service/notification.service';
import {Router} from '@angular/router';

export interface IOrderView {
  name: string;
  price: number;
}

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  orderDetails: IOrderView[] = [];
  currentOrder: IOrder;
  columnsToDisplay: string[] = ['name', 'price', 'action'];
  private currentUser: IUser;

  constructor(private localStorageService: LocalStorageService,
              private accountService: AccountService,
              private itemService: MenuItemService,
              private orderService: OrderService,
              private router: Router,
              private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.loadTable();
  }

  loadTable(): void {
    this.currentOrder = this.localStorageService.getItem(AppConstUtils.CART_KEY);

    this.currentOrder.orderDetails.forEach(value => {
      this.itemService.getMenuItemId(value.menuItemId)
        .subscribe((menuItem: IMenuItem) => {
          this.orderDetails.push({name: menuItem.title, price: menuItem.price});
        });
    });
  }



  submitOrder(): void {
    this.currentUser = this.localStorageService.getItem(AppConstUtils.CURRENT_USER_KEY);
    this.currentOrder.orderAmount = this.getTotalCost();
    this.accountService.getUserProfile(this.currentUser.email)
      .subscribe(profile => {
        this.updateOrAddOrder(profile);
      });
    this.localStorageService.addItem(AppConstUtils.CART_KEY, this.currentOrder);
  }

  updateOrAddOrder(profile: IUserProfile): void {
    this.orderService.getActiveOrder(profile.id).subscribe(order => {
      if (order) {
        this.currentOrder = order;
        this.updateOrder(profile);
      } else {
        this.addOrder(profile);
      }
    });
  }

  addOrder(profile: IUserProfile): void {
    this.currentOrder.customerId = profile?.id;
    this.orderService.addOrder(this.currentOrder).subscribe((order: IOrder) => {
      this.currentOrder = order;
      this.localStorageService.addItem(AppConstUtils.CART_KEY, this.currentOrder);
      this.mapToHistory('order has been added');
    });
  }

  updateOrder(profile: IUserProfile): void {
    this.currentOrder.customerId = profile?.id;
    this.orderService.updateOrder(this.currentOrder).subscribe((order: IOrder) => {
      this.currentOrder = order;
      this.localStorageService.addItem(AppConstUtils.CART_KEY, this.currentOrder);
      this.mapToHistory('order has been updated');
    });
  }

  mapToHistory(message: string): void {
    this.router.navigateByUrl('/orderHistory').then(r => {
      this.notificationService.showSuccess('order has been updated');
    });
  }

  getTotalCost(): number {
    return this.orderDetails?.map(t => t?.price)
      .reduce((acc, value) => acc + value, 0);
  }

  OnDelete(i: number): void {
  }


}


