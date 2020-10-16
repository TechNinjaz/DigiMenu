import {Component,  OnInit} from '@angular/core';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  title = environment.APP_TITLE;
  toggleActive = false;

  ngOnInit(): void {
  }

  constructor() {
  }

  public onSidenavClick(): void {
    this.toggleActive = !this.toggleActive;
  }
}
