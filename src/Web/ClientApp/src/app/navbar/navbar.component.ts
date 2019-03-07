import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {

  isAuthenticated: boolean;

  constructor(private authService: AuthService) {
   }

  ngOnInit() {
    this.authService.getEmitter().subscribe((isAuthenticated) => {
      this.isAuthenticated = isAuthenticated;
    });
  }

  signOutUser() {
    console.log('sign out...')
    this.authService.signOutUser();
    this.authService.getEmitter().subscribe((isAuthenticated) => {
      this.isAuthenticated = isAuthenticated;
    });
  }

}
