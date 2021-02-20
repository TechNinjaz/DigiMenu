import { Component, OnInit, ViewChild, ChangeDetectorRef   } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {KitchenService} from '../../shared/service/kitchen.service';
import {IOrder} from '../../shared/model/order';
import {kitchenOrderModel} from '../../shared/model/kitchen-order';
import { MatTableDataSource} from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { KitchenOrderComponent} from './kitchen-order/kitchen-order.component';
import { OrderService } from '../../shared/service/order.service';
import {MenuItemService} from '../../shared/service/menu-item.service';


@Component({
  selector: 'app-kitchen',
  templateUrl: './kitchen.component.html',
  styleUrls: ['./kitchen.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})

export class KitchenComponent implements OnInit {

  dataSource = [];
  component: KitchenOrderComponent;
  data: any;
  orders: IOrder[] = [];
  kitchernOrders: kitchenOrderModel[] = [];
  resultsLength = 0;

  columnsToDisplay = ['OrderNumber','OrderType', 'Status', 'Action'];
  expandedElement: PeriodicElement | null;
  orderHistories: IOrder;
  listData: MatTableDataSource<any>;
  constructor(private kitchenService: KitchenService, private dialog: MatDialog, private orderService: OrderService, private changeDetectorRefs: ChangeDetectorRef) {
    this.kitchenService.kitchenOrder = new KitchenOrderComponent(this.orderService, this.kitchenService);
   }

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;

  ngOnInit(): void {
    this.kitchenService.getAllOrders().subscribe(orders => {
      console.log("Observable: ", orders);
      this.orders = orders;
      this.populateGrid(orders);
      this.changeDetectorRefs.detectChanges();
    });
  }

  populateGrid(orders){

    let source: PeriodicElement[] = [];

    orders.forEach(element => {
      element.orderDetails.forEach(details => {
        details.selectedOptions.forEach(
          item => {
            source.push(
              {
                OrderType: item.description, OrderNumber: element.id, Status: element.orderStatusId.toString(), Description: item.description
              });
          });
        });
      });

    this.listData = new MatTableDataSource(source);
    this.listData.sort = this.sort;
    this.listData.paginator = this.paginator;
    }
  showOrder(row){
    this.data = row;
    this.kitchenService.kitchenOrder.order = row;
    this.kitchenService.populateForm(row);

    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    this.dialog.open(KitchenOrderComponent,  dialogConfig)
    .afterClosed().subscribe(result => {
      this.ngOnInit();
    });

  }
}

  export interface PeriodicElement {
    OrderType: string;
    OrderNumber: number;
    Status: string;
    Description: string;
  }

  // const ELEMENT_DATA: PeriodicElement[] = [
  //   {

  //     OrderType: 'Breakfast',
  //     OrderNumber: 1,
  //     Status: 'In progress',
  //     Description: `Hydrogen is a chemical element with Status H and atomic OrderNumber 1. With a standard
  //         atomic OrderNumber of 1.008, hydrogen is the lightest element on the periodic table.`
  //   }, {

  //     OrderType: 'Lunch',
  //     OrderNumber: 4,
  //     Status: 'In cue',
  //     Description: `Helium is a chemical element with Status He and atomic OrderNumber 2. It is a
  //         colorless, odorless, tasteless, non-toxic, inert, monatomic gas, the first in the noble gas
  //         group in the periodic table. Its boiling point is the lowest among all the elements.`
  //   }, {
  //     OrderType: 'Starter',
  //     OrderNumber: 6,
  //     Status: 'Ready for collection (complete)',
  //     Description: `Lithium is a chemical element with Status Li and atomic OrderNumber 3. It is a soft,
  //         silvery-white alkali metal. Under standard conditions, it is the lightest metal and the
  //         lightest solid element.`
  //   }, {
  //     OrderType: 'Breakfast',
  //     OrderNumber: 9,
  //     Status: 'Cue',
  //     Description: `Beryllium is a chemical element with Status Be and atomic OrderNumber 4. It is a
  //         relatively rare element in the universe, usually occurring as a product of the spallation of
  //         larger atomic nuclei that have collided with cosmic rays.`
  //   }
  // ];


