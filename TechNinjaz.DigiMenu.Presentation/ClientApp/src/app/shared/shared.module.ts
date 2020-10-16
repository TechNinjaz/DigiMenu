import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavigationBarComponent} from './navigation-bar/navigation-bar.component';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {RouterModule} from '@angular/router';
import {FlexModule} from '@angular/flex-layout';
import {MatButtonModule} from '@angular/material/button';
import {MenuCategoryService} from './service/menu-category.service';

@NgModule({
  declarations: [
    NavigationBarComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    RouterModule,
    FlexModule,
    MatButtonModule
  ],
  exports: [
    NavigationBarComponent,
  ],
  providers: [
    MenuCategoryService
  ]
})
export class SharedModule { }
