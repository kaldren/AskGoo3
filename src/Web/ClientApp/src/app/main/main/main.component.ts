import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.less'],
  host: {'class': 'main'}
})
export class MainComponent implements OnInit {

  isAuthenticated: boolean;

  constructor(private authService: AuthService) {
    this.isAuthenticated = authService.isAuthenticated();
   }

  ngOnInit() {
  }

}
