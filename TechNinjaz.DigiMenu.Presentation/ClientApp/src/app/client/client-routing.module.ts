import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {OrderDetailComponent} from './order-detail/order-detail.component';
import {OrderHistoryComponent} from './order-history/order-history.component';
import {AuthGuardService as AuthGuard} from '../shared/service/auth/auth-guard.service';

const routes: Routes = [
  {path: '', component: HomeComponent},
  // {path: 'order', component: OrderDetailComponent, canActivate: [AuthGuard]},
  {path: 'order', component: OrderDetailComponent},
  // {path: 'orderHistory', component: OrderHistoryComponent}
  {path: 'orderHistory', component: OrderHistoryComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule],
  providers: [],
})
export class ClientRoutingModule {
}
