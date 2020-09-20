import {Component,  OnInit} from '@angular/core';
import {environment} from '../../environments/environment';
import {NavBarService} from '../../service/nav-bar.service';

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

  constructor(private sidenav: NavBarService) {
  }

  public onSidenavClick(): void {
    console.log('Clicked');
    this.toggleActive = !this.toggleActive;
    this.sidenav.toggle();
  }
}
