export interface IMenuItem {
  id: number;
  createdAt: string;
  title: string;
  description: string;
  itemImageUrl: string;
  price: number;
  isActive: boolean;
  menuCategoryId: number;
}
