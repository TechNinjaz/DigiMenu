import {ISelectedOption} from './selected-option';

export interface IOrderDetail {
  id: number;
  menuItemId: number;
  selectedOptions: ISelectedOption[];
}
