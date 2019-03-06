import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

import { SignIn } from '../_models/signin';
import { DashboardModule } from '../main/dashboard/dashboard.module';

@Injectable()
export class AuthService {

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  public authenticateUser(userData: SignIn) {
    return this.http.post('https://localhost:6001/api/auth', userData);
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    // Check whether the token is expired and return
    // true or false
    return !this.jwtHelper.isTokenExpired(token);
  }

}
