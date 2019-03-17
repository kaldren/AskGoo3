import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  getSingleProfileById(id: number) {
    return this.http.get('api/profile/' + id);
  }
}
