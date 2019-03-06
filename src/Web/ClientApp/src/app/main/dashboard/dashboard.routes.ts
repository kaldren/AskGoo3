import { Routes } from "@angular/router";
import { LayoutComponent } from './layout/layout.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from 'src/app/_guards/auth-guard.service';

// TODO ROUTES
// https://codeburst.io/using-angular-route-guard-for-securing-routes-eabf5b86b4d1

export const dashboardRoutes: Routes = [
  {
    path: 'dashboard',
    component: LayoutComponent,
    canActivate: [AuthGuardService],
    children: [
      { path: '', redirectTo: '/', pathMatch: 'full' },
      { path: 'home', component: HomeComponent }
    ]
  }
];
