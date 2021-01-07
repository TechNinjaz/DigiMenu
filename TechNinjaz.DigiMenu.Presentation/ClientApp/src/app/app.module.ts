import {BrowserModule, Title} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatMenuModule} from '@angular/material/menu';
import {FlexLayoutModule} from '@angular/flex-layout';
import { HomeComponent } from './home/home.component';
import { ItemCardComponent } from './item-card/item-card.component';
import { CategoryComponent } from './category/category.component';
import {HttpClientModule} from '@angular/common/http';
import {CategoryService} from '../service/category.service';
import {MatDividerModule} from '@angular/material/divider';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import {NavBarService} from '../service/nav-bar.service';
import { KitchenModuleComponent } from './kitchen-module/kitchen-module.component';
import {MatTableModule} from '@angular/material/table';
import { KitchenService } from '../service/kitchen.service';


@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    HomeComponent,
    ItemCardComponent,
    CategoryComponent,
    KitchenModuleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js', {enabled: environment.production}),
    MatToolbarModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    FlexLayoutModule,
    MatDividerModule,
    MatCardModule,
    MatListModule,
    MatTableModule
  ],
  providers: [
    CategoryService,
    NavBarService,
    Title,
    KitchenService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
