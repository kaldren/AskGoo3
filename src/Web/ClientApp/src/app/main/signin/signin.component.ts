import { Component, OnInit } from '@angular/core';
import { SignIn } from 'src/app/_models/signin';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.less'],
  providers: [AuthService]
})
export class SignInComponent implements OnInit {

  signInUser: SignIn;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.signInUser  = {
      username: '',
      password: ''
    };
  }

  onSubmit() {
    this.authService.authenticateUser(this.signInUser)
      .subscribe((data) => {
        if (data['token']) {
          localStorage.setItem('token', data['token']);
          this.router.navigate(['dashboard/home']);
        } else {
        console.log('Invalid credentials.')
        }
      });
  }

}
