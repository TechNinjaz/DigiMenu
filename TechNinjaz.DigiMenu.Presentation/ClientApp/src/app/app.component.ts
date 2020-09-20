import {Component, OnInit, ViewChild} from '@angular/core';
import {environment} from '../environments/environment';
import {Title} from '@angular/platform-browser';
import {MatSidenav} from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title  = environment.APP_TITLE;
  @ViewChild('rightSidenav', {static: true}) sidenav: MatSidenav;
  public constructor(private titleService: Title ) { }

  ngOnInit(): void {
    this.titleService.setTitle(this.title);
  }

}
