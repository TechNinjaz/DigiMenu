import {IOrderStatus} from './order-status';
import {IUser} from './user';
import {IOrderDetail} from './order-detail';

export interface IOrder {
  id: number;
  waiterId: number;
  customerId: number;
  orderStatusId: number;
  orderAmount: number;
  paidAmount: number;
  gratuityAmount: number;
  paymentMethodId: number;
  createdAt: string;
  orderDetails: IOrderDetail[];
}
