import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './client/home/home.component';
import {OrderDetailComponent} from './client/order-detail/order-detail.component';
// import {ApiAuthorizationModule} from '../api-authorization/api-authorization.module';
// import {AuthorizeInterceptor} from '../api-authorization/authorize.interceptor';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
// import {AuthorizeGuard} from '../api-authorization/authorize.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'order', component: OrderDetailComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    // ApiAuthorizationModule,
  ],
  exports: [RouterModule],
  providers: [
    // { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
})
export class AppRoutingModule {
}
