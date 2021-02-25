import {environment} from '../../../environments/environment';

export class AppConstUtils {

  public static BASE_API_URL: any = environment.BASE_URL + '/api/';
  public static TITLE = environment.APP_TITLE;
  public static CART_KEY = 'CURRENT_ORDER';
  public static CURRENT_USER_KEY = 'CURRENT_USER';
  public static STORAGE_ADD_TYPE_KEY = 'ADD';
  public static STORAGE_REMOVE_TYPE_KEY = 'REMOVE';
  public static CURRENT_USER_TOKEN = 'CURRENT_USER_TOKEN';

}
