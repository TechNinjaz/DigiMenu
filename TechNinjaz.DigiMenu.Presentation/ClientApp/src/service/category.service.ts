import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import {CategoryModel} from '../model/category';
import {environment} from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  BaseUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) {
    this.BaseUrl =  environment.BASE_API_URL + '/api/MenuCategory/';
  }

 getCategoryList(): Observable<any> {
      return this.http.get<CategoryModel[]>(this.BaseUrl + 'GetAll')
        .pipe( retry(1), catchError(this.errorHandler));
  }

  errorHandler(error): any {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
