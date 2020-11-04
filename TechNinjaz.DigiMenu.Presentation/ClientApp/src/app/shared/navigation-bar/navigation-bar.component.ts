import {Component,  OnInit} from '@angular/core';
import {AppUtils} from '../util/AppUtils';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  title: string;
  toggleActive: boolean;

  ngOnInit(): void {
    this.toggleActive = false;
    this.title = AppUtils.TITLE;
  }

  constructor() {
  }

  public onSidenavClick(): void {
    this.toggleActive = !this.toggleActive;
  }
}
