import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {NavigationBarComponent} from './navigation-bar/navigation-bar.component';
import {RouterModule} from '@angular/router';
import {FlexLayoutModule} from '@angular/flex-layout';
import {AppMaterialModule} from '../app-material.module';

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
    AppMaterialModule,
  ],
  providers: []
})
export class SharedModule {
}
