import {HttpHeaders} from '@angular/common/http';
import {throwError} from 'rxjs';
import {environment} from '../../../environments/environment';

export class AppUtils {

  public static BASE_API_URL: any = environment.BASE_API_URL + '/api/';
  public static TITLE = environment.APP_TITLE;
  public static CART_KEY = 'CURRENT_ORDER';
  public static STORAGE_ADD_TYPE_KEY = 'ADD';
  public static STORAGE_REMOVE_TYPE_KEY = 'REMOVE';

  public static httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  public static errorHandler(error): any {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.errors[0]?.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
