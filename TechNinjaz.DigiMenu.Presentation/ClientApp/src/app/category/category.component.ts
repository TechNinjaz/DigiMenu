import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {CategoryModel} from '../../model/category';
import {CategoryService} from '../../service/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  categoryList: CategoryModel[] = [];
  @Output()
  private categoryEmitter = new EventEmitter<CategoryModel>();

  constructor(private categoryService: CategoryService) {

  }

  ngOnInit(): void {
    this.getCategoryList();

  }

  sendCategoryModel(model: CategoryModel): void {
    console.log(model);
    this.categoryEmitter.emit(model);
  }

  getCategoryList(): void {
    this.categoryService.getCategoryList()
      .subscribe((resp: CategoryModel[]) => {
        this.categoryList = resp;
        this.sendCategoryModel(this.categoryList[0]);
      });
  }
}
