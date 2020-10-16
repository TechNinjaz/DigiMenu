import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from './home/home.component';
import {ItemCardComponent} from './item-card/item-card.component';
import {MatDividerModule} from '@angular/material/divider';
import {RouterModule} from '@angular/router';
import {FlexModule} from '@angular/flex-layout';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    HomeComponent,
    ItemCardComponent,
  ],
  imports: [
    CommonModule,
    MatDividerModule,
    RouterModule,
    FlexModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule
  ],
  providers: [ ]
})
export class ClientModule {
}
