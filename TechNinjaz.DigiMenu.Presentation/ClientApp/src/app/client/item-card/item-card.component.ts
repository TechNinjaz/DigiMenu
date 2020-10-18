import {Component, Input, OnInit} from '@angular/core';
import {IMenuItem} from '../../shared/model/menu-item';
import {ItemOptionsComponent} from '../item-options/item-options.component';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {

  @Input()
  MenuItem: IMenuItem;

  constructor(private dialog: MatDialog) {
  }

  ngOnInit(): void {
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ItemOptionsComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}
