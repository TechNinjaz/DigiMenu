import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from './home/home.component';
import {ItemCardComponent} from './item-card/item-card.component';
import {OrderDetailComponent} from './order-detail/order-detail.component';
import {ItemOptionsComponent} from './item-options/item-options.component';
import {OrderHistoryComponent} from './order-history/order-history.component';
import {PaymentOptionComponent} from './payment-option/payment-option.component';
import {SharedModule} from '../shared/shared.module';


@NgModule({
  declarations: [
    HomeComponent,
    ItemCardComponent,
    OrderDetailComponent,
    ItemOptionsComponent,
    OrderHistoryComponent,
    PaymentOptionComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  providers: []
})
export class ClientModule {
}
