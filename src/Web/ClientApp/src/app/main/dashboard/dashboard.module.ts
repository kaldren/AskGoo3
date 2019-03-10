import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LayoutComponent } from './layout/layout.component';
import { dashboardRoutes } from './dashboard.routes';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuardService } from 'src/app/_guards/auth-guard.service';
import { AuthService } from 'src/app/_services/auth.service';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(dashboardRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost'],
        blacklistedRoutes: ['']
      }
    })
  ],
  providers: []
})
export class DashboardModule { }
