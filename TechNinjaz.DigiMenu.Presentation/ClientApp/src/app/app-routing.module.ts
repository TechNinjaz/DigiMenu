import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './client/home/home.component';
import {OrderDetailComponent} from './client/order-detail/order-detail.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'order', component: OrderDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
