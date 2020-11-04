import {Injectable} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {AppUtils} from "../util/AppUtils";

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  localStorage: Storage;
  storageChange: BehaviorSubject<any>;

  constructor() {
    this.localStorage = window.localStorage;
    this.storageChange = new BehaviorSubject('EMPTY');
  }

  getItem(key: string): any {
    if (this.isLocalStorageSupported) {
      return JSON.parse(this.localStorage.getItem(key));
    }
    return null;
  }

  addItem(key: string, value: any): boolean {
    if (this.isLocalStorageSupported) {
      this.localStorage.setItem(key, JSON.stringify(value));
      this.storageChange.next({
        type: AppUtils.STORAGE_ADD_TYPE_KEY,
        key,
        value
      });
      return true;
    }
    return false;
  }

  removeItem(key: string): boolean {
    if (this.isLocalStorageSupported) {
      this.localStorage.removeItem(key);
      this.storageChange.next({
        type: AppUtils.STORAGE_REMOVE_TYPE_KEY,
        key
      });
      return true;
    }
    return false;
  }

  get isLocalStorageSupported(): boolean {
    return !!this.localStorage;
  }
}
