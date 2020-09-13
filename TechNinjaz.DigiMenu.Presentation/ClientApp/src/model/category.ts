import {MenuItemModel} from './menu-item';

export class CategoryModel {

  public id: number;
  public name: string;
  public description: string;
  public categoryImage: string;
  public menuItems: Array<MenuItemModel>;
}
