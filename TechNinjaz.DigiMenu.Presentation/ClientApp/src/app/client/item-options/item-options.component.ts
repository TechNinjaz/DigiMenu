import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {IMenuItem} from '../../shared/model/menu-item';
import {IMenuItemOption} from '../../shared/model/menu-item-option';
import {MenuOptionService} from '../../shared/service/menu-option.service';
import {IOrderDetail} from '../../shared/model/order-detail';

@Component({
  selector: 'app-item-options',
  templateUrl: './item-options.component.html',
  styleUrls: ['./item-options.component.scss']
})
export class ItemOptionsComponent implements OnInit {

  itemOptions: IMenuItemOption[];
  selectedOptions: IMenuItemOption[];
  orderDetail: IOrderDetail;

  compareFunction = (o1: any, o2: any) => o1.id === o2.id;

  constructor(public dialogRef: MatDialogRef<ItemOptionsComponent>,
              private menuOptionService: MenuOptionService,
              @Inject(MAT_DIALOG_DATA) public menuItem: IMenuItem) { }

  ngOnInit(): void {
    this.orderDetail = {} as IOrderDetail;
    this.getByItemsCategoryId(this.menuItem.id);
  }

  getByItemsCategoryId(id: number): void {
    this.menuOptionService.getMenuOptionsByItemId(id)
      .subscribe((items: IMenuItemOption[]) => {
        this.itemOptions = items;
      });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  addToBasket(): void {
    this.orderDetail.menuItemId = this.menuItem.id;
    this.orderDetail.selectedOptions = [];

    this.selectedOptions?.forEach(selected =>
      this.orderDetail.selectedOptions.push({
        id: 0,
        description: selected.description
      }));

    this.dialogRef.close(this.orderDetail);
  }
}
