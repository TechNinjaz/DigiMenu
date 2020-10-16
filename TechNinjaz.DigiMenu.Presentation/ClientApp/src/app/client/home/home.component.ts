import {Component, OnInit} from '@angular/core';
import {IMenuCategory} from '../../shared/model/menu-category';
import {MenuCategoryService} from '../../shared/service/menu-category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  menuCategories: IMenuCategory[] = [];
  category: IMenuCategory = new IMenuCategory();

  constructor(private categoryService: MenuCategoryService) {
  }

  ngOnInit(): void {
    this.getMenuCategories();
  }

  getMenuCategoryById(id: number): void {
    this.categoryService.getCategory(id)
      .subscribe((category: IMenuCategory) => {
        this.category = category;
      });
  }

  getMenuCategories(): void {
    this.categoryService.getCategoryList()
      .subscribe((categories: IMenuCategory[]) => {
        this.menuCategories = categories;
        this.category = this.menuCategories[0];
      });
  }
}
