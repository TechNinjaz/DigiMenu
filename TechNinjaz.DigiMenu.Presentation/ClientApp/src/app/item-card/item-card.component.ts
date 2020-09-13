import {Component, Input, OnInit} from '@angular/core';
import {MenuItemModel} from '../../model/menu-item';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {

  @Input() MenuItem: MenuItemModel;

  constructor() { }

  ngOnInit(): void {
  }

}
