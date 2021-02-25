import {Injectable} from '@angular/core';
import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';
import {AppConstUtils} from './AppConstUtils';

@Injectable({
  providedIn: 'root'
})
export class ServerErrorInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token: any = localStorage.getItem(AppConstUtils.CURRENT_USER_TOKEN);
    request = request.clone({
      setHeaders: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${JSON.parse(token)}`,
      }
    });

    return next.handle(request).pipe(
      retry(1),
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          console.log(' refresh token');
          //
        } else {
          return throwError(error);
        }
        return throwError(error?.message);
      }));
  }
}
