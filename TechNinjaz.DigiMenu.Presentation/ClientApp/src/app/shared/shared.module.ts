import {ErrorHandler, NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NavigationBarComponent} from './navigation-bar/navigation-bar.component';
import {RouterModule} from '@angular/router';
import {FlexLayoutModule} from '@angular/flex-layout';
import {AppMaterialModule} from '../app-material.module';
import {MAT_SNACK_BAR_DEFAULT_OPTIONS} from "@angular/material/snack-bar";
import {GlobalErrorHandler} from "./util/global-error-handler";
import {HTTP_INTERCEPTORS} from "@angular/common/http";
import {ServerErrorInterceptor} from "./util/server-error-interceptor.service";


@NgModule({
  declarations: [
    NavigationBarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FlexLayoutModule,
    AppMaterialModule,

  ],
  exports: [
    NavigationBarComponent,
  ],
  providers: []
})
export class SharedModule {
}
