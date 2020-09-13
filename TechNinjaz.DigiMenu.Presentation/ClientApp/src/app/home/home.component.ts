import { Component, OnInit } from '@angular/core';
import {CategoryModel} from '../../model/category';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  category: CategoryModel;

  constructor() { }

  ngOnInit(): void {
  }

  setCategory(model: CategoryModel): void {
    this.category = model;
  }
}
