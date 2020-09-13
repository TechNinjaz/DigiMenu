import {Component, OnInit} from '@angular/core';
import {environment} from '../environments/environment';
import {Title} from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title  = environment.APP_TITLE;

  public constructor(private titleService: Title ) { }

  ngOnInit(): void {
    this.titleService.setTitle(this.title);
  }

}
