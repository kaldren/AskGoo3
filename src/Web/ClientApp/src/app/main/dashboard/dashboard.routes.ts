import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from 'src/app/_guards/auth-guard.service';
import { MessagesComponent } from './messages/messages.component';
import { SettingsComponent } from './settings/settings.component';

export const dashboardRoutes: Routes = [
  {
    path: 'dashboard',
    canActivate: [AuthGuardService],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'settings', component: SettingsComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: '**', redirectTo: 'home', pathMatch: 'full' },
    ]
  }
];
