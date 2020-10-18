import {Component, OnInit} from '@angular/core';
import {IMenuCategory} from '../../shared/model/menu-category';
import {MenuCategoryService} from '../../shared/service/menu-category.service';
import {MatDialog} from '@angular/material/dialog';
import {ItemOptionsComponent} from '../item-options/item-options.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  menuCategories: IMenuCategory[] = [];
  menuCategory: IMenuCategory;
  cartItemCount: number;

  constructor(private categoryService: MenuCategoryService, private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.cartItemCount = 5;
    this.getMenuCategories();
  }

  getMenuCategoryById(id: number): void {
    this.categoryService.getCategory(id)
      .subscribe((category: IMenuCategory) => {
        this.menuCategory = category;
      });
  }

  getMenuCategories(): void {
    this.categoryService.getCategoryList()
      .subscribe((categories: IMenuCategory[]) => {
        this.menuCategories = categories;
      });
  }


}
