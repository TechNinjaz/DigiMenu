import { KitchenComponent } from './../kitchen.component';
import { Component, OnInit, Input } from '@angular/core';
import { IOrderDetail } from '../../../shared/model/order-detail';
import { kitchenOrderModel } from '../../../shared/model/kitchen-order';
import { OrderService } from '../../../shared/service/order.service';
import { KitchenService } from '../../../shared/service/kitchen.service';
import {IOrder} from '../../../shared/model/order';


@Component({
  selector: 'app-kitchen-order',
  templateUrl: './kitchen-order.component.html',
  styleUrls: ['./kitchen-order.component.scss']
})

export class KitchenOrderComponent implements OnInit {
 orderDetail: IOrderDetail;
 order: kitchenOrderModel;
 selectedStatus: string = '';
 KitchenComponent: KitchenComponent;

 //need to change it and call Orderstatus service or read from OrderStatus table
 status: Stats [] = [
   { value: '2', viewValue: 'In-progress'},
   { value: '1', viewValue: 'Cue'},
   { value: '3', viewValue: 'Ready'},
   { value: '4', viewValue: 'Cancel'}
 ];
 ////////////////////////////////////////////////////////////////////////////////////

  constructor(private orderService: OrderService, private kitchenService: KitchenService) {
    this.order = new kitchenOrderModel();
  }

  ngOnInit(): void {
    //console.log('init...');
    this.order.OrderType = localStorage.getItem('OrderType');
    this.order.OrderNumber = localStorage.getItem('OrderNumber');
    this.order.Status = localStorage.getItem('OrderStatus');
    this.order.Description = localStorage.getItem('OrderDescription');
    //console.log('After init...: ', this.order);

  }


  populateModel(order){
   console.log('kitchen order: ' + order.OrderType);

   this.order = order;
   localStorage.setItem('OrderType', this.order.OrderType);
   localStorage.setItem('OrderNumber', this.order.OrderNumber);
   localStorage.setItem('OrderStatus', this.order.Status);
   localStorage.setItem('OrderDescription', this.order.Description);
   //console.log('this.Order: ',this.order);
  }

  updateStatus(order)
  {
    let toBeUpdated = order;
    console.log('to be updated: '+ toBeUpdated.OrderType +' ');
    this.orderService.getOrderById(order.OrderNumber)
    .subscribe(data => {
      console.log("Data: ", data.orderStatusId);
      this.completeStatusUpdate(data);

    });

    console.log('Update status: '+ this.selectedStatus +' ');
  }
  completeStatusUpdate(data)
  {
    data.orderStatusId = Number(this.selectedStatus);
    this.orderService.updateOrder(data).subscribe(o => {
      console.log("Completed Update: ", o);
    });

  };
  selectChangeHandler(event: any) {
    //update the ui
    this.selectedStatus = event.target.value;
    console.log('Selected status: '+ this.selectedStatus +' ');
  }
}

interface Stats {
  value: string;
  viewValue: string;
}

