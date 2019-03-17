import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from 'src/app/_guards/auth-guard.service';
import { MessagesComponent } from './messages/messages.component';
import { SettingsComponent } from './settings/settings.component';
import { MessageComponent } from './messages/message/message.component';
import { ProfileComponent } from './profile/profile.component';

export const dashboardRoutes: Routes = [
  {
    path: 'dashboard',
    canActivate: [AuthGuardService],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'messages/:id', component: MessageComponent },
      { path: 'settings', component: SettingsComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'profile/:id', component: ProfileComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: '**', redirectTo: 'home', pathMatch: 'full' },
    ]
  }
];
