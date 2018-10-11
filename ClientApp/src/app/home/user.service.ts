import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { UserModel } from './userModel';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }

  getUsersUrl = environment.apiUrl + "/users/";

  getUserByPhone(phone: string) {
    var fullUrl = this.getUsersUrl + phone;
    var user = this.http.get<UserModel>(fullUrl);
    return user;
  }

}
