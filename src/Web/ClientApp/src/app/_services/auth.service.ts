import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

import { SignIn } from '../_models/signin';
import { DashboardModule } from '../main/dashboard/dashboard.module';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class AuthService {

  @Output() isLoggedIn: EventEmitter<any> = new EventEmitter<any>();

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  public authenticateUser(userData: SignIn) {
    return this.http.post('https://localhost:6001/api/auth', userData);
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    // Check whether the token is expired and return
    // true or false
    const isTokenNotExpired = !this.jwtHelper.isTokenExpired(token);

    if (isTokenNotExpired) {
      this.isLoggedIn.emit(true);
      return true;
    }

    return false;
  }

  getEmitter() {
    return this.isLoggedIn;
  }

}
