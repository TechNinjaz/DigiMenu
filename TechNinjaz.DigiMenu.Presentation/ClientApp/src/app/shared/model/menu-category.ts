import {IMenuItem} from './menu-item';

export class IMenuCategory {
  id: number;
  createdAt: string;
  name: string;
  description: string;
  categoryImageUrl: string;
  menuItems: IMenuItem[];
}

