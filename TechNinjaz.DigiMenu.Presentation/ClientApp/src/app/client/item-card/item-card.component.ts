import {Component, Input, OnInit} from '@angular/core';
import {IMenuItem} from '../../shared/model/menu-item';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent implements OnInit {

  @Input()
  MenuItem: IMenuItem;

  constructor() { }

  ngOnInit(): void {
  }

}
