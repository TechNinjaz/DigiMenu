import {Component, OnInit} from '@angular/core';
import {AppConstUtils} from '../util/AppConstUtils';
import {IUser} from '../model/user';
import {LocalStorageService} from '../service/local-storage.service';
import {AccountService} from '../service/account.service';


@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  title: string;
  toggleActive: boolean;
  currentUser: IUser;

  constructor(private localStorageService: LocalStorageService,
              private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.toggleActive = false;
    this.title = AppConstUtils.TITLE;
    this.loadCurrentUser();
  }

  public onSidenavClick(): void {
    this.toggleActive = !this.toggleActive;
  }

  loadCurrentUser(): void {
    this.currentUser = this.localStorageService.getItem(AppConstUtils.CURRENT_USER_KEY);
    this.localStorageService.storageChange.subscribe(store => {
      if (store?.key === AppConstUtils.CURRENT_USER_KEY) {
        const isRemoveType: boolean = store?.type === AppConstUtils.STORAGE_REMOVE_TYPE_KEY;
        this.currentUser = isRemoveType ? null : store?.value;
      }
    });
  }

  logout(): void {
    this.accountService.logout();
  }
}
