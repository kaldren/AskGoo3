import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SignIn } from '../_models/signin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public authenticateUser(userData: SignIn) {
    return this.http.post('https://localhost:6001/api/auth', userData);
  }
}
