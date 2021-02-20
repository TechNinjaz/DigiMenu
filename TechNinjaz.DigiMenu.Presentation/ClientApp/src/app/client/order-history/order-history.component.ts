import {Component, OnInit} from '@angular/core';
import {OrderService} from '../../shared/service/order.service';
import {IOrder} from '../../shared/model/order';
import {IUserProfile} from '../../shared/model/user-profile';
import {AccountService} from '../../shared/service/account.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.scss']
})
export class OrderHistoryComponent implements OnInit {
  orderHistoryContent: number;
  orderHistories: IOrder[] = [];
  currentUserProfile: IUserProfile;

  constructor(private accountService: AccountService,
              private orderService: OrderService) {

  }

  ngOnInit(): void {
    this.getOrderHistory();

  }

  getOrderHistory(): void {
    this.accountService.getCurrentUser().subscribe(user => {
      this.accountService.getUserProfile(user.email).subscribe(profile => {
        this.orderService.getAllUserOrders(profile?.id)
          .subscribe(orders => {
            this.orderHistories = orders;
            this.orderHistoryContent = this.orderHistories?.length;
          });
      });
    });

  }

  // getTotalCost(order: IOrder): number {
  //   return order?.orderDetails?.map(t => t?.price)
  //     .reduce((acc, value) => acc + value, 0);
  // }

}
