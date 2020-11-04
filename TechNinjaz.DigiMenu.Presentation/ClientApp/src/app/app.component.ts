import {Component, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {AppUtils} from './shared/util/AppUtils';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title: string;

  public constructor(private titleService: Title ) { }

  ngOnInit(): void {
    this.title = AppUtils.TITLE;
    this.titleService.setTitle(this.title);
  }

}
