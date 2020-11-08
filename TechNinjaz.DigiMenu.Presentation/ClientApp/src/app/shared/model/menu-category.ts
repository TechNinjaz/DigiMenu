import {IBaseModel} from './base-model';

export interface IMenuCategory extends IBaseModel{
  name: string;
  description: string;
  categoryImageUrl: string;
}

