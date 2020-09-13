import {Component, OnInit, Output, EventEmitter, Input} from '@angular/core';
import {CategoryModel} from '../../model/category';
import {CategoryService} from '../../service/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  categoryList: CategoryModel[] = [];
  category: CategoryModel;
  @Output()
  private categoryEmitter = new EventEmitter<CategoryModel>();

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategoryList();
  }

  private sendCategoryModel(model: CategoryModel): void {
    this.categoryEmitter.emit(model);
  }

  getCategoryById(id: number): void {
    this.categoryService.getCategory(id)
      .subscribe((resp: CategoryModel) => {
        this.category = resp;
        this.sendCategoryModel(this.category);
      });
  }

  getCategoryList(): void {
    this.categoryService.getCategoryList()
      .subscribe((resp: CategoryModel[]) => {
        this.categoryList = resp;
        this.sendCategoryModel(this.categoryList[0]);
      });
  }
}
