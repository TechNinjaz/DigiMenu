import {Injectable} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {AppConstUtils} from '../../util/AppConstUtils';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  storageChange: BehaviorSubject<any>;

  constructor() {
    this.storageChange = new BehaviorSubject(null);
  }

  getItem(key: string): any {
    if (this.isLocalStorageSupported()) {
      const value: any = localStorage.getItem(key);
      return JSON.parse(value);
    }
    return null;
  }

  addItem(key: string, value: any): boolean {
    if (this.isLocalStorageSupported()) {
      localStorage.setItem(key, JSON.stringify(value));
      this.storageChange.next({
        type: AppConstUtils.STORAGE_ADD_TYPE_KEY,
        key,
        value
      });
      return true;
    }
    return false;
  }

  removeItem(key: string): boolean {
    if (this.isLocalStorageSupported()) {
      localStorage.removeItem(key);
      this.storageChange.next({
        type: AppConstUtils.STORAGE_REMOVE_TYPE_KEY,
        key
      });
      return true;
    }
    return false;
  }

  clearStorage(): void {
    localStorage.clear();
    this.storageChange.next(null);
  }

  isLocalStorageSupported(): boolean {
    return !!localStorage;
  }
}
