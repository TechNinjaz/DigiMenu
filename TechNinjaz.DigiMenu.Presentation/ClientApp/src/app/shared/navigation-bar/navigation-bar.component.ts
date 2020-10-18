import {Component,  OnInit} from '@angular/core';
import {environment} from '../../../environments/environment';

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
    this.title = environment.APP_TITLE;
  }

  constructor() {
  }

  public onSidenavClick(): void {
    this.toggleActive = !this.toggleActive;
  }
}
