import {AfterViewInit, Component, OnInit} from '@angular/core';
import {AppConstUtils} from '../../shared/util/AppConstUtils';
import {IOrder} from '../../shared/model/order';
import {MenuItemService} from '../../shared/service/menu-item.service';
import {IMenuItem} from '../../shared/model/menu-item';
import {OrderService} from '../../shared/service/order.service';
import {IUserProfile} from '../../shared/model/user-profile';
import {Router} from '@angular/router';
import {AccountService} from '../../shared/service/auth/account.service';
import {LocalStorageService} from '../../shared/service/config/local-storage.service';
import {NotificationService} from '../../shared/service/config/notification.service';
import {IUser} from '../../shared/model/user';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  dataSource: any ;
  currentOrder!: IOrder;
  columnsToDisplay: string[] = ['title', 'description', 'price'];
  private currentUser: IUser;

  constructor(private router: Router,
              private orderService: OrderService,
              private itemService: MenuItemService,
              private accountService: AccountService,
              private localStorageService: LocalStorageService,
              private notificationService: NotificationService) {

    this.currentOrder = this.localStorageService.getItem(AppConstUtils.CART_KEY);
    this.currentUser = this.localStorageService.getItem(AppConstUtils.CURRENT_USER_KEY);
  }

  ngOnInit(): void {
    this.dataSource = this.itemService.getAllMenuItem();
  }

  submitOrder(): void {
    // this.currentOrder.orderAmount = this.getTotalCost();
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
    this.router.navigateByUrl('/orderHistory').then(() => {
      this.notificationService.showSuccess(message);
    });
  }

  // getTotalCost(): number {
  //   return this.dataSource?.map(t => t?.price)
  //     .reduce((acc, value) => acc + value, 0);
  // }
}


