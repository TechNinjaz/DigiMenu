import {Component, OnInit} from '@angular/core';
import {IMenuCategory} from '../../shared/model/menu-category';
import {MenuCategoryService} from '../../shared/service/menu-category.service';
import {AppUtils} from '../../shared/util/AppUtils';
import {IMenuItem} from '../../shared/model/menu-item';
import {MenuItemService} from '../../shared/service/menu-item.service';
import {LocalStorageService} from '../../shared/service/local-storage.service';
import {IOrder} from '../../shared/model/order';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  menuCategories: IMenuCategory[];
  menuItems: IMenuItem[];
  cartItemCount: number;
  selectedIndex: number;
  title: string;

  constructor(private localStorageService: LocalStorageService,
              private categoryService: MenuCategoryService,
              private itemService: MenuItemService) {
  }

  ngOnInit(): void {
    this.menuItems = [];
    this.selectedIndex = 0;
    this.getMenuCategories();
    this.menuCategories = [];
    this.title = AppUtils.TITLE;
    this.countCartItems();
  }

  getSelectedCategoryTabItems(event): void {
    this.selectedIndex = Number(event);
    this.getByItemsCategoryId(this.menuCategories[this.selectedIndex].id);
  }

  getByItemsCategoryId(id: number): void {
    this.itemService.getByItemsCategoryId(id)
      .subscribe((items: IMenuItem[]) => {
        this.menuItems = items;
      });
  }

  private getMenuCategories(): void {
    this.categoryService.getCategoryList()
      .subscribe((categories: IMenuCategory[]) => {
        this.menuCategories = categories;
        this.getByItemsCategoryId(this.menuCategories[this.selectedIndex].id);
      });
  }

  private countCartItems(): void {
    this.localStorageService.storageChange.subscribe(item => {
      console.log(item);
      if (item.key === AppUtils.CART_KEY) {
        const Order: IOrder = item.value;
        this.cartItemCount = Order?.orderDetails?.length;
      }
    });
  }
}
