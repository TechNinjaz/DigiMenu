import {ErrorHandler, Injectable, Injector} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';
import {ErrorService} from '../service/config/error-service';
import {NotificationService} from '../service/config/notification.service';

@Injectable({
  providedIn: 'root'
})
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private injector: Injector) {
  }

  handleError(error: Error | HttpErrorResponse): void {
    const errorService = this.injector.get(ErrorService);
    const notifier = this.injector.get(NotificationService);
    console.log(error);
    let message;
    if (error instanceof HttpErrorResponse) {  // Server error
      message = errorService.getServerErrorMessage(error);
      notifier.showError(message);
    } else {   // Client Error
      message = errorService.getClientErrorMessage(error);
      notifier.showError(message);
    }
  }
}
