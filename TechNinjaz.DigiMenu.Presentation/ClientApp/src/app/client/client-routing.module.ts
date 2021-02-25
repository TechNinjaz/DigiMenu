import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {OrderDetailComponent} from './order-detail/order-detail.component';
import {OrderHistoryComponent} from './order-history/order-history.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'order', component: OrderDetailComponent},
  {path: 'orderHistory', component: OrderHistoryComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule],
  providers: [],
})
export class ClientRoutingModule { }
