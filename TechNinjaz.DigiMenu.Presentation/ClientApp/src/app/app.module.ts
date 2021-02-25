import {BrowserModule, Title as TitleService} from '@angular/platform-browser';
import {ErrorHandler, NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ServiceWorkerModule} from '@angular/service-worker';
import {environment} from '../environments/environment';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ClientRoutingModule} from './client/client-routing.module';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {SharedModule} from './shared/shared.module';
import {KitchenModule} from './kitchen/kitchen.module';
import {ClientModule} from './client/client.module';
import {AuthApiModule} from './auth-api/auth-api.module';
import {AdminModule} from './admin/admin.module';
import {MAT_SNACK_BAR_DEFAULT_OPTIONS} from '@angular/material/snack-bar';
import {GlobalErrorHandler} from './shared/util/global-error-handler';
import {ServerErrorInterceptor} from './shared/util/server-error-interceptor.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js', {enabled: environment.production}),
    BrowserAnimationsModule,
    ClientRoutingModule,
    SharedModule,
    KitchenModule,
    ClientModule,
    AuthApiModule,
    AdminModule,
  ],
  providers: [
    TitleService,
    {provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 8000}},
    {provide: ErrorHandler, useClass: GlobalErrorHandler},
    {provide: HTTP_INTERCEPTORS, useClass: ServerErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
