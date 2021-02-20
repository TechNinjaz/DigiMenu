import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from './home/home.component';
import {ItemCardComponent} from './item-card/item-card.component';
import {OrderDetailComponent} from './order-detail/order-detail.component';
import {ItemOptionsComponent} from './item-options/item-options.component';
import {AppMaterialModule} from '../app-material.module';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { PaymentOptionComponent } from './payment-option/payment-option.component';
import { KitchenComponent } from './kitchen/kitchen.component';
import { KitchenOrderComponent } from './kitchen/kitchen-order/kitchen-order.component';

@NgModule({
  declarations: [
    HomeComponent,
    ItemCardComponent,
    OrderDetailComponent,
    ItemOptionsComponent,
    OrderHistoryComponent,
    PaymentOptionComponent,
    KitchenComponent,
    KitchenOrderComponent,
  ],
  imports: [
    CommonModule,
    AppMaterialModule,
  ],
  providers: []
})
export class ClientModule {
}
