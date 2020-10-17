import {IMenuItem} from './menu-item';

export interface IMenuCategory {
  id: number;
  createdAt: string;
  name: string;
  description: string;
  categoryImageUrl: string;
  menuItems: IMenuItem[];
}

