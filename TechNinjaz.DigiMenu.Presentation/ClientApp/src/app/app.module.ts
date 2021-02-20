import {BrowserModule, Title} from '@angular/platform-browser';
import {ErrorHandler, NgModule} from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ServiceWorkerModule} from '@angular/service-worker';
import {environment} from '../environments/environment';
import {SharedModule} from './shared/shared.module';
import {ClientModule} from './client/client.module';
import {AdminModule} from './admin/admin.module';
import {AuthApiModule} from './auth-api/auth-api.module';
import {ServerErrorInterceptor} from './shared/util/server-error-interceptor.service';
import {GlobalErrorHandler} from './shared/util/global-error-handler';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {MAT_SNACK_BAR_DEFAULT_OPTIONS} from '@angular/material/snack-bar';
import {ClientRoutingModule} from './client/client-routing.module';
import { KitchenOrderComponent } from './client/kitchen/kitchen-order/kitchen-order.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    ClientRoutingModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js', {enabled: environment.production}),
    SharedModule,
    ClientModule,
    AuthApiModule,
    AdminModule,

  ],
  providers: [
    Title,
    {provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 2000}},
    {provide: ErrorHandler, useClass: GlobalErrorHandler},
    {provide: HTTP_INTERCEPTORS, useClass: ServerErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent],
  entryComponents: [KitchenOrderComponent]
})
export class AppModule {
}
