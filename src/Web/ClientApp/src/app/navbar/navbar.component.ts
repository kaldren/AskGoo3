import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {

  isAuthenticated: boolean;
  appName: string = environment.appName;

  constructor(private authService: AuthService, private router: Router) {
   }

  ngOnInit() {
    this.authService.getEmitter().subscribe((isAuthenticated) => {
      this.isAuthenticated = isAuthenticated;
    });
  }

  signOutUser() {
    this.authService.signOutUser();
    this.authService.getEmitter().subscribe((isAuthenticated) => {
      this.isAuthenticated = isAuthenticated;
    });
  }

}
