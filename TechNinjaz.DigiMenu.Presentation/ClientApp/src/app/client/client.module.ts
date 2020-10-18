import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HomeComponent} from './home/home.component';
import {ItemCardComponent} from './item-card/item-card.component';
import {MatDividerModule} from '@angular/material/divider';
import {RouterModule} from '@angular/router';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTabsModule} from '@angular/material/tabs';
import {FlexLayoutModule} from '@angular/flex-layout';
import {MatBadgeModule} from '@angular/material/badge';
import {MatTooltipModule} from '@angular/material/tooltip';
import {OrderDetailComponent} from './order-detail/order-detail.component';
import {MatDialogModule} from '@angular/material/dialog';
import {ItemOptionsComponent} from './item-options/item-options.component';

@NgModule({
  declarations: [
    HomeComponent,
    ItemCardComponent,
    OrderDetailComponent,
    ItemOptionsComponent,
  ],
  imports: [
    CommonModule,
    MatDividerModule,
    RouterModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatTabsModule,
    FlexLayoutModule,
    MatBadgeModule,
    MatTooltipModule,
    MatDialogModule
  ],
  providers: []
})
export class ClientModule {
}
