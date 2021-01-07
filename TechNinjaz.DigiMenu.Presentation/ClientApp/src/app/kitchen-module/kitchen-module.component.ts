// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-kitchen-module',
//   templateUrl: './kitchen-module.component.html',
//   styleUrls: ['./kitchen-module.component.scss']
// })
// export class KitchenModuleComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }

import {Component} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';

/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-kitchen-module',
  styleUrls: ['./kitchen-module.component.scss'],
  templateUrl: './kitchen-module.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class KitchenModuleComponent {
  dataSource = ELEMENT_DATA;
  columnsToDisplay = ['OrderNumber','OrderType', 'Status'];
  expandedElement: PeriodicElement | null;
}

export interface PeriodicElement {
  OrderType: string;
  OrderNumber: number;
  Status: string;
  description: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    
    OrderType: 'Breakfast',
    OrderNumber: 1,
    Status: 'In progress',
    description: `Hydrogen is a chemical element with Status H and atomic OrderNumber 1. With a standard
        atomic OrderNumber of 1.008, hydrogen is the lightest element on the periodic table.`
  }, {
   
    OrderType: 'Lunch',
    OrderNumber: 4,
    Status: 'In cue',
    description: `Helium is a chemical element with Status He and atomic OrderNumber 2. It is a
        colorless, odorless, tasteless, non-toxic, inert, monatomic gas, the first in the noble gas
        group in the periodic table. Its boiling point is the lowest among all the elements.`
  }, {
    OrderType: 'Starter',
    OrderNumber: 6,
    Status: 'Ready for collection (complete)',
    description: `Lithium is a chemical element with Status Li and atomic OrderNumber 3. It is a soft,
        silvery-white alkali metal. Under standard conditions, it is the lightest metal and the
        lightest solid element.`
  }, {
    OrderType: 'Breakfast',
    OrderNumber: 9,
    Status: 'Cue',
    description: `Beryllium is a chemical element with Status Be and atomic OrderNumber 4. It is a
        relatively rare element in the universe, usually occurring as a product of the spallation of
        larger atomic nuclei that have collided with cosmic rays.`
  }
];

