import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/_models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  model = new Login('kdrenski', 'kdrenski');

  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    console.log('submit clicked!');
  }

}
