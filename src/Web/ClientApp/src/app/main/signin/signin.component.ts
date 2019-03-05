import { Component, OnInit } from '@angular/core';
import { SignIn } from 'src/app/_models/signin';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.less']
})
export class SignInComponent implements OnInit {

  signInUser: SignIn = {
    username: '',
    password: ''
  };

  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    console.log('submit clicked!');
  }

}
