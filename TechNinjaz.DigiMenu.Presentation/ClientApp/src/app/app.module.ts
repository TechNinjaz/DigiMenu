import {BrowserModule, Title} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ServiceWorkerModule} from '@angular/service-worker';
import {environment} from '../environments/environment';
import {HttpClientModule} from '@angular/common/http';
import {SharedModule} from './shared/shared.module';
import {KitchenModule} from './kitchen/kitchen.module';
import {ClientModule} from './client/client.module';
import {AdminModule} from './admin/admin.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js', {enabled: environment.production}),
    SharedModule,
    KitchenModule,
    ClientModule,
    AdminModule
  ],
  providers: [
    Title
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
